using System.Linq;
using Content.Client.ContextMenu.UI;
using Content.Client.Examine;
using Content.Client.InterfaceGuidelines;
using Content.Client.PDA;
using Content.Client.Resources;
using Content.Client.UserInterface.Controls;
using Content.Client.UserInterface.Controls.FancyTree;
using Content.Client.Verbs.UI;
using Content.Shared.InterfaceGuidelines;
using Content.Shared.Verbs;
using Robust.Client.Graphics;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using static Robust.Client.UserInterface.StylesheetHelpers;


namespace Content.Client.Stylesheets;


// STLYE SHEETS WERE A MISTAKE. KILL ALL OF THIS WITH FIRE
public sealed class StyleNano : StyleBase
{
    public const string StyleClassBorderedWindowPanel            = "BorderedWindowPanel";
    public const string StyleClassInventorySlotBackground        = "InventorySlotBackground";
    public const string StyleClassHandSlotHighlight              = "HandSlotHighlight";
    public const string StyleClassChatSubPanel                   = "ChatSubPanel";
    public const string StyleClassTransparentBorderedWindowPanel = "TransparentBorderedWindowPanel";
    public const string StyleClassHotbarPanel                    = "HotbarPanel";
    public const string StyleClassTooltipPanel                   = "tooltipBox";
    public const string StyleClassTooltipAlertTitle              = "tooltipAlertTitle";
    public const string StyleClassTooltipAlertDescription        = "tooltipAlertDesc";
    public const string StyleClassTooltipAlertCooldown           = "tooltipAlertCooldown";
    public const string StyleClassTooltipActionTitle             = "tooltipActionTitle";
    public const string StyleClassTooltipActionDescription       = "tooltipActionDesc";
    public const string StyleClassTooltipActionCooldown          = "tooltipActionCooldown";
    public const string StyleClassTooltipActionRequirements      = "tooltipActionCooldown";
    public const string StyleClassTooltipActionCharges           = "tooltipActionCharges";
    public const string StyleClassHotbarSlotNumber               = "hotbarSlotNumber";
    public const string StyleClassActionSearchBox                = "actionSearchBox";
    public const string StyleClassChatLineEdit                   = "chatLineEdit";
    public const string StyleClassChatChannelSelectorButton      = "chatSelectorOptionButton";
    public const string StyleClassChatFilterOptionButton         = "chatFilterOptionButton";
    public const string StyleClassStorageButton                  = "storageButton";

    public const string StyleClassConsoleHeading    = "ConsoleHeading";
    public const string StyleClassConsoleSubHeading = "ConsoleSubHeading";
    public const string StyleClassConsoleText       = "ConsoleText";

    public const string StyleClassSliderRed   = "Red";
    public const string StyleClassSliderGreen = "Green";
    public const string StyleClassSliderBlue  = "Blue";
    public const string StyleClassSliderWhite = "White";

    public const string StyleClassLabelHeadingBigger  = "LabelHeadingBigger";
    public const string StyleClassLabelKeyText        = "LabelKeyText";
    public const string StyleClassLabelSecondaryColor = "LabelSecondaryColor";
    public const string StyleClassLabelBig            = "LabelBig";
    public const string StyleClassLabelSmall          = "LabelSmall";
    public const string StyleClassButtonBig           = "ButtonBig";

    public const string StyleClassButtonHelp = "HelpButtonIcon";

    public static readonly Color PanelDark = Color.FromHex("#1E1E22");

    public static readonly Color GoodGreenFore        = Color.FromHex("#31843E");
    public static readonly Color ConcerningOrangeFore = Color.FromHex("#A5762F");
    public static readonly Color DangerousRedFore     = Color.FromHex("#BB3232");
    public static readonly Color DisabledFore         = Color.FromHex("#5A5A5A");

    public static readonly Color ButtonColorDefault    = Color.FromHex("#464950");
    public static readonly Color ButtonColorDefaultRed = Color.FromHex("#D43B3B");
    public static readonly Color ButtonColorHovered    = Color.FromHex("#575b61");
    public static readonly Color ButtonColorHoveredRed = Color.FromHex("#DF6B6B");
    public static readonly Color ButtonColorPressed    = Color.FromHex("#3e6c45");
    public static readonly Color ButtonColorDisabled   = Color.FromHex("#292929");

    public static readonly Color ButtonColorCautionDefault  = Color.FromHex("#8F6A33");
    public static readonly Color ButtonColorCautionHovered  = Color.FromHex("#C0934E");
    public static readonly Color ButtonColorCautionPressed  = Color.FromHex("#E49F35");
    public static readonly Color ButtonColorCautionDisabled = Color.FromHex("#28251F");

    public static readonly Color ButtonColorDangerDefault  = Color.FromHex("#7B2D2D");
    public static readonly Color ButtonColorDangerHovered  = Color.FromHex("#BD524B");
    public static readonly Color ButtonColorDangerPressed  = Color.FromHex("#C12525");
    public static readonly Color ButtonColorDangerDisabled = Color.FromHex("#2F2020");

    public static readonly Color ButtonColorGoodDefault  = Color.FromHex("#3E6C45");
    public static readonly Color ButtonColorGoodHovered  = Color.FromHex("#31843E");
    public static readonly Color ButtonColorGoodDisabled = Color.FromHex("#164420");

    // Context menu button colors
    public static readonly Color ButtonColorContext         = Color.FromHex("#1119");
    public static readonly Color ButtonColorContextHover    = Color.FromHex("#575b61");
    public static readonly Color ButtonColorContextPressed  = Color.FromHex("#3e6c45");
    public static readonly Color ButtonColorContextDisabled = Color.Black;

    // Examine button colors
    public static readonly Color ExamineButtonColorContext         = Color.Transparent;
    public static readonly Color ExamineButtonColorContextHover    = Color.FromHex("#575b61");
    public static readonly Color ExamineButtonColorContextPressed  = Color.FromHex("#3e6c45");
    public static readonly Color ExamineButtonColorContextDisabled = Color.FromHex("#5A5A5A");

    // Fancy Tree elements
    public static readonly Color FancyTreeEvenRowColor     = Color.FromHex("#25252A");
    public static readonly Color FancyTreeOddRowColor      = FancyTreeEvenRowColor * new Color(0.8f, 0.8f, 0.8f);
    public static readonly Color FancyTreeSelectedRowColor = new(55, 55, 68);

    //Used by the APC and SMES menus
    public const string StyleClassPowerStateNone = "PowerStateNone";
    public const string StyleClassPowerStateLow  = "PowerStateLow";
    public const string StyleClassPowerStateGood = "PowerStateGood";

    public const           string StyleClassItemStatus        = "ItemStatus";
    public const           string StyleClassItemStatusNotHeld = "ItemStatusNotHeld";
    public static readonly Color  ItemStatusNotHeldColor      = Color.Gray;

    //Buttons
    public const string StyleClassButtonColorRed   = "ButtonColorRed";
    public const string StyleClassButtonColorGreen = "ButtonColorGreen";

    public static readonly Color ChatBackgroundColor = Color.FromHex("#25252ADD");

    // DeltaV - AAC button variables
    public static readonly string CommandButtonClass     = "CommandButton";
    public static readonly string EngineeringButtonClass = "EngineeringButton";
    public static readonly string EpistemicsButtonClass  = "EpistemicsButton";
    public static readonly string JusticeButtonClass     = "JusticeButton";
    public static readonly string LogisticsButtonClass   = "LogisticsButton";
    public static readonly string MedicalButtonClass     = "MedicalButton";
    public static readonly string SecurityButtonClass    = "SecurityButton";
    public static readonly string ServiceButtonClass     = "ServiceButton";

    // DeltaV - AAC button colors
    public static readonly Color CommandButtonColorDefault     = Color.FromHex("#404A58");
    public static readonly Color CommandColorHovered           = Color.FromHex("#4F587B");
    public static readonly Color EngineeringButtonColorDefault = Color.FromHex("#77684B");
    public static readonly Color EngineeringColorHovered       = Color.FromHex("#776D71");
    public static readonly Color EpistemicsButtonColorDefault  = Color.FromHex("#6F5973");
    public static readonly Color EpistemicsColorHovered        = Color.FromHex("#71638E");
    public static readonly Color LogisticsButtonColorDefault   = Color.FromHex("#61503A");
    public static readonly Color LogisticsColorHovered         = Color.FromHex("#675C64");
    public static readonly Color JusticeButtonColorDefault     = Color.FromHex("#4F3D4C");
    public static readonly Color JusticeColorHovered           = Color.FromHex("#5C4B5A");
    public static readonly Color MedicalButtonColorDefault     = Color.FromHex("#49687D");
    public static readonly Color MedicalColorHovered           = Color.FromHex("#556E95");
    public static readonly Color SecurityButtonColorDefault    = Color.FromHex("#724449");
    public static readonly Color SecurityColorHovered          = Color.FromHex("#745370");
    public static readonly Color ServiceButtonColorDefault     = Color.FromHex("#607952");
    public static readonly Color ServiceColorHovered           = Color.FromHex("#667A76");
    // End DeltaV

    //Bwoink
    public const string StyleClassPinButtonPinned   = "pinButtonPinned";
    public const string StyleClassPinButtonUnpinned = "pinButtonUnpinned";


    #region Window

    public static RectBox FancyWindowPanel =>
        new()
        {
            Rounding        = new(14.0f),
            Borders         = new(Colors.WindowBorder, new(2.0f)),
            InsetBorders    = new(Colors.WindowInsetBorder, new(2.0f)),
            BackgroundColor = Colors.WindowBackground
        };

    public static RectBox FancyWindowPanelSmall =>
        new()
        {
            Rounding        = new(6.0f),
            Borders         = new(Colors.WindowBorder, new(2.0f)),
            InsetBorders    = new(Colors.WindowInsetBorder, new(2.0f)),
            BackgroundColor = Colors.WindowBackground
        };

    public static RectBox FancyWindowTitlebarPanel =>
        new()
        {
            Rounding                    = new(14.0f, 14.0f, 0.0f, 0.0f),
            Borders                     = new(Colors.WindowTitlebarBorder, new(2.0f)),
            InsetBorders                = new(Colors.WindowTitlebarInsetBorder, new(2.0f)),
            BackgroundColor             = Colors.WindowTitlebarBackground,
            ContentMarginBottomOverride = 14.0f
        };

    #endregion

    #region Chat

    public static RectBox ChatPanel =>
        new()
        {
            Borders         = new(Colors.ChatBorder, new(2.0f, 0.0f, 0.0f, 0.0f)),
            InsetBorders    = new(Colors.ChatInsetBorder, new(2.0f, 0.0f, 0.0f, 0.0f)),
            BackgroundColor = Colors.ChatBackground
        };

    #endregion

    public override Stylesheet Stylesheet { get; }

