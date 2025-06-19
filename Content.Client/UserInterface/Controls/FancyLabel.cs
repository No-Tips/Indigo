using Content.Client.InterfaceGuidelines;
using Robust.Client.UserInterface.Controls;


namespace Content.Client.UserInterface.Controls;


public sealed class FancyLabel : Label
{
    [Dependency] private readonly TypographyManager _typographyManager = null!;

    public FontType? FontType
    {
        get => _fontType;
        set
        {
            _fontType = value;
            UpdateAppearance();
        }
    }

    public TextStyle? TextStyle
    {
        get => _textStyle;
        set
        {
            _textStyle = value;
            UpdateAppearance();
        }
    }

    public FontWeight? FontWeight
    {
        get => _fontWeight;
        set
        {
            _fontWeight = value;
            UpdateAppearance();
        }
    }

    private FontType?   _fontType;
    private TextStyle?  _textStyle;
    private FontWeight? _fontWeight;

    public FancyLabel()
    {
        IoCManager.InjectDependencies(this);
    }

    private void UpdateAppearance()
    {
        var style = TextStyle ?? InterfaceGuidelines.TextStyle.Body;
        var fontWeight = FontWeight ?? style switch
        {
            InterfaceGuidelines.TextStyle.Headline => InterfaceGuidelines.FontWeight.Medium,
            InterfaceGuidelines.TextStyle.Title3 or InterfaceGuidelines.TextStyle.Title2 => InterfaceGuidelines
                .FontWeight.SemiBold,
            InterfaceGuidelines.TextStyle.Title1     => InterfaceGuidelines.FontWeight.Bold,
            InterfaceGuidelines.TextStyle.LargeTitle => InterfaceGuidelines.FontWeight.ExtraBold,
            _                                        => InterfaceGuidelines.FontWeight.Regular
        };

        FontOverride = _typographyManager.GetFont(
            type: FontType ?? InterfaceGuidelines.FontType.SansSerif,
            style: TextStyle ?? InterfaceGuidelines.TextStyle.Body,
            weight: FontWeight ?? fontWeight
        );

        if (style <= InterfaceGuidelines.TextStyle.Headline)
            FontColorOverride = Color.White;
    }
}
