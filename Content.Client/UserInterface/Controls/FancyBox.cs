using Content.Shared.InterfaceGuidelines;
using Robust.Client.UserInterface.Controls;


namespace Content.Client.UserInterface.Controls;


public sealed class FancyPanelContainer : PanelContainer
{
    public Rounding Rounding { get; set; } = new(0.0f);

    public FancyPanelContainer()
    {
        PanelOverride = new RectBox
        {
            BackgroundColor = Colors.Black,
            Borders         = new(Colors.WindowInsetBorder, new(2.0f)),
            Rounding        = Rounding
        };
    }
}
