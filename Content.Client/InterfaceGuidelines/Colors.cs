namespace Content.Client.InterfaceGuidelines;


public static class Colors
{
    public static readonly Color Black = Color.FromHex("#191919");
    public static readonly Color Gray  = Color.FromHex("#353535");

    #region Window

    public static          Color WindowBackgroundColor => Black;
    public static readonly Color WindowBorderColor      = new(0, 0, 0);
    public static readonly Color WindowInsetBorderColor = new(48, 48, 48);

    public static          Color WindowTitlebarBackgroundColor => Gray;
    public static          Color WindowTitlebarBorderColor     => WindowBorderColor;
    public static readonly Color WindowTitlebarInsetBorderColor = new(73, 73, 73);

    #endregion
}
