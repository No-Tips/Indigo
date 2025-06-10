namespace Content.Shared.Localizations;


[Serializable, DataDefinition,]
public partial record struct LocalizedString()
{
    [DataField(required: true)]
    public string Key { get; set; } = null!;

    public LocalizedString(string key) : this()
    {
        Key = key;
    }

    public override string ToString() => Loc.GetString(Key);
}