    public StyleNano(IResourceCache resCache, TypographyManager typographyManager) : base(resCache)
    {
        var windowHeaderTex = resCache.GetTexture("/Textures/Interface/Nano/window_header.png");
        var windowHeader = new StyleBoxTexture
        {
            Texture                     = windowHeaderTex,
            PatchMarginBottom           = 3,
            ExpandMarginBottom          = 3,
            ContentMarginBottomOverride = 0
        };
        var windowHeaderAlertTex = resCache.GetTexture("/Textures/Interface/Nano/window_header_alert.png");
        var windowHeaderAlert = new StyleBoxTexture
        {
            Texture                     = windowHeaderAlertTex,
            PatchMarginBottom           = 3,
            ExpandMarginBottom          = 3,
            ContentMarginBottomOverride = 0
        };
        var windowBackgroundTex = resCache.GetTexture("/Textures/Interface/Nano/window_background.png");
        var windowBackground = new StyleBoxTexture
        {
            Texture = windowBackgroundTex
        };
        windowBackground.SetPatchMargin(StyleBox.Margin.Horizontal | StyleBox.Margin.Bottom, 2);
        windowBackground.SetExpandMargin(StyleBox.Margin.Horizontal | StyleBox.Margin.Bottom, 2);

        var borderedWindowBackgroundTex =
            resCache.GetTexture("/Textures/Interface/Nano/window_background_bordered.png");
        var borderedWindowBackground = new StyleBoxTexture
        {
            Texture = borderedWindowBackgroundTex
        };
        borderedWindowBackground.SetPatchMargin(StyleBox.Margin.All, 2);

        var contextMenuBackground = new StyleBoxTexture
        {
            Texture = borderedWindowBackgroundTex
        };
        contextMenuBackground.SetPatchMargin(StyleBox.Margin.All, ContextMenuElement.ElementMargin);

        var invSlotBgTex = resCache.GetTexture("/Textures/Interface/Inventory/inv_slot_background.png");
        var invSlotBg = new StyleBoxTexture
        {
            Texture = invSlotBgTex
        };
        invSlotBg.SetPatchMargin(StyleBox.Margin.All, 2);
        invSlotBg.SetContentMarginOverride(StyleBox.Margin.All, 0);

        var handSlotHighlightTex = resCache.GetTexture("/Textures/Interface/Inventory/hand_slot_highlight.png");
        var handSlotHighlight = new StyleBoxTexture
        {
            Texture = handSlotHighlightTex
        };
        handSlotHighlight.SetPatchMargin(StyleBox.Margin.All, 2);

        var borderedTransparentWindowBackgroundTex =
            resCache.GetTexture("/Textures/Interface/Nano/transparent_window_background_bordered.png");
        var borderedTransparentWindowBackground = new StyleBoxTexture
        {
            Texture = borderedTransparentWindowBackgroundTex
        };
        borderedTransparentWindowBackground.SetPatchMargin(StyleBox.Margin.All, 2);

        var hotbarBackground = new StyleBoxTexture
        {
            Texture = borderedWindowBackgroundTex
        };
        hotbarBackground.SetPatchMargin(StyleBox.Margin.All, 2);
        hotbarBackground.SetExpandMargin(StyleBox.Margin.All, 4);

        var buttonStorage = new StyleBoxTexture(BaseButton);
        buttonStorage.SetPatchMargin(StyleBox.Margin.All, 10);
        buttonStorage.SetPadding(StyleBox.Margin.All, 0);
        buttonStorage.SetContentMarginOverride(StyleBox.Margin.Vertical, 0);
        buttonStorage.SetContentMarginOverride(StyleBox.Margin.Horizontal, 4);

        var buttonContext = new StyleBoxTexture { Texture = Texture.White, };

        var buttonRectTex = resCache.GetTexture("/Textures/Interface/Nano/light_panel_background_bordered.png");
        var buttonRect = new StyleBoxTexture(BaseButton)
        {
            Texture = buttonRectTex
        };
        buttonRect.SetPatchMargin(StyleBox.Margin.All, 2);
        buttonRect.SetPadding(StyleBox.Margin.All, 2);
        buttonRect.SetContentMarginOverride(StyleBox.Margin.Vertical, 2);
        buttonRect.SetContentMarginOverride(StyleBox.Margin.Horizontal, 2);

        var buttonRectActionMenuItemTex =
            resCache.GetTexture("/Textures/Interface/Nano/black_panel_light_thin_border.png");
        var buttonRectActionMenuRevokedItemTex =
            resCache.GetTexture("/Textures/Interface/Nano/black_panel_red_thin_border.png");
        var buttonRectActionMenuItem = new StyleBoxTexture(BaseButton)
        {
            Texture = buttonRectActionMenuItemTex
        };
        buttonRectActionMenuItem.SetPatchMargin(StyleBox.Margin.All, 2);
        buttonRectActionMenuItem.SetPadding(StyleBox.Margin.All, 2);
        buttonRectActionMenuItem.SetContentMarginOverride(StyleBox.Margin.Vertical, 2);
        buttonRectActionMenuItem.SetContentMarginOverride(StyleBox.Margin.Horizontal, 2);

        var buttonTex = resCache.GetTexture("/Textures/Interface/Nano/button.svg.96dpi.png");
        var topButtonBase = new StyleBoxTexture
        {
            Texture = buttonTex
        };
        topButtonBase.SetPatchMargin(StyleBox.Margin.All, 10);
        topButtonBase.SetPadding(StyleBox.Margin.All, 0);
        topButtonBase.SetContentMarginOverride(StyleBox.Margin.All, 0);

        var topButtonOpenRight = new StyleBoxTexture(topButtonBase)
        {
            Texture = new AtlasTexture(buttonTex, UIBox2.FromDimensions(new(0, 0), new(14, 24)))
        };
        topButtonOpenRight.SetPatchMargin(StyleBox.Margin.Right, 0);

        var topButtonOpenLeft = new StyleBoxTexture(topButtonBase)
        {
            Texture = new AtlasTexture(buttonTex, UIBox2.FromDimensions(new(10, 0), new(14, 24)))
        };
        topButtonOpenLeft.SetPatchMargin(StyleBox.Margin.Left, 0);

        var topButtonSquare = new StyleBoxTexture(topButtonBase)
        {
            Texture = new AtlasTexture(buttonTex, UIBox2.FromDimensions(new(10, 0), new(3, 24)))
        };
        topButtonSquare.SetPatchMargin(StyleBox.Margin.Horizontal, 0);

        var chatChannelButtonTex = resCache.GetTexture("/Textures/Interface/Nano/rounded_button.svg.96dpi.png");
        var chatChannelButton = new StyleBoxTexture
        {
            Texture = chatChannelButtonTex
        };
        chatChannelButton.SetPatchMargin(StyleBox.Margin.All, 5);
        chatChannelButton.SetPadding(StyleBox.Margin.All, 2);

        var chatFilterButtonTex = resCache.GetTexture("/Textures/Interface/Nano/rounded_button_bordered.svg.96dpi.png");
        var chatFilterButton = new StyleBoxTexture
        {
            Texture = chatFilterButtonTex
        };
        chatFilterButton.SetPatchMargin(StyleBox.Margin.All, 5);
        chatFilterButton.SetPadding(StyleBox.Margin.All, 2);

        var smallButtonTex = resCache.GetTexture("/Textures/Interface/Nano/button_small.svg.96dpi.png");
        var smallButtonBase = new StyleBoxTexture
        {
            Texture = smallButtonTex
        };

        var textureInvertedTriangle = resCache.GetTexture("/Textures/Interface/Nano/inverted_triangle.svg.png");

        var lineEditTex = resCache.GetTexture("/Textures/Interface/Nano/lineedit.png");
        var lineEdit = new StyleBoxTexture
        {
            Texture = lineEditTex
        };
        lineEdit.SetPatchMargin(StyleBox.Margin.All, 3);
        lineEdit.SetContentMarginOverride(StyleBox.Margin.Horizontal, 5);

        var chatSubBg = new StyleBoxFlat
        {
            BackgroundColor = ChatBackgroundColor
        };
        chatSubBg.SetContentMarginOverride(StyleBox.Margin.All, 2);

        var actionSearchBoxTex = resCache.GetTexture("/Textures/Interface/Nano/black_panel_dark_thin_border.png");
        var actionSearchBox = new StyleBoxTexture
        {
            Texture = actionSearchBoxTex
        };
        actionSearchBox.SetPatchMargin(StyleBox.Margin.All, 3);
        actionSearchBox.SetContentMarginOverride(StyleBox.Margin.Horizontal, 5);

        var tabContainerPanelTex = resCache.GetTexture("/Textures/Interface/Nano/tabcontainer_panel.png");
        var tabContainerPanel = new StyleBoxTexture
        {
            Texture = tabContainerPanelTex
        };
        tabContainerPanel.SetPatchMargin(StyleBox.Margin.All, 2);

        var tabContainerBoxActive = new StyleBoxFlat { BackgroundColor = new(64, 64, 64), };
        tabContainerBoxActive.SetContentMarginOverride(StyleBox.Margin.Horizontal, 5);
        var tabContainerBoxInactive = new StyleBoxFlat { BackgroundColor = new(32, 32, 32), };
        tabContainerBoxInactive.SetContentMarginOverride(StyleBox.Margin.Horizontal, 5);

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

        // CheckBox
        var checkBoxTextureChecked   = resCache.GetTexture("/Textures/Interface/Nano/checkbox_checked.svg.96dpi.png");
        var checkBoxTextureUnchecked = resCache.GetTexture("/Textures/Interface/Nano/checkbox_unchecked.svg.96dpi.png");
        var monotoneCheckBoxTextureChecked =
            resCache.GetTexture("/Textures/Interface/Nano/Monotone/monotone_checkbox_checked.svg.96dpi.png");
        var monotoneCheckBoxTextureUnchecked = resCache.GetTexture(
            "/Textures/Interface/Nano/Monotone/monotone_checkbox_unchecked.svg.96dpi.png");

        // Tooltip box
        var tooltipTexture = resCache.GetTexture("/Textures/Interface/Nano/tooltip.png");
        var tooltipBox = new StyleBoxTexture
        {
            Texture = tooltipTexture
        };
        tooltipBox.SetPatchMargin(StyleBox.Margin.All, 2);
        tooltipBox.SetContentMarginOverride(StyleBox.Margin.Horizontal, 7);

        // Whisper box
        var whisperTexture = resCache.GetTexture("/Textures/Interface/Nano/whisper.png");
        var whisperBox = new StyleBoxTexture
        {
            Texture = whisperTexture
        };
        whisperBox.SetPatchMargin(StyleBox.Margin.All, 2);
        whisperBox.SetContentMarginOverride(StyleBox.Margin.Horizontal, 7);

        // Placeholder
        var placeholderTexture = resCache.GetTexture("/Textures/Interface/Nano/placeholder.png");
        var placeholder        = new StyleBoxTexture { Texture = placeholderTexture, };
        placeholder.SetPatchMargin(StyleBox.Margin.All, 19);
        placeholder.SetExpandMargin(StyleBox.Margin.All, -5);
        placeholder.Mode = StyleBoxTexture.StretchMode.Tile;

        var itemListBackgroundSelected = new StyleBoxFlat { BackgroundColor = new(75, 75, 75), };
        itemListBackgroundSelected.SetContentMarginOverride(StyleBox.Margin.Vertical, 2);
        itemListBackgroundSelected.SetContentMarginOverride(StyleBox.Margin.Horizontal, 4);
        var itemListItemBackgroundDisabled = new StyleBoxFlat { BackgroundColor = new(10, 10, 10), };
        itemListItemBackgroundDisabled.SetContentMarginOverride(StyleBox.Margin.Vertical, 2);
        itemListItemBackgroundDisabled.SetContentMarginOverride(StyleBox.Margin.Horizontal, 4);
        var itemListItemBackground = new StyleBoxFlat { BackgroundColor = new(55, 55, 55), };
        itemListItemBackground.SetContentMarginOverride(StyleBox.Margin.Vertical, 2);
        itemListItemBackground.SetContentMarginOverride(StyleBox.Margin.Horizontal, 4);
        var itemListItemBackgroundTransparent = new StyleBoxFlat { BackgroundColor = Color.Transparent, };
        itemListItemBackgroundTransparent.SetContentMarginOverride(StyleBox.Margin.Vertical, 2);
        itemListItemBackgroundTransparent.SetContentMarginOverride(StyleBox.Margin.Horizontal, 4);

        var squareTex = resCache.GetTexture("/Textures/Interface/Nano/square.png");
        var listContainerButton = new StyleBoxTexture
        {
            Texture                   = squareTex,
            ContentMarginLeftOverride = 10
        };

        // NanoHeading
        var nanoHeadingTex = resCache.GetTexture("/Textures/Interface/Nano/nanoheading.svg.96dpi.png");
        var nanoHeadingBox = new StyleBoxTexture
        {
            Texture                   = nanoHeadingTex,
            PatchMarginRight          = 10,
            PatchMarginTop            = 10,
            ContentMarginTopOverride  = 2,
            ContentMarginLeftOverride = 10,
            PaddingTop                = 4
        };

        nanoHeadingBox.SetPatchMargin(StyleBox.Margin.Left | StyleBox.Margin.Bottom, 2);

        // Stripe background
        var stripeBackTex = resCache.GetTexture("/Textures/Interface/Nano/stripeback.svg.96dpi.png");
        var stripeBack = new StyleBoxTexture
        {
            Texture = stripeBackTex,
            Mode    = StyleBoxTexture.StretchMode.Tile
        };

        // Slider
        var sliderOutlineTex = resCache.GetTexture("/Textures/Interface/Nano/slider_outline.svg.96dpi.png");
        var sliderFillTex    = resCache.GetTexture("/Textures/Interface/Nano/slider_fill.svg.96dpi.png");
        var sliderGrabTex    = resCache.GetTexture("/Textures/Interface/Nano/slider_grabber.svg.96dpi.png");

        var sliderFillBox = new StyleBoxTexture
        {
            Texture  = sliderFillTex,
            Modulate = Color.FromHex("#3E6C45")
        };

        var sliderBackBox = new StyleBoxTexture
        {
            Texture  = sliderFillTex,
            Modulate = PanelDark
        };

        var sliderForeBox = new StyleBoxTexture
        {
            Texture  = sliderOutlineTex,
            Modulate = Color.FromHex("#494949")
        };

        var sliderGrabBox = new StyleBoxTexture
        {
            Texture = sliderGrabTex
        };

        sliderFillBox.SetPatchMargin(StyleBox.Margin.All, 12);
        sliderBackBox.SetPatchMargin(StyleBox.Margin.All, 12);
        sliderForeBox.SetPatchMargin(StyleBox.Margin.All, 12);
        sliderGrabBox.SetPatchMargin(StyleBox.Margin.All, 12);

        var sliderFillGreen = new StyleBoxTexture(sliderFillBox) { Modulate = Color.LimeGreen, };
        var sliderFillRed   = new StyleBoxTexture(sliderFillBox) { Modulate = Color.Red, };
        var sliderFillBlue  = new StyleBoxTexture(sliderFillBox) { Modulate = Color.Blue, };
        var sliderFillWhite = new StyleBoxTexture(sliderFillBox) { Modulate = Color.White, };

        var insetBack = new StyleBoxTexture
        {
            Texture  = buttonTex,
            Modulate = Color.FromHex("#202023")
        };
        insetBack.SetPatchMargin(StyleBox.Margin.All, 10);

        // Default paper background:
        var paperBackground = new StyleBoxTexture
        {
            Texture  = resCache.GetTexture("/Textures/Interface/Paper/paper_background_default.svg.96dpi.png"),
            Modulate = Color.FromHex("#eaedde") // A light cream
        };
        paperBackground.SetPatchMargin(StyleBox.Margin.All, 16.0f);

        Stylesheet = new(
            BaseRules.Concat(
                [
                    // Window title.
                    new(
                        new SelectorElement(
                            typeof(Label),
                            [DefaultWindow.StyleClassWindowTitle,],
                            null,
                            null),
                        [
                            new(
                                Label.StylePropertyFont,
                                typographyManager.GetFont(FontType.SansSerif, weight: FontWeight.Bold))
                        ]),
                    // Alert (white) window title.
                    new(
                        new SelectorElement(typeof(Label), ["windowTitleAlert",], null, null),
                        [
                            new(Label.StylePropertyFontColor, Color.White),
                            new(
                                Label.StylePropertyFont,
                                typographyManager.GetFont(FontType.SansSerif, weight: FontWeight.Bold))
                        ]),
                    // Window background.
                    new(
                        new SelectorElement(null, [DefaultWindow.StyleClassWindowPanel,], null, null),
                        [
                            new(PanelContainer.StylePropertyPanel, windowBackground)
                        ]),
                    // bordered window background
                    new(
                        new SelectorElement(null, [StyleClassBorderedWindowPanel,], null, null),
                        [
                            new(PanelContainer.StylePropertyPanel, borderedWindowBackground)
                        ]),
                    new(
                        new SelectorElement(null, [StyleClassTransparentBorderedWindowPanel,], null, null),
                        [
                            new(
                                PanelContainer.StylePropertyPanel,
                                borderedTransparentWindowBackground)
                        ]),
                    // inventory slot background
                    new(
                        new SelectorElement(null, [StyleClassInventorySlotBackground,], null, null),
                        [
                            new(PanelContainer.StylePropertyPanel, invSlotBg)
                        ]),
                    // hand slot highlight
                    new(
                        new SelectorElement(null, [StyleClassHandSlotHighlight,], null, null),
                        [
                            new(PanelContainer.StylePropertyPanel, handSlotHighlight)
                        ]),
                    // Hotbar background
                    new(
                        new SelectorElement(typeof(PanelContainer), [StyleClassHotbarPanel,], null, null),
                        [
                            new(PanelContainer.StylePropertyPanel, hotbarBackground)
                        ]),
                    // Window header.
                    new(
                        new SelectorElement(
                            typeof(PanelContainer),
                            [DefaultWindow.StyleClassWindowHeader,],
                            null,
                            null),
                        [
                            new(PanelContainer.StylePropertyPanel, windowHeader)
                        ]),
                    // Alert (red) window header.
                    new(
                        new SelectorElement(typeof(PanelContainer), ["windowHeaderAlert",], null, null),
                        [
                            new(PanelContainer.StylePropertyPanel, windowHeaderAlert)
                        ]),

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

                    #region Labels

                    Element<Label>()
                        .Class(UIStyleClasses.LabelIconFilledRegular1)
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetSymbolsFont(
                                filled: true,
                                style: TextStyle.Title1,
                                weight: FontWeight.Regular
                            )
                        ),

                    Element<Label>()
                        .Class(UIStyleClasses.LabelIconFilledRegular2)
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetSymbolsFont(
                                filled: true,
                                style: TextStyle.Title2,
                                weight: FontWeight.Regular
                            )
                        ),

                    Element<Label>()
                        .Class(UIStyleClasses.LabelIconFilledRegular3)
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetSymbolsFont(
                                filled: true,
                                style: TextStyle.Title3,
                                weight: FontWeight.Regular
                            )
                        ),

                    Element<Label>()
                        .Class(UIStyleClasses.LabelIconFilledSemiBold1)
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetSymbolsFont(
                                filled: true,
                                style: TextStyle.Title1,
                                weight: FontWeight.SemiBold
                            )
                        ),

