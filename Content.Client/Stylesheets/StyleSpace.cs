using System.Linq;
using Content.Client.InterfaceGuidelines;
using Content.Client.Resources;
using Robust.Client.Graphics;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Robust.Client.UserInterface.StylesheetHelpers;


namespace Content.Client.Stylesheets;


public sealed class StyleSpace : StyleBase
{
    public static readonly Color SpaceRed = Color.FromHex("#9b2236");

    public static readonly Color ButtonColorDefault = Color.FromHex("#464966");
    public static readonly Color ButtonColorHovered = Color.FromHex("#575b7f");
    public static readonly Color ButtonColorPressed = Color.FromHex("#3e6c45");
    public static readonly Color ButtonColorDisabled = Color.FromHex("#30313c");

    public static readonly Color ButtonColorCautionDefault = Color.FromHex("#ab3232");
    public static readonly Color ButtonColorCautionHovered = Color.FromHex("#cf2f2f");
    public static readonly Color ButtonColorCautionPressed = Color.FromHex("#3e6c45");
    public static readonly Color ButtonColorCautionDisabled = Color.FromHex("#602a2a");

    public override Stylesheet Stylesheet { get; }

    public StyleSpace(IResourceCache resCache, TypographyManager typographyManager) : base(resCache)
    {
        var progressBarBackground = new StyleBoxFlat
        {
            BackgroundColor = new(0.25f, 0.25f, 0.25f)
        };
        progressBarBackground.SetContentMarginOverride(StyleBox.Margin.Vertical, 14.5f);

        var progressBarForeground = new StyleBoxFlat
        {
            BackgroundColor = new(0.25f, 0.50f, 0.25f)
        };
        progressBarForeground.SetContentMarginOverride(StyleBox.Margin.Vertical, 14.5f);

        var textureInvertedTriangle = resCache.GetTexture("/Textures/Interface/Nano/inverted_triangle.svg.png");

        var tabContainerPanel = new StyleBoxTexture();
        tabContainerPanel.SetPatchMargin(StyleBox.Margin.All, 2);

        var tabContainerBoxActive = new StyleBoxFlat { BackgroundColor = new(64, 64, 64), };
        tabContainerBoxActive.SetContentMarginOverride(StyleBox.Margin.Horizontal, 5);
        var tabContainerBoxInactive = new StyleBoxFlat { BackgroundColor = new(32, 32, 32), };
        tabContainerBoxInactive.SetContentMarginOverride(StyleBox.Margin.Horizontal, 5);

        Stylesheet = new(
            BaseRules.Concat(
                [
                    Element<Label>()
                        .Class(StyleClassLabelHeading)
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetFont(FontType.SansSerif, TextStyle.Title3, FontWeight.SemiBold))
                        .Prop(Label.StylePropertyFontColor, SpaceRed),

                    Element<Label>()
                        .Class(StyleClassLabelSubText)
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetFont(FontType.SansSerif, TextStyle.Footnote))
                        .Prop(Label.StylePropertyFontColor, Color.DarkGray),

                    Element<PanelContainer>()
                        .Class(ClassHighDivider)
                        .Prop(
                            PanelContainer.StylePropertyPanel,
                            new StyleBoxFlat
                            {
                                BackgroundColor = SpaceRed, ContentMarginBottomOverride = 2,
                                ContentMarginLeftOverride = 2
                            }),

                    Element<PanelContainer>()
                        .Class(ClassLowDivider)
                        .Prop(
                            PanelContainer.StylePropertyPanel,
                            new StyleBoxFlat
                            {
                                BackgroundColor = Color.FromHex("#444"),
                                ContentMarginLeftOverride = 2,
                                ContentMarginBottomOverride = 2
                            }),

                    // Shapes for the buttons.
                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Prop(ContainerButton.StylePropertyStyleBox, BaseButton),

                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Class(ButtonOpenRight)
                        .Prop(ContainerButton.StylePropertyStyleBox, BaseButtonOpenRight),

                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Class(ButtonOpenLeft)
                        .Prop(ContainerButton.StylePropertyStyleBox, BaseButtonOpenLeft),

                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Class(ButtonOpenBoth)
                        .Prop(ContainerButton.StylePropertyStyleBox, BaseButtonOpenBoth),

                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Class(ButtonSquare)
                        .Prop(ContainerButton.StylePropertyStyleBox, BaseButtonSquare),

                    // Colors for the buttons.
                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDefault),

                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorHovered),

                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Pseudo(ContainerButton.StylePseudoClassPressed)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorPressed),

                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Pseudo(ContainerButton.StylePseudoClassDisabled)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDisabled),

                    // Colors for the caution buttons.
                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Class(ButtonDanger)
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorCautionDefault),

                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Class(ButtonDanger)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorCautionHovered),

                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Class(ButtonDanger)
                        .Pseudo(ContainerButton.StylePseudoClassPressed)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorCautionPressed),

                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Class(ButtonDanger)
                        .Pseudo(ContainerButton.StylePseudoClassDisabled)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorCautionDisabled),


                    Element<Label>()
                        .Class(ContainerButton.StyleClassButton)
                        .Prop(Label.StylePropertyAlignMode, Label.AlignMode.Center),

                    Element<PanelContainer>()
                        .Class(ClassAngleRect)
                        .Prop(PanelContainer.StylePropertyPanel, BaseAngleRect)
                        .Prop(Control.StylePropertyModulateSelf, Color.FromHex("#202030")),

                    Child()
                        .Parent(Element<Button>().Class(ContainerButton.StylePseudoClassDisabled))
                        .Child(Element<Label>())
                        .Prop("font-color", Color.FromHex("#E5E5E581")),

                    Element<ProgressBar>()
                        .Prop(ProgressBar.StylePropertyBackground, progressBarBackground)
                        .Prop(ProgressBar.StylePropertyForeground, progressBarForeground),

                    // OptionButton
                    Element<OptionButton>()
                        .Prop(ContainerButton.StylePropertyStyleBox, BaseButton),

                    Element<OptionButton>()
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDefault),

                    Element<OptionButton>()
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorHovered),

                    Element<OptionButton>()
                        .Pseudo(ContainerButton.StylePseudoClassPressed)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorPressed),

                    Element<OptionButton>()
                        .Pseudo(ContainerButton.StylePseudoClassDisabled)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDisabled),

                    Element<TextureRect>()
                        .Class(OptionButton.StyleClassOptionTriangle)
                        .Prop(TextureRect.StylePropertyTexture, textureInvertedTriangle),

                    Element<Label>()
                        .Class(OptionButton.StyleClassOptionButton)
                        .Prop(Label.StylePropertyAlignMode, Label.AlignMode.Center),

                    // TabContainer
                    new(
                        new SelectorElement(typeof(TabContainer), null, null, null),
                        [
                            new(TabContainer.StylePropertyPanelStyleBox, tabContainerPanel),
                            new(TabContainer.StylePropertyTabStyleBox, tabContainerBoxActive),
                            new(
                                TabContainer.StylePropertyTabStyleBoxInactive,
                                tabContainerBoxInactive)
                        ])
                ])
                .ToList());
    }
}
