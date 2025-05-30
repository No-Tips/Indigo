using System.Linq;
using Content.Shared.CCVar;
using Robust.Client.Input;
using Robust.Shared.Configuration;
using Robust.Shared.Reflection;
using Robust.Shared.Sandboxing;


namespace Content.Client.KeyPresets;


public sealed class KeyPresetsManager
{
    [Dependency] private readonly IConfigurationManager _configurationManager = null!;
    [Dependency] private readonly IInputManager _inputManager = null!;
    [Dependency] private readonly IReflectionManager _reflectionManager = null!;
    [Dependency] private readonly ISandboxHelper _sandboxHelper = null!;

    private List<KeysPreset> _keyPresets = [];

    public void Initialize()
    {
        foreach (var preset in _reflectionManager.GetAllChildren<KeysPreset>())
        {
            if (preset.IsAbstract)
                continue;

            _keyPresets.Add((_sandboxHelper.CreateInstance(preset) as KeysPreset)!);
        }

        _keyPresets = _keyPresets.OrderBy(p => p.Name).ToList();

        var value = _configurationManager.GetCVar(CCVars.ControlKeysPreset);

        if (string.IsNullOrEmpty(value))
            return;

        foreach (var preset in _keyPresets)
        {
            if (preset.Name != value)
                continue;

            ApplyPreset(preset);

            return;
        }

        _configurationManager.SetCVar(CCVars.ControlKeysPreset, "");
    }

    public IReadOnlyList<KeysPreset> GetKeyPresets() => _keyPresets;

    public void ApplyPreset(KeysPreset preset)
    {
        _configurationManager.SetCVar(CCVars.ControlKeysPreset, preset.Name);
        _configurationManager.SaveToFile();
        preset.Apply(_inputManager);
    }
}
