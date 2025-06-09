// Copyright (C) 2025 Igor Spichkin

// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.

// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

namespace Content.Shared.InterfaceGuidelines;


public static class Colors
{
    public static readonly Color Black = Color.FromHex("#191919");

    public static readonly Color BlueLight = Color.FromHex("#627CFF");
    public static readonly Color Blue      = Color.FromHex("#3B5CFF");
    public static readonly Color BlueDark  = Color.FromHex("#243BAA");

    public static readonly Color Gray   = Color.FromHex("#353535");
    public static readonly Color Indigo = Color.FromHex("#9900FF");
    public static readonly Color Red    = Color.FromHex("#E40E0E");

    public static Color AccentLight => BlueLight;
    public static Color Accent      => Blue;
    public static Color AccentDark  => BlueDark;

    #region Window

    public static          Color WindowBackground => Black;
    public static readonly Color WindowBorder      = new(0, 0, 0);
    public static readonly Color WindowInsetBorder = new(48, 48, 48);

    public static readonly Color WindowTitle = Color.FromHex("#AAAAAA");
    public static          Color WindowTitlebarBackground => Gray;
    public static          Color WindowTitlebarBorder     => WindowBorder;
    public static readonly Color WindowTitlebarInsetBorder = new(73, 73, 73);

    public static readonly Color WindowTitlebarCloseButton = Color.FromHex("#ff6565");
    public static readonly Color WindowTitlebarHelpButton  = Color.FromHex("#eebe00");

    #endregion

    #region Button

    public static          Color ButtonLabel => Color.White;
    public static readonly Color ButtonSelectedItemDisabledLabel = Color.FromHex("#969696");

    #region Default

    public static readonly Color ButtonBackground         = Color.FromHex("#646464");
    public static readonly Color ButtonPressedBackground  = Color.FromHex("#828282");
    public static readonly Color ButtonDisabledBackground = Color.FromHex("#323232");

    #endregion

    #region Accent

    public static Color ButtonAccentBackground         => Accent;
    public static Color ButtonAccentPressedBackground  => AccentLight;
    public static Color ButtonAccentDisabledBackground => AccentDark;

    #endregion

    #endregion

    #region Button Option

    public static Color OptionButtonSelectedItemLabel         => Color.White;
    public static Color OptionButtonSelectedItemDisabledLabel => ButtonSelectedItemDisabledLabel;

    #endregion

    #region Label

    public static readonly Color Label         = Color.FromHex("#E1E1E1");
    public static readonly Color LabelTitle1   = Color.White;
    public static readonly Color LabelTitle2   = Color.White;
    public static readonly Color LabelTitle3   = Color.White;
    public static readonly Color LabelHeadline = Color.White;

    #endregion

    #region Line Edit

    public static readonly Color LineEditBackground  = Color.FromHex("#252525");
    public static readonly Color LineEditBorder      = Color.FromHex("#303030");
    public static readonly Color LineEditInsetBorder = Color.FromHex("#444444");
    public static readonly Color LineEditPlaceholder = Color.FromHex("#646464");
    public static          Color LineEditCursor    => Accent;
    public static          Color LineEditSelection => Accent.WithAlpha(0.25f);

    #endregion

    #region Check Box

    public static readonly Color CheckBoxBackground = Color.FromHex("#3A3A3A");
    public static          Color CheckBoxCheckedBackground => Accent;

    #endregion

    #region Popup

    public static Color PopupBackground  => WindowBackground;
    public static Color PopupBorder      => WindowBorder;
    public static Color PopupInsetBorder => WindowInsetBorder;

    #endregion

    #region Chat

    public static Color ChatBorder      => WindowBorder;
    public static Color ChatInsetBorder => WindowInsetBorder;
    public static Color ChatBackground  => Black;

    #endregion
}
