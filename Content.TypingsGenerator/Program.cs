// Copyright (C) 2025 Igor Spichkin

// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.

// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Content.IntegrationTests;
using Content.Shared.FixedPoint;
using Robust.Shared.Audio;
using Robust.Shared.GameObjects;
using Robust.Shared.Localization;
using Robust.Shared.Maths;
using Robust.Shared.Prototypes;
using Robust.Shared.Reflection;
using Robust.Shared.Serialization.Manager.Attributes;
using Robust.Shared.Utility;
using Vector3 = Robust.Shared.Maths.Vector3;


namespace Content.TypingsGenerator;


internal sealed class ReflectionManager
{
    private readonly List<Assembly> _assemblies = [];
    private readonly List<System.Type> _getAllTypesCache = [];

    public ReflectionManager()
    {
        _assemblies.Add(typeof(Robust.Shared.IoC.IoCManager).Assembly);
        _assemblies.Add(typeof(Robust.Client.IBaseClient).Assembly);
        _assemblies.Add(typeof(Robust.Server.IBaseServer).Assembly);
        _assemblies
            .Add(typeof(Shared.Entry.EntryPoint).Assembly);
        _assemblies
            .Add(typeof(Client.Entry.EntryPoint).Assembly);
        _assemblies
            .Add(typeof(Server.Entry.EntryPoint).Assembly);
    }

    public IEnumerable<System.Type> GetAllChildren<T>(bool inclusive = false) => GetAllChildren(typeof(T), inclusive);

    public IEnumerable<System.Type> GetAllChildren(System.Type baseType, bool inclusive = false)
    {
        EnsureGetAllTypesCache();

        foreach (var type in _getAllTypesCache)
        {
            if (!baseType.IsAssignableFrom(type) || type.IsAbstract)
                continue;

            if (baseType == type && !inclusive)
                continue;

            yield return type;
        }
    }

    private void EnsureGetAllTypesCache()
    {
        if (_getAllTypesCache.Count != 0)
            return;

        var totalLength = 0;
        var typeSets = new List<System.Type[]>();

        foreach (var assembly in _assemblies)
        {
            var types = assembly.GetTypes();
            typeSets.Add(types);
            totalLength += types.Length;
        }

        _getAllTypesCache.Capacity = totalLength;

        foreach (var typeSet in typeSets)
        {
            foreach (var type in typeSet)
            {
                var attribute = (ReflectAttribute?) Attribute.GetCustomAttribute(type, typeof(ReflectAttribute));

                if (!(attribute?.Discoverable ?? ReflectAttribute.DEFAULT_DISCOVERABLE))
                    continue;

                _getAllTypesCache.Add(type);
            }
        }
    }
}

internal record struct Type
{
    public const string BaseModuleName = "base";

    public string Name;

    public bool IsNullable;

    public string? Module;

    public List<Type> TypeArguments = [];

    public Type(
        string name,
        bool isNullable,
        string? module,
        List<Type>? typeArguments = null
    )
    {
        Name = name;
        IsNullable = isNullable;
        Module = module;
        TypeArguments = typeArguments ?? [];
    }

