using Content.Client.InterfaceGuidelines;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Timing;


namespace Content.Client.UserInterface.Controls;


public sealed class FancyIcon : Label
{
    [Dependency] private readonly TypographyManager _typographyManager = null!;

    public TextStyle? TextStyle
    {
        get => _textStyle;
        set
        {
            _textStyle = value;
            _isDirty   = true;
        }
    }

    public FontWeight? FontWeight
    {
        get => _fontWeight;
        set
        {
            _fontWeight = value;
            _isDirty    = true;
        }
    }

    public bool Filled
    {
        get => _filled;
        set
        {
            _filled  = value;
            _isDirty = true;
        }
    }

    private TextStyle?  _textStyle;
    private FontWeight? _fontWeight;
    private bool        _filled = true;

    private bool _isDirty;

    public FancyIcon()
    {
        IoCManager.InjectDependencies(this);
    }

    protected override void FrameUpdate(FrameEventArgs args)
    {
        base.FrameUpdate(args);

        if (!_isDirty)
            return;

        _isDirty = false;
        UpdateAppearance();
    }

    private void UpdateAppearance() =>
        FontOverride = _typographyManager.GetSymbolsFont(
            _filled,
            style: TextStyle ?? InterfaceGuidelines.TextStyle.Title2,
            weight: FontWeight ?? InterfaceGuidelines.FontWeight.Regular
        );
}
