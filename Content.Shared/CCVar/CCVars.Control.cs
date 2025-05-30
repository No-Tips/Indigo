using Robust.Shared.Configuration;


namespace Content.Shared.CCVar;


public sealed partial class CCVars
{
    public static readonly CVarDef<string> ControlKeysPreset =
        CVarDef.Create("control.keys_preset", "", CVar.ARCHIVE | CVar.CLIENTONLY);
}