    public static Type? TryToBuiltinType(System.Type t, bool skipGenericCheck = false)
    {
        if (!skipGenericCheck && t.IsGenericType)
        {
            var genericDef = t.GetGenericTypeDefinition();

            if (genericDef == typeof(Nullable<>))
            {
                var ty = TryToBuiltinType(t.GenericTypeArguments[0], true);

                if (ty.HasValue)
                    ty = ty.Value with { IsNullable = true, };

                return ty;
            }

            var type = TryToBuiltinType(genericDef, true);

            if (type is null)
                return null;

            foreach (var p in t.GenericTypeArguments)
            {
                if (TryToBuiltinType(p) is not { } pType)
                    continue;

                type.Value.TypeArguments.Add(pType);
            }

            return type;
        }

        if (t == typeof(char))
            return new("Char", false, null);

        if (t == typeof(string) || t == typeof(TimeSpan))
            return new("String", false, null);

        if (t == typeof(bool))
            return new("Boolean", false, null);

        if (t == typeof(short))
            return new("Int16", false, null);

        if (t == typeof(int))
            return new("Int32", false, null);

        if (t == typeof(uint))
            return new("UInt32", false, null);

        if (t == typeof(float) || t == typeof(double))
            return new("Float", false, null);

        if (t == typeof(EntityUid))
            return new("EntityUid", false, BaseModuleName);

        if (t == typeof(ProtoId<>))
            return new Type("ProtoId", false, BaseModuleName);

        if (t == typeof(EntProtoId) || t == typeof(EntProtoId<>))
            return new Type("EntProtoId", false, BaseModuleName);

        if (t == typeof(LocId))
            return new Type("LocId", false, BaseModuleName);

        if (t == typeof(ResPath))
            return new Type("ResPath", false, BaseModuleName);

        if (t == typeof(AudioParams))
            return new Type("AudioParams", false, BaseModuleName);

        if (t == typeof(SoundSpecifier))
            return new Type("SoundSpecifier", false, BaseModuleName);

        if (t == typeof(Vector2i))
            return new Type("Vector2i", false, BaseModuleName);

        if (t == typeof(Vector2))
            return new Type("Vector2", false, BaseModuleName);

        if (t == typeof(Vector3))
            return new Type("Vector3", false, BaseModuleName);

        if (t == typeof(Color))
            return new Type("Color", false, BaseModuleName);

        if (t == typeof(Angle))
            return new Type("Angle", false, BaseModuleName);

        if (t == typeof(FixedPoint2))
            return new Type("FixedPoint2", false, BaseModuleName);

        if (t == typeof(HashSet<>) || t == typeof(ImmutableHashSet<>))
            return new Type("Set", false, null);

        if (t == typeof(Dictionary<,>) || t == typeof(ImmutableDictionary<,>) || t == typeof(ReadOnlyDictionary<,>) ||
            t == typeof(FrozenDictionary<,>))
            return new Type("Mapping", false, null);

        if (t == typeof(List<>) || t == typeof(IReadOnlyList<>) || t == typeof(ImmutableList<>) ||
            t == typeof(IReadOnlyCollection<>) || t.IsArray)
            return new Type("Listing", false, null);

        if (t == typeof(ComponentRegistry))
            return new Type("ComponentRegistry", false, BaseModuleName);

        return null;
    }

    public string Stringify()
    {
        var sb = new StringBuilder();

        if (Module is not null)
            sb.Append($"{Module}.");

        sb.Append(Name);

        if (TypeArguments.Count == 0)
        {
            if (IsNullable)
                sb.Append('?');

            return sb.ToString();
        }

        sb.Append('<');

        for (var i = 0; i < TypeArguments.Count; i++)
        {
            var type = TypeArguments[i];

            sb.Append(type.Stringify());
            sb.Append(i != TypeArguments.Count - 1 ? ',' : '>');
        }

        if (IsNullable)
            sb.Append('?');

        return sb.ToString();
    }
}

public enum FieldModifier
{
    None,
    Fixed
}

internal record struct FieldDefinition
{
    public string Name;

    public Type Type;

    public FieldModifier Modifier;

    public string? DefaultValue;

    public FieldDefinition(
        string name,
        Type type,
        FieldModifier modifier = FieldModifier.None,
        string? defaultValue = null
    )
    {
        Name = name;
        Type = type;
        Modifier = modifier;
        DefaultValue = defaultValue;
    }

    public string Stringify()
    {
        var sb = new StringBuilder();

        switch (Modifier)
        {
            case FieldModifier.None:
                break;
            case FieldModifier.Fixed:
                sb.Append("fixed ");

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        sb.Append($"{Name}: {Type.Stringify()}");

        if (DefaultValue is { } defaultValue)
            sb.Append($" = {defaultValue}");

        return sb.ToString();
    }
}

interface ITypeDefinition
{
    public string Name { get; }

    public string Stringify();
}

internal record struct EnumDefinition : ITypeDefinition
{
    public string Name { get; }

    public List<string> Variants = [];

    public EnumDefinition(string name, List<string> variants)
    {
        Name = name;
        Variants = variants;
    }

    public string Stringify()
    {
        var sb = new StringBuilder();

        sb.Append($"typealias {Name} = ");

        for (var i = 0; i < Variants.Count; i++)
        {
            sb.Append($"\"{Variants[i]}\"");

            if (i != Variants.Count - 1)
                sb.Append(" | ");
        }

        sb.AppendLine();

        return sb.ToString();
    }
}

internal record struct ClassDefinition : ITypeDefinition
{
    public string Name { get; }

    public List<FieldDefinition> Fields = [];

    public Type? Base;

    public ClassDefinition(string name, List<FieldDefinition> fields, Type? baseClass = null)
    {
        Name = name;
        Fields = fields;
        Base = baseClass;
    }

    public string Stringify()
    {
        var sb = new StringBuilder();

        sb.Append($"class {Name} ");

        if (Base is { } baseClass)
            sb.Append($"extends {baseClass.Stringify()} ");

        sb.AppendLine("{");

        foreach (var field in Fields)
        {
            sb.Append("  ");
            sb.AppendLine(field.Stringify());
        }

        sb.AppendLine("}");

        return sb.ToString();
    }

