using Robust.Client.Graphics;
using Robust.Client.ResourceManagement;
using Robust.Shared.Utility;


namespace Content.Client.InterfaceGuidelines;


public sealed class TypographyManager
{
    [Dependency] private readonly IResourceCache _cache = null!;

    private readonly List<string> _symbolFontPaths =
        new()
        {
            "/Fonts/NotoSans/NotoSansSymbols-Regular.ttf", "/Fonts/NotoSans/NotoSansSymbols2-Regular.ttf"
        };

    public StackedFont GetFont(
        FontType type,
        TextStyle style = TextStyle.Body,
        FontWeight weight = FontWeight.Regular,
        FontModifier modifier = FontModifier.Normal
    ) =>
        GetFont(type, style.ToPx(), weight, modifier);

    public StackedFont GetFont(
        FontType type,
        int customSize,
        FontWeight weight = FontWeight.Regular,
        FontModifier modifier = FontModifier.Normal
    )
    {
        var basePath = type.ToBasePath();

        weight = type switch
        {
            FontType.Serif => weight switch
            {
                < FontWeight.Light => FontWeight.Light,
                _ => weight
            },
            FontType.Mono => weight switch
            {
                < FontWeight.Regular => FontWeight.Regular,
                FontWeight.Medium => FontWeight.Regular,
                FontWeight.SemiBold => FontWeight.Bold,
                > FontWeight.Bold => FontWeight.Bold,
                _ => weight
            },
            _ => weight
        };

        var weightPostfix = weight.ToPostfix();
        var modifierPostfix = modifier.ToPostfix();

        var path = new ResPath($"{basePath}-{weightPostfix}{modifierPostfix}.otf");
        var fontResource = _cache.GetResource<FontResource>(path);

        var fonts = new Font[_symbolFontPaths.Count + 1];

        fonts[0] = new VectorFont(fontResource, customSize);

        for (var i = 1; i < _symbolFontPaths.Count + 1; i++)
        {
            var symbolFontResource = _cache.GetResource<FontResource>(_symbolFontPaths[i - 1]);

            fonts[i] = new VectorFont(symbolFontResource, customSize);
        }

        return new(fonts);
    }
}

public enum FontType
{
    SansSerif,
    Serif,
    Mono
}

public static class FontTypeExtensions
{
    public static string ToBasePath(this FontType type) =>
        type switch
        {
            FontType.SansSerif => "/Fonts/Pretendard/Pretendard",
            FontType.Serif => "/Fonts/Merriweather/Merriweather",
            FontType.Mono => "/Fonts/Hack/Hack",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
}

public enum FontModifier
{
    Normal,

    /// <summary>
    ///     Not really italic but oblique 🤓
    /// </summary>
    Italic
}

public static class FontModifierExtensions
{
    public static string ToPostfix(this FontModifier modifier) =>
        modifier switch
        {
            FontModifier.Normal => "",
            FontModifier.Italic => "Italic",
            _ => throw new ArgumentOutOfRangeException(nameof(modifier), modifier, null)
        };
}

public enum FontWeight
{
    Thin,
    ExtraLight,
    Light,
    Regular,
    Medium,
    SemiBold,
    Bold,
    ExtraBold,
    Black
}

public static class FontWeightExtensions
{
    public static string ToPostfix(this FontWeight weight) =>
        weight switch
        {
            FontWeight.Thin => "Thin",
            FontWeight.ExtraLight => "ExtraLight",
            FontWeight.Light => "Light",
            FontWeight.Regular => "Regular",
            FontWeight.Medium => "Medium",
            FontWeight.SemiBold => "SemiBold",
            FontWeight.Bold => "Bold",
            FontWeight.ExtraBold => "ExtraBold",
            FontWeight.Black => "Black",
            _ => throw new ArgumentOutOfRangeException(nameof(weight), weight, null)
        };
}

public enum TextStyle
{
    LargeTitle,
    Title1,
    Title2,
    Title3,
    Headline,
    Body,
    Callout,
    Subheadline,
    Footnote
}

public static class TextSizeExtensions
{
    public static int ToPx(this TextStyle style) =>
        style switch
        {
            TextStyle.LargeTitle => 26,
            TextStyle.Title1 => 22,
            TextStyle.Title2 => 17,
            TextStyle.Title3 => 15,
            TextStyle.Headline => 13,
            TextStyle.Body => 13,
            TextStyle.Callout => 12,
            TextStyle.Subheadline => 11,
            TextStyle.Footnote => 10,
            _ => throw new ArgumentOutOfRangeException(nameof(style), style, null)
        };
}