                    Element<Label>()
                        .Class(UIStyleClasses.LabelIconFilledSemiBold2)
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetSymbolsFont(
                                filled: true,
                                style: TextStyle.Title2,
                                weight: FontWeight.SemiBold
                            )
                        ),

                    Element<Label>()
                        .Class(UIStyleClasses.LabelIconFilledSemiBold3)
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetSymbolsFont(
                                filled: true,
                                style: TextStyle.Title3,
                                weight: FontWeight.SemiBold
                            )
                        ),

                    Element<Label>()
                        .Class(UIStyleClasses.LabelIconFilledBold1)
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetSymbolsFont(
                                filled: true,
                                style: TextStyle.Title1,
                                weight: FontWeight.Bold
                            )
                        ),

                    Element<Label>()
                        .Class(UIStyleClasses.LabelIconFilledBold2)
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetSymbolsFont(
                                filled: true,
                                style: TextStyle.Title2,
                                weight: FontWeight.Bold
                            )
                        ),

                    Element<Label>()
                        .Class(UIStyleClasses.LabelIconFilledBold3)
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetSymbolsFont(
                                filled: true,
                                style: TextStyle.Title3,
                                weight: FontWeight.Bold
                            )
                        ),

                    #endregion

                    #region Buttons

                    Element<ContainerButton>()
                        .Class(UIStyleClasses.GhostButton)
                        .Prop(ContainerButton.StylePropertyStyleBox, new StyleBoxEmpty()),

                    #endregion

                    #region Windows

                    Element<PanelContainer>()
                        .Class(UIStyleClasses.FancyWindowPanel)
                        .Prop(PanelContainer.StylePropertyPanel, FancyWindowPanel),

                    Element<PanelContainer>()
                        .Class(UIStyleClasses.FancyWindowPanelSmall)
                        .Prop(PanelContainer.StylePropertyPanel, FancyWindowPanelSmall),

                    Element<Label>()
                        .Class(UIStyleClasses.FancyWindowTitle)
                        .Prop("font", typographyManager.GetFont(FontType.SansSerif, weight: FontWeight.Bold)),

                    Element<Label>()
                        .Class(UIStyleClasses.FancyWindowTitlebarIcon)
                        .Prop(
                            "font",
                            typographyManager.GetSymbolsFont(
                                true,
                                style: TextStyle.Title3,
                                weight: FontWeight.Bold
                            )
                        ),

                    Element<PanelContainer>()
                        .Class(UIStyleClasses.FancyWindowTitlebarPanel)
                        .Prop(PanelContainer.StylePropertyPanel, FancyWindowTitlebarPanel),

                    #endregion

                    #region Chat

                    Element<PanelContainer>()
                        .Class(UIStyleClasses.ChatPanel)
                        .Prop(PanelContainer.StylePropertyPanel, ChatPanel),

                    #endregion

                    #region Global Menu

                    Element<ContainerButton>()
                        .Class(UIStyleClasses.GlobalMenuCategoryButton)
                        .Prop(
                            ContainerButton.StylePropertyStyleBox,
                            new StyleBoxEmpty
                            {
                                Padding = new(8.0f, 0.0f)
                            }),

                    Element<ContainerButton>()
                        .Class(UIStyleClasses.GlobalMenuCategoryButton)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(
                            ContainerButton.StylePropertyStyleBox,
                            new StyleBoxFlat(new Color(255, 255, 255, 8))
                            {
                                Padding = new(8.0f, 0.0f)
                            }),

                    Element<Label>()
                        .Class(UIStyleClasses.GlobalMenuCategoryLabel)
                        .Prop("font", typographyManager.GetFont(FontType.SansSerif, weight: FontWeight.SemiBold)),

                    Element<Label>()
                        .Class(UIStyleClasses.GlobalMenuCategoryIcon)
                        .Prop(
                            "font",
                            typographyManager.GetSymbolsFont(
                                filled: true,
                                style: TextStyle.Title2,
                                weight: FontWeight.Regular
                            )
                        ),

                    Element<ContainerButton>()
                        .Class(UIStyleClasses.GlobalMenuPopupItem)
                        .Prop(
                            ContainerButton.StylePropertyStyleBox,
                            new StyleBoxEmpty
                            {
                                Padding = new(12.0f, 4.0f)
                            }),

                    Element<ContainerButton>()
                        .Class(UIStyleClasses.GlobalMenuPopupItem)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(
                            ContainerButton.StylePropertyStyleBox,
                            new StyleBoxFlat(new Color(255, 255, 255, 8))
                            {
                                Padding = new(12.0f, 4.0f)
                            }),

                    Element<Label>()
                        .Class(UIStyleClasses.GlobalMenuPopupItemHotkeyLabel)
                        .Prop(Label.StylePropertyFontColor, new Color(127, 127, 127)),

                    #endregion

                    new(
                        new SelectorElement(typeof(Label), [ContainerButton.StyleClassButton,], null, null),
                        [
                            new(Label.StylePropertyAlignMode, Label.AlignMode.Center)
                        ]),

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
                        .Class(ButtonCaution)
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorCautionDefault),

                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Class(ButtonCaution)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorCautionHovered),

                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Class(ButtonCaution)
                        .Pseudo(ContainerButton.StylePseudoClassPressed)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorCautionPressed),

                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Class(ButtonCaution)
                        .Pseudo(ContainerButton.StylePseudoClassDisabled)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorCautionDisabled),

                    // Colors for the danger buttons.
                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Class(ButtonDanger)
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDangerDefault),

                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Class(ButtonDanger)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDangerHovered),

                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Class(ButtonDanger)
                        .Pseudo(ContainerButton.StylePseudoClassPressed)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDangerPressed),

                    Element<ContainerButton>()
                        .Class(ContainerButton.StyleClassButton)
                        .Class(ButtonDanger)
                        .Pseudo(ContainerButton.StylePseudoClassDisabled)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDangerDisabled),

                    // Colors for confirm buttons confirm states.
                    Element<ConfirmButton>()
                        .Pseudo(ConfirmButton.ConfirmPrefix + ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDangerDefault),

                    Element<ConfirmButton>()
                        .Pseudo(ConfirmButton.ConfirmPrefix + ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDangerHovered),

                    Element<ConfirmButton>()
                        .Pseudo(ConfirmButton.ConfirmPrefix + ContainerButton.StylePseudoClassPressed)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDangerPressed),

                    Element<ConfirmButton>()
                        .Pseudo(ConfirmButton.ConfirmPrefix + ContainerButton.StylePseudoClassDisabled)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDangerDisabled),

                    new(
                        new SelectorChild(
                            new SelectorElement(
                                typeof(Button),
                                null,
                                null,
                                [ContainerButton.StylePseudoClassDisabled,]),
                            new SelectorElement(typeof(Label), null, null, null)),
                        [
                            new("font-color", Color.FromHex("#E5E5E581"))
                        ]),

                    // Context Menu window
                    Element<PanelContainer>()
                        .Class(ContextMenuPopup.StyleClassContextMenuPopup)
                        .Prop(PanelContainer.StylePropertyPanel, contextMenuBackground),

                    // Context menu buttons
                    Element<ContextMenuElement>()
                        .Class(ContextMenuElement.StyleClassContextMenuButton)
                        .Prop(ContainerButton.StylePropertyStyleBox, buttonContext),

                    Element<ContextMenuElement>()
                        .Class(ContextMenuElement.StyleClassContextMenuButton)
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorContext),

                    Element<ContextMenuElement>()
                        .Class(ContextMenuElement.StyleClassContextMenuButton)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorContextHover),

                    Element<ContextMenuElement>()
                        .Class(ContextMenuElement.StyleClassContextMenuButton)
                        .Pseudo(ContainerButton.StylePseudoClassPressed)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorContextPressed),

                    Element<ContextMenuElement>()
                        .Class(ContextMenuElement.StyleClassContextMenuButton)
                        .Pseudo(ContainerButton.StylePseudoClassDisabled)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorContextDisabled),

                    // Context Menu Labels
                    Element<RichTextLabel>()
                        .Class(InteractionVerb.DefaultTextStyleClass)
                        .Prop(Label.StylePropertyFont, typographyManager.GetFont(FontType.SansSerif)),

                    Element<RichTextLabel>()
                        .Class(ActivationVerb.DefaultTextStyleClass)
                        .Prop(Label.StylePropertyFont, typographyManager.GetFont(FontType.SansSerif)),

                    Element<RichTextLabel>()
                        .Class(AlternativeVerb.DefaultTextStyleClass)
                        .Prop(Label.StylePropertyFont, typographyManager.GetFont(FontType.SansSerif)),

                    Element<RichTextLabel>()
                        .Class(Verb.DefaultTextStyleClass)
                        .Prop(Label.StylePropertyFont, typographyManager.GetFont(FontType.SansSerif)),

                    // Context menu confirm buttons
                    Element<ContextMenuElement>()
                        .Class(ConfirmationMenuElement.StyleClassConfirmationContextMenuButton)
                        .Prop(ContainerButton.StylePropertyStyleBox, buttonContext),

                    Element<ContextMenuElement>()
                        .Class(ConfirmationMenuElement.StyleClassConfirmationContextMenuButton)
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDangerDefault),

                    Element<ContextMenuElement>()
                        .Class(ConfirmationMenuElement.StyleClassConfirmationContextMenuButton)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDangerHovered),

                    Element<ContextMenuElement>()
                        .Class(ConfirmationMenuElement.StyleClassConfirmationContextMenuButton)
                        .Pseudo(ContainerButton.StylePseudoClassPressed)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDangerPressed),

                    Element<ContextMenuElement>()
                        .Class(ConfirmationMenuElement.StyleClassConfirmationContextMenuButton)
                        .Pseudo(ContainerButton.StylePseudoClassDisabled)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDangerDisabled),

                    // Examine buttons
                    Element<ExamineButton>()
                        .Class(ExamineButton.StyleClassExamineButton)
                        .Prop(ContainerButton.StylePropertyStyleBox, buttonContext),

                    Element<ExamineButton>()
                        .Class(ExamineButton.StyleClassExamineButton)
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, ExamineButtonColorContext),

                    Element<ExamineButton>()
                        .Class(ExamineButton.StyleClassExamineButton)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, ExamineButtonColorContextHover),

                    Element<ExamineButton>()
                        .Class(ExamineButton.StyleClassExamineButton)
                        .Pseudo(ContainerButton.StylePseudoClassPressed)
                        .Prop(Control.StylePropertyModulateSelf, ExamineButtonColorContextPressed),

                    Element<ExamineButton>()
                        .Class(ExamineButton.StyleClassExamineButton)
                        .Pseudo(ContainerButton.StylePseudoClassDisabled)
                        .Prop(Control.StylePropertyModulateSelf, ExamineButtonColorContextDisabled),

                    // Thin buttons (No padding nor vertical margin)
                    Element<ContainerButton>()
                        .Class(StyleClassStorageButton)
                        .Prop(ContainerButton.StylePropertyStyleBox, buttonStorage),

                    Element<ContainerButton>()
                        .Class(StyleClassStorageButton)
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDefault),

                    Element<ContainerButton>()
                        .Class(StyleClassStorageButton)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorHovered),

                    Element<ContainerButton>()
                        .Class(StyleClassStorageButton)
                        .Pseudo(ContainerButton.StylePseudoClassPressed)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorPressed),

                    Element<ContainerButton>()
                        .Class(StyleClassStorageButton)
                        .Pseudo(ContainerButton.StylePseudoClassDisabled)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDisabled),
                    // ListContainer
                    Element<ContainerButton>()
                        .Class(ListContainer.StyleClassListContainerButton)
                        .Prop(ContainerButton.StylePropertyStyleBox, listContainerButton),

                    Element<ContainerButton>()
                        .Class(ListContainer.StyleClassListContainerButton)
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, new Color(55, 55, 68)),

                    Element<ContainerButton>()
                        .Class(ListContainer.StyleClassListContainerButton)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, new Color(75, 75, 86)),

                    Element<ContainerButton>()
                        .Class(ListContainer.StyleClassListContainerButton)
                        .Pseudo(ContainerButton.StylePseudoClassPressed)
                        .Prop(Control.StylePropertyModulateSelf, new Color(75, 75, 86)),

                    Element<ContainerButton>()
                        .Class(ListContainer.StyleClassListContainerButton)
                        .Pseudo(ContainerButton.StylePseudoClassDisabled)
                        .Prop(Control.StylePropertyModulateSelf, new Color(10, 10, 12)),

                    // Main menu: Make those buttons bigger.
                    new(
                        new SelectorChild(
                            new SelectorElement(typeof(Button), null, "mainMenu", null),
                            new SelectorElement(typeof(Label), null, null, null)),
                        [
                            new(
                                "font",
                                typographyManager.GetFont(
                                    FontType.SansSerif,
                                    TextStyle.Title3,
                                    weight: FontWeight.SemiBold))
                        ]),

                    // Main menu: also make those buttons slightly more separated.
                    new(
                        new SelectorElement(typeof(BoxContainer), null, "mainMenuVBox", null),
                        [
                            new(BoxContainer.StylePropertySeparation, 2)
                        ]),

                    // Fancy LineEdit
                    new(
                        new SelectorElement(typeof(LineEdit), null, null, null),
                        [
                            new(LineEdit.StylePropertyStyleBox, lineEdit)
                        ]),

                    new(
                        new SelectorElement(
                            typeof(LineEdit),
                            [LineEdit.StyleClassLineEditNotEditable,],
                            null,
                            null),
                        [
                            new("font-color", new Color(192, 192, 192))
                        ]),

                    new(
                        new SelectorElement(
                            typeof(LineEdit),
                            null,
                            null,
                            [LineEdit.StylePseudoClassPlaceholder,]),
                        [
                            new("font-color", Color.Gray)
                        ]),

                    Element<TextEdit>()
                        .Pseudo(TextEdit.StylePseudoClassPlaceholder)
                        .Prop("font-color", Color.Gray),

                    // Chat lineedit - we don't actually draw a stylebox around the lineedit itself, we put it around the
                    // input + other buttons, so we must clear the default stylebox
                    new(
                        new SelectorElement(typeof(LineEdit), [StyleClassChatLineEdit,], null, null),
                        [
                            new(LineEdit.StylePropertyStyleBox, new StyleBoxEmpty())
                        ]),

                    // Action searchbox lineedit
                    new(
                        new SelectorElement(typeof(LineEdit), [StyleClassActionSearchBox,], null, null),
                        [
                            new(LineEdit.StylePropertyStyleBox, actionSearchBox)
                        ]),

                    // TabContainer
                    new(
                        new SelectorElement(typeof(TabContainer), null, null, null),
                        [
                            new(TabContainer.StylePropertyPanelStyleBox, tabContainerPanel),
                            new(TabContainer.StylePropertyTabStyleBox, tabContainerBoxActive),
                            new(
                                TabContainer.StylePropertyTabStyleBoxInactive,
                                tabContainerBoxInactive)
                        ]),

                    // ProgressBar
                    new(
                        new SelectorElement(typeof(ProgressBar), null, null, null),
                        [
                            new(ProgressBar.StylePropertyBackground, progressBarBackground),
                            new(ProgressBar.StylePropertyForeground, progressBarForeground)
                        ]),

                    // CheckBox
                    new(
                        new SelectorElement(typeof(TextureRect), [CheckBox.StyleClassCheckBox,], null, null),
                        [
                            new(TextureRect.StylePropertyTexture, checkBoxTextureUnchecked)
                        ]),

                    new(
                        new SelectorElement(
                            typeof(TextureRect),
                            [CheckBox.StyleClassCheckBox, CheckBox.StyleClassCheckBoxChecked,],
                            null,
                            null),
                        [
                            new(TextureRect.StylePropertyTexture, checkBoxTextureChecked)
                        ]),

                    new(
                        new SelectorElement(
                            typeof(BoxContainer),
                            [CheckBox.StyleClassCheckBox,],
                            null,
                            null),
                        [
                            new(BoxContainer.StylePropertySeparation, 10)
                        ]),

                    new(
                        new SelectorElement(
                            typeof(TextureRect),
                            [MonotoneCheckBox.StyleClassCheckBox,],
                            null,
                            null),
                        [
                            new(TextureRect.StylePropertyTexture, monotoneCheckBoxTextureUnchecked)
                        ]),

                    new(
                        new SelectorElement(
                            typeof(TextureRect),
                            [
                                MonotoneCheckBox.StyleClassCheckBox, MonotoneCheckBox.StyleClassCheckBoxChecked
                            ],
                            null,
                            null),
                        [
                            new(TextureRect.StylePropertyTexture, monotoneCheckBoxTextureChecked)
                        ]),

                    new(
                        new SelectorElement(
                            typeof(BoxContainer),
                            [MonotoneCheckBox.StyleClassCheckBox,],
                            null,
                            null),
                        [
                            new(BoxContainer.StylePropertySeparation, 10)
                        ]),

                    // Tooltip
                    new(
                        new SelectorElement(typeof(Tooltip), null, null, null),
                        [
                            new(PanelContainer.StylePropertyPanel, tooltipBox)
                        ]),

                    new(
                        new SelectorElement(typeof(PanelContainer), [StyleClassTooltipPanel,], null, null),
                        [
                            new(PanelContainer.StylePropertyPanel, tooltipBox)
                        ]),

                    new(
                        new SelectorElement(typeof(PanelContainer), ["speechBox", "sayBox",], null, null),
                        [
                            new(PanelContainer.StylePropertyPanel, tooltipBox)
                        ]),

                    new(
                        new SelectorElement(
                            typeof(PanelContainer),
                            ["speechBox", "whisperBox",],
                            null,
                            null),
                        [
                            new(PanelContainer.StylePropertyPanel, whisperBox)
                        ]),

                    new(
                        new SelectorChild(
                            new SelectorElement(
                                typeof(PanelContainer),
                                ["speechBox", "whisperBox",],
                                null,
                                null),
                            new SelectorElement(typeof(RichTextLabel), ["bubbleContent",], null, null)),
                        [
                            new(
                                "font",
                                typographyManager.GetFont(
                                    FontType.SansSerif,
                                    TextStyle.Footnote,
                                    modifier: FontModifier.Italic))
                        ]),

                    new(
                        new SelectorChild(
                            new SelectorElement(
                                typeof(PanelContainer),
                                ["speechBox", "emoteBox",],
                                null,
                                null),
                            new SelectorElement(typeof(RichTextLabel), null, null, null)),
                        [
                            new(
                                "font",
                                typographyManager.GetFont(
                                    FontType.SansSerif,
                                    TextStyle.Callout,
                                    modifier: FontModifier.Italic))
                        ]),

                    new(
                        new SelectorElement(typeof(RichTextLabel), [StyleClassLabelKeyText,], null, null),
                        [
                            new(
                                Label.StylePropertyFont,
                                typographyManager.GetFont(FontType.SansSerif, weight: FontWeight.SemiBold))
                        ]),

                    // alert tooltip
                    new(
                        new SelectorElement(
                            typeof(RichTextLabel),
                            [StyleClassTooltipAlertTitle,],
                            null,
                            null),
                        [
                            new(
                                "font",
                                typographyManager.GetFont(
                                    FontType.SansSerif,
                                    TextStyle.Title3,
                                    weight: FontWeight.Bold))
                        ]),
                    new(
                        new SelectorElement(
                            typeof(RichTextLabel),
                            [StyleClassTooltipAlertDescription,],
                            null,
                            null),
                        [
                            new("font", typographyManager.GetFont(FontType.SansSerif))
                        ]),
                    new(
                        new SelectorElement(
                            typeof(RichTextLabel),
                            [StyleClassTooltipAlertCooldown,],
                            null,
                            null),
                        [
                            new("font", typographyManager.GetFont(FontType.SansSerif, weight: FontWeight.SemiBold))
                        ]),

                    // action tooltip
                    new(
                        new SelectorElement(
                            typeof(RichTextLabel),
                            [StyleClassTooltipActionTitle,],
                            null,
                            null),
                        [
                            new(
                                "font",
                                typographyManager.GetFont(
                                    FontType.SansSerif,
                                    TextStyle.Title3,
                                    weight: FontWeight.Bold))
                        ]),
                    new(
                        new SelectorElement(
                            typeof(RichTextLabel),
                            [StyleClassTooltipActionDescription,],
                            null,
                            null),
                        [
                            new("font", typographyManager.GetFont(FontType.SansSerif))
                        ]),
                    new(
                        new SelectorElement(
                            typeof(RichTextLabel),
                            [StyleClassTooltipActionCooldown,],
                            null,
                            null),
                        [
                            new("font", typographyManager.GetFont(FontType.SansSerif, weight: FontWeight.SemiBold))
                        ]),
                    new(
                        new SelectorElement(
                            typeof(RichTextLabel),
                            [StyleClassTooltipActionRequirements,],
                            null,
                            null),
                        [
                            new("font", typographyManager.GetFont(FontType.SansSerif, weight: FontWeight.SemiBold))
                        ]),
                    new(
                        new SelectorElement(
                            typeof(RichTextLabel),
                            [StyleClassTooltipActionCharges,],
                            null,
                            null),
                        [
                            new("font", typographyManager.GetFont(FontType.SansSerif, weight: FontWeight.SemiBold))
                        ]),

                    // small number for the entity counter in the entity menu
                    new(
                        new SelectorElement(
                            typeof(Label),
                            [ContextMenuElement.StyleClassEntityMenuIconLabel,],
                            null,
                            null),
                        [
                            new("font", typographyManager.GetFont(FontType.SansSerif, TextStyle.Footnote)),
                            new(Label.StylePropertyAlignMode, Label.AlignMode.Right)
                        ]),

                    // hotbar slot
                    new(
                        new SelectorElement(
                            typeof(RichTextLabel),
                            [StyleClassHotbarSlotNumber,],
                            null,
                            null),
                        [
                            new(
                                "font",
                                typographyManager.GetFont(
                                    FontType.SansSerif,
                                    TextStyle.Title3,
                                    weight: FontWeight.Bold))
                        ]),

                    // Entity tooltip
                    new(
                        new SelectorElement(
                            typeof(PanelContainer),
                            [ExamineSystem.StyleClassEntityTooltip,],
                            null,
                            null),
                        [
                            new(PanelContainer.StylePropertyPanel, tooltipBox)
                        ]),

                    // ItemList
                    new(
                        new SelectorElement(typeof(ItemList), null, null, null),
                        [
                            new(
                                ItemList.StylePropertyBackground,
                                new StyleBoxFlat { BackgroundColor = new(32, 32, 32), }),
                            new(
                                ItemList.StylePropertyItemBackground,
                                itemListItemBackground),
                            new(
                                ItemList.StylePropertyDisabledItemBackground,
                                itemListItemBackgroundDisabled),
                            new(
                                ItemList.StylePropertySelectedItemBackground,
                                itemListBackgroundSelected)
                        ]),

                    new(
                        new SelectorElement(typeof(ItemList), ["transparentItemList",], null, null),
                        [
                            new(
                                ItemList.StylePropertyBackground,
                                new StyleBoxFlat { BackgroundColor = Color.Transparent, }),
                            new(
                                ItemList.StylePropertyItemBackground,
                                itemListItemBackgroundTransparent),
                            new(
                                ItemList.StylePropertyDisabledItemBackground,
                                itemListItemBackgroundDisabled),
                            new(
                                ItemList.StylePropertySelectedItemBackground,
                                itemListBackgroundSelected)
                        ]),

                    new(
                        new SelectorElement(
                            typeof(ItemList),
                            ["transparentBackgroundItemList",],
                            null,
                            null),
                        [
                            new(
                                ItemList.StylePropertyBackground,
                                new StyleBoxFlat { BackgroundColor = Color.Transparent, }),
                            new(
                                ItemList.StylePropertyItemBackground,
                                itemListItemBackground),
                            new(
                                ItemList.StylePropertyDisabledItemBackground,
                                itemListItemBackgroundDisabled),
                            new(
                                ItemList.StylePropertySelectedItemBackground,
                                itemListBackgroundSelected)
                        ]),

                    // Tree
                    new(
                        new SelectorElement(typeof(Tree), null, null, null),
                        [
                            new(
                                Tree.StylePropertyBackground,
                                new StyleBoxFlat { BackgroundColor = new(32, 32, 32), }),
                            new(
                                Tree.StylePropertyItemBoxSelected,
                                new StyleBoxFlat
                                {
                                    BackgroundColor           = new(55, 55, 68),
                                    ContentMarginLeftOverride = 4
                                })
                        ]),

                    // Placeholder
                    new(
                        new SelectorElement(typeof(Placeholder), null, null, null),
                        [
                            new(PanelContainer.StylePropertyPanel, placeholder)
                        ]),

                    new(
                        new SelectorElement(
                            typeof(Label),
                            [Placeholder.StyleClassPlaceholderText,],
                            null,
                            null),
                        [
                            new(Label.StylePropertyFont, typographyManager.GetFont(FontType.SansSerif)),
                            new(Label.StylePropertyFontColor, new Color(103, 103, 103, 128))
                        ]),

                    // Big Label
                    new(
                        new SelectorElement(typeof(Label), [StyleClassLabelHeading,], null, null),
                        [
                            new(
                                Label.StylePropertyFont,
                                typographyManager.GetFont(
                                    FontType.SansSerif,
                                    TextStyle.Title3,
                                    weight: FontWeight.Bold))
                        ]),

                    // Bigger Label
                    new(
                        new SelectorElement(typeof(Label), [StyleClassLabelHeadingBigger,], null, null),
                        [
                            new(
                                Label.StylePropertyFont,
                                typographyManager.GetFont(
                                    FontType.SansSerif,
                                    TextStyle.Title2,
                                    weight: FontWeight.Bold))
                        ]),

                    // Small Label
                    new(
                        new SelectorElement(typeof(Label), [StyleClassLabelSubText,], null, null),
                        [
                            new(
                                Label.StylePropertyFont,
                                typographyManager.GetFont(
                                    FontType.SansSerif,
                                    TextStyle.Callout,
                                    weight: FontWeight.SemiBold)),
                            new(Label.StylePropertyFontColor, Color.DarkGray)
                        ]),

                    // Label Key
                    new(
                        new SelectorElement(typeof(Label), [StyleClassLabelKeyText,], null, null),
                        [
                            new(
                                Label.StylePropertyFont,
                                typographyManager.GetFont(FontType.SansSerif, weight: FontWeight.SemiBold))
                        ]),

                    new(
                        new SelectorElement(typeof(Label), [StyleClassLabelSecondaryColor,], null, null),
                        [
                            new(
                                Label.StylePropertyFont,
                                typographyManager.GetFont(FontType.SansSerif, weight: FontWeight.SemiBold)),
                            new(Label.StylePropertyFontColor, Color.DarkGray)
                        ]),

                    // Console text
                    new(
                        new SelectorElement(typeof(Label), [StyleClassConsoleText,], null, null),
                        [
                            new(Label.StylePropertyFont, typographyManager.GetFont(FontType.Mono))
                        ]),

                    new(
                        new SelectorElement(typeof(Label), [StyleClassConsoleSubHeading,], null, null),
                        [
                            new(
                                Label.StylePropertyFont,
                                typographyManager.GetFont(FontType.Mono, TextStyle.Title3, weight: FontWeight.Bold))
                        ]),

                    new(
                        new SelectorElement(typeof(Label), [StyleClassConsoleHeading,], null, null),
                        [
                            new(
                                Label.StylePropertyFont,
                                typographyManager.GetFont(FontType.Mono, TextStyle.Title2, weight: FontWeight.Bold))
                        ]),

                    // Big Button
                    new(
                        new SelectorChild(
                            new SelectorElement(typeof(Button), [StyleClassButtonBig,], null, null),
                            new SelectorElement(typeof(Label), null, null, null)),
                        [
                            new(
                                "font",
                                typographyManager.GetFont(FontType.Mono, TextStyle.Title3, weight: FontWeight.Bold))
                        ]),

                    //APC and SMES power state label colors
                    new(
                        new SelectorElement(typeof(Label), [StyleClassPowerStateNone,], null, null),
                        [
                            new(Label.StylePropertyFontColor, new Color(0.8f, 0.0f, 0.0f))
                        ]),

                    new(
                        new SelectorElement(typeof(Label), [StyleClassPowerStateLow,], null, null),
                        [
                            new(Label.StylePropertyFontColor, new Color(0.9f, 0.36f, 0.0f))
                        ]),

                    new(
                        new SelectorElement(typeof(Label), [StyleClassPowerStateGood,], null, null),
                        [
                            new(Label.StylePropertyFontColor, new Color(0.024f, 0.8f, 0.0f))
                        ]),

                    // Those top menu buttons.
                    // these use slight variations on the various BaseButton styles so that the content within them appears centered,
                    // which is NOT the case for the default BaseButton styles (OpenLeft/OpenRight adds extra padding on one of the sides
                    // which makes the TopButton icons appear off-center, which we don't want).
                    new(
                        new SelectorElement(typeof(MenuButton), [ButtonSquare,], null, null),
                        [
                            new(ContainerButton.StylePropertyStyleBox, topButtonSquare)
                        ]),

                    new(
                        new SelectorElement(typeof(MenuButton), [ButtonOpenLeft,], null, null),
                        [
                            new(ContainerButton.StylePropertyStyleBox, topButtonOpenLeft)
                        ]),

                    new(
                        new SelectorElement(typeof(MenuButton), [ButtonOpenRight,], null, null),
                        [
                            new(ContainerButton.StylePropertyStyleBox, topButtonOpenRight)
                        ]),

                    new(
                        new SelectorElement(
                            typeof(MenuButton),
                            null,
                            null,
                            [ContainerButton.StylePseudoClassNormal,]),
                        [
                            new(Control.StylePropertyModulateSelf, ButtonColorDefault)
                        ]),

                    new(
                        new SelectorElement(
                            typeof(MenuButton),
                            [MenuButton.StyleClassRedTopButton,],
                            null,
                            [ContainerButton.StylePseudoClassNormal,]),
                        [
                            new(Control.StylePropertyModulateSelf, ButtonColorDefaultRed)
                        ]),

                    new(
                        new SelectorElement(
                            typeof(MenuButton),
                            null,
                            null,
                            [ContainerButton.StylePseudoClassNormal,]),
                        [
                            new(Control.StylePropertyModulateSelf, ButtonColorDefault)
                        ]),

                    new(
                        new SelectorElement(
                            typeof(MenuButton),
                            null,
                            null,
                            [ContainerButton.StylePseudoClassPressed,]),
                        [
                            new(Control.StylePropertyModulateSelf, ButtonColorPressed)
                        ]),

                    new(
                        new SelectorElement(typeof(MenuButton), null, null, [ContainerButton.StylePseudoClassHover,]),
                        [
                            new(Control.StylePropertyModulateSelf, ButtonColorHovered)
                        ]),

                    new(
                        new SelectorElement(
                            typeof(MenuButton),
                            [MenuButton.StyleClassRedTopButton,],
                            null,
                            [ContainerButton.StylePseudoClassHover,]),
                        [
                            new(Control.StylePropertyModulateSelf, ButtonColorHoveredRed)
                        ]),

                    new(
                        new SelectorElement(
                            typeof(Label),
                            [MenuButton.StyleClassLabelTopButton,],
                            null,
                            null),
                        [
                            new(Label.StylePropertyFont, typographyManager.GetFont(FontType.SansSerif))
                        ]),

                    // NanoHeading

                    new(
                        new SelectorChild(
                            SelectorElement.Type(typeof(NanoHeading)),
                            SelectorElement.Type(typeof(PanelContainer))),
                        [
                            new(PanelContainer.StylePropertyPanel, nanoHeadingBox)
                        ]),

                    // StripeBack
                    new(
                        SelectorElement.Type(typeof(StripeBack)),
                        [
                            new(StripeBack.StylePropertyBackground, stripeBack)
                        ]),

                    // StyleClassItemStatus
                    new(
                        SelectorElement.Class(StyleClassItemStatus),
                        [
                            new(
                                "font",
                                typographyManager.GetFont(
                                    FontType.SansSerif,
                                    TextStyle.Footnote,
                                    weight: FontWeight.SemiBold))
                        ]),

                    Element()
                        .Class(StyleClassItemStatusNotHeld)
                        .Prop(
                            "font",
                            typographyManager.GetFont(
                                FontType.SansSerif,
                                TextStyle.Footnote,
                                weight: FontWeight.SemiBold))
                        .Prop("font-color", ItemStatusNotHeldColor),

                    Element<RichTextLabel>()
                        .Class(StyleClassItemStatus)
                        .Prop(nameof(RichTextLabel.LineHeightScale), 0.7f)
                        .Prop(nameof(Control.Margin), new Thickness(0, 0, 0, -6)),

                    // Slider
                    new(
                        SelectorElement.Type(typeof(Slider)),
                        [
                            new(Slider.StylePropertyBackground, sliderBackBox),
                            new(Slider.StylePropertyForeground, sliderForeBox),
                            new(Slider.StylePropertyGrabber, sliderGrabBox),
                            new(Slider.StylePropertyFill, sliderFillBox)
                        ]),

                    new(
                        SelectorElement.Type(typeof(ColorableSlider)),
                        [
                            new(ColorableSlider.StylePropertyFillWhite, sliderFillWhite),
                            new(ColorableSlider.StylePropertyBackgroundWhite, sliderFillWhite)
                        ]),

                    new(
                        new SelectorElement(typeof(Slider), [StyleClassSliderRed,], null, null),
                        [
                            new(Slider.StylePropertyFill, sliderFillRed)
                        ]),

                    new(
                        new SelectorElement(typeof(Slider), [StyleClassSliderGreen,], null, null),
                        [
                            new(Slider.StylePropertyFill, sliderFillGreen)
                        ]),

                    new(
                        new SelectorElement(typeof(Slider), [StyleClassSliderBlue,], null, null),
                        [
                            new(Slider.StylePropertyFill, sliderFillBlue)
                        ]),

                    new(
                        new SelectorElement(typeof(Slider), [StyleClassSliderWhite,], null, null),
                        [
                            new(Slider.StylePropertyFill, sliderFillWhite)
                        ]),

                    // chat channel option selector
                    new(
                        new SelectorElement(
                            typeof(Button),
                            [StyleClassChatChannelSelectorButton,],
                            null,
                            null),
                        [
                            new(ContainerButton.StylePropertyStyleBox, chatChannelButton)
                        ]),
                    // chat filter button
                    new(
                        new SelectorElement(
                            typeof(ContainerButton),
                            [StyleClassChatFilterOptionButton,],
                            null,
                            null),
                        [
                            new(ContainerButton.StylePropertyStyleBox, chatFilterButton)
                        ]),
                    new(
                        new SelectorElement(
                            typeof(ContainerButton),
                            [StyleClassChatFilterOptionButton,],
                            null,
                            [ContainerButton.StylePseudoClassNormal,]),
                        [
                            new(Control.StylePropertyModulateSelf, ButtonColorDefault)
                        ]),
                    new(
                        new SelectorElement(
                            typeof(ContainerButton),
                            [StyleClassChatFilterOptionButton,],
                            null,
                            [ContainerButton.StylePseudoClassHover,]),
                        [
                            new(Control.StylePropertyModulateSelf, ButtonColorHovered)
                        ]),
                    new(
                        new SelectorElement(
                            typeof(ContainerButton),
                            [StyleClassChatFilterOptionButton,],
                            null,
                            [ContainerButton.StylePseudoClassPressed,]),
                        [
                            new(Control.StylePropertyModulateSelf, ButtonColorPressed)
                        ]),
                    new(
                        new SelectorElement(
                            typeof(ContainerButton),
                            [StyleClassChatFilterOptionButton,],
                            null,
                            [ContainerButton.StylePseudoClassDisabled,]),
                        [
                            new(Control.StylePropertyModulateSelf, ButtonColorDisabled)
                        ]),

                    // OptionButton
                    new(
                        new SelectorElement(typeof(OptionButton), null, null, null),
                        [
                            new(ContainerButton.StylePropertyStyleBox, BaseButton)
                        ]),
                    new(
                        new SelectorElement(
                            typeof(OptionButton),
                            null,
                            null,
                            [ContainerButton.StylePseudoClassNormal,]),
                        [
                            new(Control.StylePropertyModulateSelf, ButtonColorDefault)
                        ]),
                    new(
                        new SelectorElement(
                            typeof(OptionButton),
                            null,
                            null,
                            [ContainerButton.StylePseudoClassHover,]),
                        [
                            new(Control.StylePropertyModulateSelf, ButtonColorHovered)
                        ]),
                    new(
                        new SelectorElement(
                            typeof(OptionButton),
                            null,
                            null,
                            [ContainerButton.StylePseudoClassPressed,]),
                        [
                            new(Control.StylePropertyModulateSelf, ButtonColorPressed)
                        ]),
                    new(
                        new SelectorElement(
                            typeof(OptionButton),
                            null,
                            null,
                            [ContainerButton.StylePseudoClassDisabled,]),
                        [
                            new(Control.StylePropertyModulateSelf, ButtonColorDisabled)
                        ]),

                    new(
                        new SelectorElement(
                            typeof(TextureRect),
                            [OptionButton.StyleClassOptionTriangle,],
                            null,
                            null),
                        [
                            new(TextureRect.StylePropertyTexture, textureInvertedTriangle)
                            //new StyleProperty(Control.StylePropertyModulateSelf, Color.FromHex("#FFFFFF")),
                        ]),

                    new(
                        new SelectorElement(
                            typeof(Label),
                            [OptionButton.StyleClassOptionButton,],
                            null,
                            null),
                        [
                            new(Label.StylePropertyAlignMode, Label.AlignMode.Center)
                        ]),

                    new(
                        new SelectorElement(typeof(PanelContainer), [ClassHighDivider,], null, null),
                        [
                            new(
                                PanelContainer.StylePropertyPanel,
                                new StyleBoxFlat
                                {
                                    ContentMarginLeftOverride = 2
                                })
                        ]),

                    Element<TextureButton>()
                        .Class(StyleClassButtonHelp)
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetSymbolsFont(
                                filled: true,
                                style: TextStyle.Title2,
                                weight: FontWeight.SemiBold
                            )),

                    // Labels ---
                    Element<Label>()
                        .Class(StyleClassLabelBig)
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetFont(FontType.SansSerif, TextStyle.Title3, weight: FontWeight.Bold)),

                    Element<Label>()
                        .Class(StyleClassLabelSmall)
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetFont(
                                FontType.SansSerif,
                                TextStyle.Footnote,
                                weight: FontWeight.SemiBold)),
                    // ---

                    // Different Background shapes ---
                    Element<PanelContainer>()
                        .Class("BackgroundOpenRight")
                        .Prop(PanelContainer.StylePropertyPanel, BaseButtonOpenRight)
                        .Prop(Control.StylePropertyModulateSelf, Color.FromHex("#25252A")),

                    Element<PanelContainer>()
                        .Class("BackgroundOpenLeft")
                        .Prop(PanelContainer.StylePropertyPanel, BaseButtonOpenLeft)
                        .Prop(Control.StylePropertyModulateSelf, Color.FromHex("#25252A")),
                    // ---

                    // Dividers
                    Element<PanelContainer>()
                        .Class(ClassLowDivider)
                        .Prop(
                            PanelContainer.StylePropertyPanel,
                            new StyleBoxFlat
                            {
                                BackgroundColor             = Color.FromHex("#444"),
                                ContentMarginLeftOverride   = 2,
                                ContentMarginBottomOverride = 2
                            }),

                    //The lengths you have to go through to change a background color smh
                    Element<PanelContainer>()
                        .Class("PanelBackgroundBaseDark")
                        .Prop("panel", new StyleBoxTexture(BaseButtonOpenBoth) { Padding = default, })
                        .Prop(Control.StylePropertyModulateSelf, Color.FromHex("#1F1F23")),

                    Element<PanelContainer>()
                        .Class("PanelBackgroundLight")
                        .Prop("panel", new StyleBoxTexture(BaseButtonOpenBoth) { Padding = default, })
                        .Prop(Control.StylePropertyModulateSelf, Color.FromHex("#2F2F3B")),

                    // Window Footer
                    Element<TextureRect>()
                        .Class("NTLogoDark")
                        .Prop(
                            TextureRect.StylePropertyTexture,
                            resCache.GetTexture("/Textures/Interface/Nano/ntlogo.svg.png"))
                        .Prop(Control.StylePropertyModulateSelf, Color.FromHex("#757575")),

                    Element<Label>()
                        .Class("WindowFooterText")
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetFont(
                                FontType.SansSerif,
                                TextStyle.Footnote,
                                weight: FontWeight.SemiBold))
                        .Prop(Label.StylePropertyFontColor, Color.FromHex("#757575")),

                    // X Texture button ---
                    Element<TextureButton>()
                        .Class("CrossButtonRed")
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/Interface/Nano/cross.svg.png"))
                        .Prop(Control.StylePropertyModulateSelf, DangerousRedFore),

                    Element<TextureButton>()
                        .Class("CrossButtonRed")
                        .Pseudo(TextureButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, Color.FromHex("#7F3636")),

                    Element<TextureButton>()
                        .Class("CrossButtonRed")
                        .Pseudo(TextureButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, Color.FromHex("#753131")),
                    // ---

                    // Profile Editor
                    Element<Label>()
                        .Class("SpeciesInfoButtonIcon")
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetSymbolsFont(
                                filled: true,
                                style: TextStyle.Title2,
                                weight: FontWeight.SemiBold
                            )),

                    // The default look of paper in UIs. Pages can have components which override this
                    Element<PanelContainer>()
                        .Class("PaperDefaultBorder")
                        .Prop(PanelContainer.StylePropertyPanel, paperBackground),
                    Element<RichTextLabel>()
                        .Class("PaperWrittenText")
                        .Prop(Label.StylePropertyFont, typographyManager.GetFont(FontType.SansSerif))
                        .Prop(Control.StylePropertyModulateSelf, Color.FromHex("#111111")),

                    Element<RichTextLabel>()
                        .Class("LabelSubText")
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetFont(
                                FontType.SansSerif,
                                TextStyle.Footnote,
                                weight: FontWeight.SemiBold))
                        .Prop(Label.StylePropertyFontColor, Color.DarkGray),

                    Element<LineEdit>()
                        .Class("PaperLineEdit")
                        .Prop(LineEdit.StylePropertyStyleBox, new StyleBoxEmpty()),

                    // Red Button ---
                    Element<Button>()
                        .Class("ButtonColorRed")
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDefaultRed),

                    Element<Button>()
                        .Class("ButtonColorRed")
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorDefaultRed),

                    Element<Button>()
                        .Class("ButtonColorRed")
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorHoveredRed),
                    // ---

                    // Green Button ---
                    Element<Button>()
                        .Class("ButtonColorGreen")
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorGoodDefault),

                    Element<Button>()
                        .Class("ButtonColorGreen")
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorGoodDefault),

                    Element<Button>()
                        .Class("ButtonColorGreen")
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorGoodHovered),

                    // Accept button (merge with green button?) ---
                    Element<Button>()
                        .Class("ButtonAccept")
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorGoodDefault),

                    Element<Button>()
                        .Class("ButtonAccept")
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorGoodDefault),

                    Element<Button>()
                        .Class("ButtonAccept")
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorGoodHovered),

                    Element<Button>()
                        .Class("ButtonAccept")
                        .Pseudo(ContainerButton.StylePseudoClassDisabled)
                        .Prop(Control.StylePropertyModulateSelf, ButtonColorGoodDisabled),

                    // ---

                    // Small Button ---
                    Element<Button>()
                        .Class("ButtonSmall")
                        .Prop(ContainerButton.StylePropertyStyleBox, smallButtonBase),

                    Child()
                        .Parent(Element<Button>().Class("ButtonSmall"))
                        .Child(Element<Label>())
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetFont(FontType.SansSerif, TextStyle.Footnote)),
                    // ---

                    Element<Label>()
                        .Class("Good")
                        .Prop("font-color", GoodGreenFore),

                    Element<Label>()
                        .Class("Caution")
                        .Prop("font-color", ConcerningOrangeFore),

                    Element<Label>()
                        .Class("Danger")
                        .Prop("font-color", DangerousRedFore),

                    Element<Label>()
                        .Class("Disabled")
                        .Prop("font-color", DisabledFore),

                    // Radial menu buttons
                    Element<TextureButton>()
                        .Class("RadialMenuButton")
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/Interface/Radial/button_normal.png")),
                    Element<TextureButton>()
                        .Class("RadialMenuButton")
                        .Pseudo(TextureButton.StylePseudoClassHover)
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/Interface/Radial/button_hover.png")),

                    Element<TextureButton>()
                        .Class("RadialMenuCloseButton")
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/Interface/Radial/close_normal.png")),
                    Element<TextureButton>()
                        .Class("RadialMenuCloseButton")
                        .Pseudo(TextureButton.StylePseudoClassHover)
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/Interface/Radial/close_hover.png")),

                    Element<TextureButton>()
                        .Class("RadialMenuBackButton")
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/Interface/Radial/back_normal.png")),
                    Element<TextureButton>()
                        .Class("RadialMenuBackButton")
                        .Pseudo(TextureButton.StylePseudoClassHover)
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/Interface/Radial/back_hover.png")),

                    //PDA - Backgrounds
                    Element<PanelContainer>()
                        .Class("PdaContentBackground")
                        .Prop(PanelContainer.StylePropertyPanel, BaseButtonOpenBoth)
                        .Prop(Control.StylePropertyModulateSelf, Color.FromHex("#25252a")),

                    Element<PanelContainer>()
                        .Class("PdaBackground")
                        .Prop(PanelContainer.StylePropertyPanel, BaseButtonOpenBoth)
                        .Prop(Control.StylePropertyModulateSelf, Color.FromHex("#000000")),

                    Element<PanelContainer>()
                        .Class("PdaBackgroundRect")
                        .Prop(PanelContainer.StylePropertyPanel, BaseAngleRect)
                        .Prop(Control.StylePropertyModulateSelf, Color.FromHex("#717059")),

                    Element<PanelContainer>()
                        .Class("PdaBorderRect")
                        .Prop(PanelContainer.StylePropertyPanel, AngleBorderRect),

                    Element<PanelContainer>()
                        .Class("BackgroundDark")
                        .Prop(PanelContainer.StylePropertyPanel, new StyleBoxFlat(Color.FromHex("#252525"))),

                    //PDA - Buttons
                    Element<PdaSettingsButton>()
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(
                            PdaSettingsButton.StylePropertyBgColor,
                            Color.FromHex(PdaSettingsButton.NormalBgColor))
                        .Prop(
                            PdaSettingsButton.StylePropertyFgColor,
                            Color.FromHex(PdaSettingsButton.EnabledFgColor)),

                    Element<PdaSettingsButton>()
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(PdaSettingsButton.StylePropertyBgColor, Color.FromHex(PdaSettingsButton.HoverColor))
                        .Prop(
                            PdaSettingsButton.StylePropertyFgColor,
                            Color.FromHex(PdaSettingsButton.EnabledFgColor)),

                    Element<PdaSettingsButton>()
                        .Pseudo(ContainerButton.StylePseudoClassPressed)
                        .Prop(PdaSettingsButton.StylePropertyBgColor, Color.FromHex(PdaSettingsButton.PressedColor))
                        .Prop(
                            PdaSettingsButton.StylePropertyFgColor,
                            Color.FromHex(PdaSettingsButton.EnabledFgColor)),

                    Element<PdaSettingsButton>()
                        .Pseudo(ContainerButton.StylePseudoClassDisabled)
                        .Prop(
                            PdaSettingsButton.StylePropertyBgColor,
                            Color.FromHex(PdaSettingsButton.NormalBgColor))
                        .Prop(
                            PdaSettingsButton.StylePropertyFgColor,
                            Color.FromHex(PdaSettingsButton.DisabledFgColor)),

                    Element<PdaProgramItem>()
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(PdaProgramItem.StylePropertyBgColor, Color.FromHex(PdaProgramItem.NormalBgColor)),

                    Element<PdaProgramItem>()
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(PdaProgramItem.StylePropertyBgColor, Color.FromHex(PdaProgramItem.HoverColor)),

                    Element<PdaProgramItem>()
                        .Pseudo(ContainerButton.StylePseudoClassPressed)
                        .Prop(PdaProgramItem.StylePropertyBgColor, Color.FromHex(PdaProgramItem.HoverColor)),

                    //PDA - Text
                    Element<Label>()
                        .Class("PdaContentFooterText")
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetFont(
                                FontType.SansSerif,
                                TextStyle.Footnote,
                                weight: FontWeight.SemiBold))
                        .Prop(Label.StylePropertyFontColor, Color.FromHex("#757575")),

                    Element<Label>()
                        .Class("PdaWindowFooterText")
                        .Prop(
                            Label.StylePropertyFont,
                            typographyManager.GetFont(
                                FontType.SansSerif,
                                TextStyle.Footnote,
                                weight: FontWeight.SemiBold))
                        .Prop(Label.StylePropertyFontColor, Color.FromHex("#333d3b")),

                    // Fancy Tree
                    Element<ContainerButton>()
                        .Identifier(TreeItem.StyleIdentifierTreeButton)
                        .Class(TreeItem.StyleClassEvenRow)
                        .Prop(
                            ContainerButton.StylePropertyStyleBox,
                            new StyleBoxFlat
                            {
                                BackgroundColor = FancyTreeEvenRowColor
                            }),

                    Element<ContainerButton>()
                        .Identifier(TreeItem.StyleIdentifierTreeButton)
                        .Class(TreeItem.StyleClassOddRow)
                        .Prop(
                            ContainerButton.StylePropertyStyleBox,
                            new StyleBoxFlat
                            {
                                BackgroundColor = FancyTreeOddRowColor
                            }),

                    Element<ContainerButton>()
                        .Identifier(TreeItem.StyleIdentifierTreeButton)
                        .Class(TreeItem.StyleClassSelected)
                        .Prop(
                            ContainerButton.StylePropertyStyleBox,
                            new StyleBoxFlat
                            {
                                BackgroundColor = FancyTreeSelectedRowColor
                            }),

                    Element<ContainerButton>()
                        .Identifier(TreeItem.StyleIdentifierTreeButton)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(
                            ContainerButton.StylePropertyStyleBox,
                            new StyleBoxFlat
                            {
                                BackgroundColor = FancyTreeSelectedRowColor
                            }),

                    // DeltaV - AAC button styles
                    Element<ContainerButton>()
                        .Class(CommandButtonClass)
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, CommandButtonColorDefault),

                    Element<ContainerButton>()
                        .Class(CommandButtonClass)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, CommandColorHovered),

                    Element<ContainerButton>()
                        .Class(EngineeringButtonClass)
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, EngineeringButtonColorDefault),

                    Element<ContainerButton>()
                        .Class(EngineeringButtonClass)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, EngineeringColorHovered),

                    Element<ContainerButton>()
                        .Class(EpistemicsButtonClass)
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, EpistemicsButtonColorDefault),

                    Element<ContainerButton>()
                        .Class(EpistemicsButtonClass)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, EpistemicsColorHovered),

                    Element<ContainerButton>()
                        .Class(LogisticsButtonClass)
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, LogisticsButtonColorDefault),

                    Element<ContainerButton>()
                        .Class(LogisticsButtonClass)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, LogisticsColorHovered),

                    Element<ContainerButton>()
                        .Class(MedicalButtonClass)
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, MedicalButtonColorDefault),

                    Element<ContainerButton>()
                        .Class(MedicalButtonClass)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, MedicalColorHovered),

                    Element<ContainerButton>()
                        .Class(SecurityButtonClass)
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, SecurityButtonColorDefault),

                    Element<ContainerButton>()
                        .Class(SecurityButtonClass)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, SecurityColorHovered),

                    Element<ContainerButton>()
                        .Class(ServiceButtonClass)
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, ServiceButtonColorDefault),

                    Element<ContainerButton>()
                        .Class(ServiceButtonClass)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, ServiceColorHovered),

                    Element<ContainerButton>()
                        .Class(JusticeButtonClass)
                        .Pseudo(ContainerButton.StylePseudoClassNormal)
                        .Prop(Control.StylePropertyModulateSelf, JusticeButtonColorDefault),

                    Element<ContainerButton>()
                        .Class(JusticeButtonClass)
                        .Pseudo(ContainerButton.StylePseudoClassHover)
                        .Prop(Control.StylePropertyModulateSelf, JusticeColorHovered),
                    // End DeltaV

                    // Pinned button style
                    new(
                        new SelectorElement(typeof(TextureButton), [StyleClassPinButtonPinned,], null, null),
                        [
                            new(
                                TextureButton.StylePropertyTexture,
                                resCache.GetTexture("/Textures/Interface/Bwoink/pinned.png"))
                        ]),

                    // Unpinned button style
                    new(
                        new SelectorElement(
                            typeof(TextureButton),
                            [StyleClassPinButtonUnpinned,],
                            null,
                            null),
                        [
                            new(
                                TextureButton.StylePropertyTexture,
                                resCache.GetTexture("/Textures/Interface/Bwoink/un_pinned.png"))
                        ]),
                    // Shitmed Change Start
                    Element<TextureButton>()
                        .Class("TargetDollButtonHead")
                        .Pseudo(TextureButton.StylePseudoClassHover)
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/_Shitmed/Interface/Targeting/Doll/head_hover.png")),

                    Element<TextureButton>()
                        .Class("TargetDollButtonChest")
                        .Pseudo(TextureButton.StylePseudoClassHover)
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/_Shitmed/Interface/Targeting/Doll/torso_hover.png")),

                    Element<TextureButton>()
                        .Class("TargetDollButtonGroin")
                        .Pseudo(TextureButton.StylePseudoClassHover)
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/_Shitmed/Interface/Targeting/Doll/groin_hover.png")),

                    Element<TextureButton>()
                        .Class("TargetDollButtonLeftArm")
                        .Pseudo(TextureButton.StylePseudoClassHover)
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/_Shitmed/Interface/Targeting/Doll/leftarm_hover.png")),

                    Element<TextureButton>()
                        .Class("TargetDollButtonLeftHand")
                        .Pseudo(TextureButton.StylePseudoClassHover)
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/_Shitmed/Interface/Targeting/Doll/lefthand_hover.png")),

                    Element<TextureButton>()
                        .Class("TargetDollButtonRightArm")
                        .Pseudo(TextureButton.StylePseudoClassHover)
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/_Shitmed/Interface/Targeting/Doll/rightarm_hover.png")),

                    Element<TextureButton>()
                        .Class("TargetDollButtonRightHand")
                        .Pseudo(TextureButton.StylePseudoClassHover)
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/_Shitmed/Interface/Targeting/Doll/righthand_hover.png")),

                    Element<TextureButton>()
                        .Class("TargetDollButtonLeftLeg")
                        .Pseudo(TextureButton.StylePseudoClassHover)
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/_Shitmed/Interface/Targeting/Doll/leftleg_hover.png")),

                    Element<TextureButton>()
                        .Class("TargetDollButtonLeftFoot")
                        .Pseudo(TextureButton.StylePseudoClassHover)
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/_Shitmed/Interface/Targeting/Doll/leftfoot_hover.png")),

                    Element<TextureButton>()
                        .Class("TargetDollButtonRightLeg")
                        .Pseudo(TextureButton.StylePseudoClassHover)
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/_Shitmed/Interface/Targeting/Doll/rightleg_hover.png")),

                    Element<TextureButton>()
                        .Class("TargetDollButtonRightFoot")
                        .Pseudo(TextureButton.StylePseudoClassHover)
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/_Shitmed/Interface/Targeting/Doll/rightfoot_hover.png")),

                    Element<TextureButton>()
                        .Class("TargetDollButtonEyes")
                        .Pseudo(TextureButton.StylePseudoClassHover)
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/_Shitmed/Interface/Targeting/Doll/eyes_hover.png")),

                    Element<TextureButton>()
                        .Class("TargetDollButtonMouth")
                        .Pseudo(TextureButton.StylePseudoClassHover)
                        .Prop(
                            TextureButton.StylePropertyTexture,
                            resCache.GetTexture("/Textures/_Shitmed/Interface/Targeting/Doll/mouth_hover.png"))
                    // Shitmed Change End
                ])
                .ToList());
    }
}