    public void MergeFields(ClassDefinition b)
    {
        foreach (var field in b.Fields)
        {
            if (Fields.Any(f => f.Name == field.Name))
                continue;

            Fields.Add(field);
        }
    }
}

internal record struct ModuleDefinition
{
    public string Name;

    public List<string> Imports;

    public List<ClassDefinition> ClassDefinitions;

    public ModuleDefinition(string name, List<string> imports, List<ClassDefinition> classDefinitions)
    {
        Name = name;
        Imports = imports;
        ClassDefinitions = classDefinitions;
    }

    public string Stringify()
    {
        var sb = new StringBuilder();

        foreach (var import in Imports)
            sb.AppendLine($"import \"{import}\"");

        if (Imports.Count > 0)
            sb.AppendLine();

        foreach (var def in ClassDefinitions)
            sb.AppendLine(def.Stringify());

        return sb.ToString();
    }
}

internal static class Program
{
    private const string PklFolder = "Pkl";
    private const string PklTypingsFile = $"{PklFolder}/typings.pkl";

    private static readonly Dictionary<System.Type, ITypeDefinition> GlobalTypes = [];
    private static readonly HashSet<string> ReservedWords = ["hidden", "abstract", "open", "delete",];

    private static async Task<int> Main()
    {
        var reflectionManager = new ReflectionManager();

        if (Path.GetFileName(Environment.CurrentDirectory) == $"{nameof(Content)}.{nameof(TypingsGenerator)}")
            Environment.CurrentDirectory = Path.GetFullPath(Path.Join(Environment.CurrentDirectory, "../../"));

        if (!Directory.Exists(Path.Join(Environment.CurrentDirectory, PklFolder)))
        {
            Console.WriteLine("The folder 'Resources/Prototype' not found");

            return -1;
        }

        if (File.Exists(PklTypingsFile))
            File.Delete(PklTypingsFile);

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var classes = GenerateTypings(reflectionManager);

        Console.WriteLine($"Typings generated in {(int) stopwatch.Elapsed.TotalMilliseconds} ms.");

        var sb = new StringBuilder();

        sb.AppendLine("// AUTO GENERATED\n");
        sb.AppendLine("import \"base.pkl\"");
        sb.AppendLine();

        foreach (var c in classes)
            sb.AppendLine(c.Value.Stringify());

        HashSet<string> saved = [];

        foreach (var kvp in GlobalTypes)
        {
            if (saved.Contains(kvp.Value.Name) || classes.ContainsKey(kvp.Value.Name))
                continue;

            sb.AppendLine(kvp.Value.Stringify());
            saved.Add(kvp.Value.Name);
        }

        await File.WriteAllTextAsync(PklTypingsFile, sb.ToString());

        return 0;
    }

    private static Dictionary<string, ClassDefinition> GenerateTypings(
        ReflectionManager reflectionManager
    )
    {
        var classes = new Dictionary<string, ClassDefinition>();

        foreach (var prototype in reflectionManager.GetAllChildren<IPrototype>())
        {
            if (prototype.FullName!.StartsWith("Robust.UnitTesting"))
                continue;

            var typeValue = CalculatePrototypeTypeName(prototype);

            var classDef = GenerateClassDefinition(
                    prototype,
                    [
                        new(
                            "type",
                            new("String", false, null),
                            FieldModifier.Fixed,
                            $"\"{typeValue}\"")
                    ]) with
                {
                    Base = new Type("Prototype", false, "base")
                };

            if (classes.TryGetValue(classDef.Name, out var oldDef))
            {
                oldDef.MergeFields(classDef);
                classes[classDef.Name] = oldDef;
            }
            else
                classes.Add(classDef.Name, classDef);

            if (GlobalTypes.TryGetValue(prototype, out var oldDef2) && oldDef2 is ClassDefinition oldClassDef)
            {
                oldClassDef.MergeFields(classDef);
                classes[classDef.Name] = oldClassDef;
            }
            else
                GlobalTypes.Add(prototype, classDef);
        }

        foreach (var component in reflectionManager.GetAllChildren<IComponent>())
        {
            if (component.FullName!.StartsWith("Robust.UnitTesting"))
                continue;

            var typeValue = JsonNamingPolicy.CamelCase.ConvertName(component.Name.Replace("Prototype", null));

            var classDef = GenerateClassDefinition(
                    component,
                    [
                        new(
                            "type",
                            new("String", false, null),
                            FieldModifier.Fixed,
                            $"\"{typeValue}\"")
                    ]) with
                {
                    Base = new Type("Component", false, "base")
                };

            if (classes.TryGetValue(classDef.Name, out var oldDef))
            {
                oldDef.MergeFields(classDef);
                classes[classDef.Name] = oldDef;
            }
            else
                classes.Add(classDef.Name, classDef);

            if (GlobalTypes.TryGetValue(component, out var oldDef2) && oldDef2 is ClassDefinition oldClassDef)
            {
                oldClassDef.MergeFields(classDef);
                classes[classDef.Name] = oldClassDef;
            }
            else
                GlobalTypes.Add(component, classDef);
        }

        return classes;
    }

    private static ClassDefinition GenerateClassDefinition(
        System.Type t,
        List<FieldDefinition>? baseFields = null
    )
    {
        var fields = new Dictionary<string, FieldDefinition>();

        foreach (var field in baseFields ?? [])
            fields.TryAdd(field.Name, field);

        foreach (var prop in t.GetAllProperties())
            if (GenerateFieldDefinition(t, prop) is { } def)
                fields.TryAdd(def.Name, def);

        foreach (var field in t.GetAllFields())
            if (GenerateFieldDefinition(t, field) is { } def)
                fields.TryAdd(def.Name, def);

        return new(t.Name, fields.Values.ToList());
    }

    private static EnumDefinition GenerateEnumDefinition(System.Type t)
    {
        var variants = new List<string>();

        foreach (var variant in t.GetEnumNames())
            variants.Add(variant);

        return new(t.Name, variants);
    }

    private static FieldDefinition? GenerateFieldDefinition(System.Type t, MemberInfo info)
    {
        if (info.GetCustomAttribute<DataFieldAttribute>() is not { } dataFieldAttribute)
            return null;

        System.Type type;

        if (info is PropertyInfo propertyInfo)
            type = propertyInfo.PropertyType;
        else if (info is FieldInfo fieldInfo)
            type = fieldInfo.FieldType;
        else
            return null;

        var isNullable = !dataFieldAttribute.Required;
        var def = Type.TryToBuiltinType(type);

        if (def is null)
        {
            if (type.IsGenericType)
            {
                Console.WriteLine(
                    $"Couldn't make the typings for the field '{type.FullName} {type.Name}' of type '{t.FullName}'");

                return null;
            }

            if (GlobalTypes.TryGetValue(type, out var globalType))
                def = new Type(globalType.Name, isNullable, null);
            else
            {
                if (!type.IsEnum && !type.HasCustomAttribute<DataDefinitionAttribute>() &&
                    !type.HasCustomAttribute<SerializableAttribute>())
                {
                    Console.WriteLine(
                        $"Couldn't make the typings for the field '{type.FullName} {type.Name}' of type '{t.FullName}'");

                    return new(GetFieldName(info, dataFieldAttribute), new Type("Dynamic", isNullable, null));
                }

                // TODO:
                if (type.IsAbstract || type.IsInterface)
                {
                    Console.WriteLine(
                        $"Couldn't make the typings for the field '{type.FullName} {type.Name}' of type '{t.FullName}'");

                    def = new Type("Dynamic", isNullable, null);
                }
                else if (type.IsEnum)
                {
                    var newEnum = GenerateEnumDefinition(type);

                    def = new Type(newEnum.Name, isNullable, null);

                    GlobalTypes.Add(type, newEnum);
                }
                else
                {
                    var newClass = GenerateClassDefinition(type);

                    def = new Type(newClass.Name, isNullable, null);

                    GlobalTypes.Add(type, newClass);
                }
            }
        }

        def = def.Value with { IsNullable = isNullable, };

        return new(GetFieldName(info, dataFieldAttribute), def.Value);
    }

    private static string GetFieldName(MemberInfo fieldInfo, DataFieldAttribute dataField)
    {
        string name;

        if (dataField.Tag is { } tag)
            name = tag;
        else
            name = JsonNamingPolicy.CamelCase.ConvertName(fieldInfo.Name);

        return ReservedWords.Contains(name) ? $"`{name}`" : name;
    }

    private static string CalculatePrototypeTypeName(System.Type type)
    {
        if (type.GetCustomAttribute<PrototypeAttribute>() is { } prototypeAttribute &&
            prototypeAttribute.Type is { } typeOverride)
            return typeOverride;

        const string prototype = "Prototype";

        if (!type.Name.EndsWith(prototype))
            throw new InvalidPrototypeNameException($"Prototype {type} must end with the word Prototype");

        var name = type.Name.AsSpan();
        return $"{char.ToLowerInvariant(name[0])}{name[1..^prototype.Length]}";
    }
}
