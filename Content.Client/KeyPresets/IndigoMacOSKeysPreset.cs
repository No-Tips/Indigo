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

using Content.Shared.Input;
using Robust.Client.Input;
using Robust.Shared.Input;


namespace Content.Client.KeyPresets;


public sealed class IndigoMacOSKeysPreset : KeysPreset
{
    public override string Name => "Indigo MacOS";

    protected override Dictionary<BoundKeyFunction, List<KeyBindingRegistration>> Registrations { get; set; } = new()
    {
        #region Global

        {
            ContentKeyFunctions.OpenAdminMenu, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.A,
                    Mod1    = Keyboard.Key.LSystem,
                    Mod2    = Keyboard.Key.Control,
                    Type    = KeyBindingType.State
                }
            }
        },
        {
            ContentKeyFunctions.OpenContextMenu, new()
            {
                new()
                {
                    BaseKey  = Keyboard.Key.MouseRight,
                    Priority = -10
                },
                new()
                {
                    BaseKey = Keyboard.Key.MouseLeft,
                    Mod1    = Keyboard.Key.Control
                }
            }
        },
        {
            ContentKeyFunctions.OpenDecalSpawnWindow, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.P,
                    Mod1    = Keyboard.Key.LSystem,
                    Mod2    = Keyboard.Key.Control,
                    Type    = KeyBindingType.State
                }
            }
        },
        {
            ContentKeyFunctions.OpenEntitySpawnWindow, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.E,
                    Mod1    = Keyboard.Key.LSystem,
                    Mod2    = Keyboard.Key.Control,
                    Type    = KeyBindingType.State
                }
            }
        },
        {
            ContentKeyFunctions.OpenOptionsWindow, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.Comma,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },
        {
            ContentKeyFunctions.OpenSandboxWindow, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.S,
                    Mod1    = Keyboard.Key.LSystem,
                    Mod2    = Keyboard.Key.Control,
                    Type    = KeyBindingType.State
                }
            }
        },
        {
            ContentKeyFunctions.OpenTileSpawnWindow, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.T,
                    Mod1    = Keyboard.Key.LSystem,
                    Mod2    = Keyboard.Key.Control,
                    Type    = KeyBindingType.State
                }
            }
        },
        {
            ContentKeyFunctions.TakeScreenshot, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.F12,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },
        {
            ContentKeyFunctions.TakeScreenshotNoUI, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.F12,
                    Mod1    = Keyboard.Key.LSystem,
                    Mod2    = Keyboard.Key.Alt
                }
            }
        },
        {
            ContentKeyFunctions.ToggleFullscreen, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.Return,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },

        #endregion

        #region Camera

        {
            EngineKeyFunctions.CameraRotateLeft, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.NumpadNum7
                },
                new()
                {
                    BaseKey = Keyboard.Key.RBracket
                }
            }
        },
        {
            EngineKeyFunctions.CameraRotateRight, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.NumpadNum9
                },
                new()
                {
                    BaseKey = Keyboard.Key.LBracket
                }
            }
        },
        {
            ContentKeyFunctions.ZoomIn, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.NumpadNum6
                },
                new()
                {
                    BaseKey = Keyboard.Key.Equal
                }
            }
        },
        {
            ContentKeyFunctions.ZoomOut, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.NumpadNum4
                },
                new()
                {
                    BaseKey = Keyboard.Key.Minus
                }
            }
        },
        {
            ContentKeyFunctions.ResetZoom, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.NumpadNum5
                },
                new()
                {
                    BaseKey = Keyboard.Key.Num0,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },

        #endregion

        #region Character

        {
            ContentKeyFunctions.ActivateItemInWorld, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.MouseLeft,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },
        {
            ContentKeyFunctions.AltActivateItemInWorld, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.MouseLeft,
                    Mod1    = Keyboard.Key.LSystem,
                    Mod2    = Keyboard.Key.Alt
                }
            }
        },
        {
            ContentKeyFunctions.UseItemInHand, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.F
                }
            }
        },
        {
            ContentKeyFunctions.AltUseItemInHand, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.F,
                    Mod1    = Keyboard.Key.Alt
                }
            }
        },
        {
            ContentKeyFunctions.MovePulledObject, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.MouseRight,
                    Mod1    = Keyboard.Key.Alt
                }
            }
        },
        {
            ContentKeyFunctions.OfferItem, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.Q,
                    Mod1    = Keyboard.Key.Alt,
                    Mod2    = Keyboard.Key.Shift
                }
            }
        },
        {
            ContentKeyFunctions.OpenGuidebook, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.F1,
                    Mod1    = Keyboard.Key.Alt
                }
            }
        },
        {
            ContentKeyFunctions.ReleasePulledObject, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.Q,
                    Mod1    = Keyboard.Key.Alt
                }
            }
        },
        {
            ContentKeyFunctions.ThrowItemInHand, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.MouseRight,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },
        {
            ContentKeyFunctions.ToggleStanding, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.R,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },
        {
            ContentKeyFunctions.TryPullObject, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.MouseLeft,
                    Mod1    = Keyboard.Key.Alt
                }
            }
        },

        #endregion

        #region Inventory

        {
            ContentKeyFunctions.OpenBackpack, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.B,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },
        {
            ContentKeyFunctions.OpenBelt, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.B,
                    Mod1    = Keyboard.Key.LSystem,
                    Mod2    = Keyboard.Key.Alt
                }
            }
        },
        {
            ContentKeyFunctions.SmartEquipBackpack, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.E,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },
        {
            ContentKeyFunctions.SmartEquipBelt, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.E,
                    Mod1    = Keyboard.Key.LSystem,
                    Mod2    = Keyboard.Key.Alt
                }
            }
        },

        #endregion

        #region Chat

        {
            ContentKeyFunctions.CycleChatChannelBackward, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.Tab,
                    Mod1    = Keyboard.Key.Shift
                }
            }
        },
        {
            ContentKeyFunctions.CycleChatChannelForward, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.Tab
                }
            }
        },
        {
            ContentKeyFunctions.FocusAdminChat, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.Num5,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },
        {
            ContentKeyFunctions.FocusDeadChat, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.Num4,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },
        {
            ContentKeyFunctions.FocusEmote, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.Num2,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },
        {
            ContentKeyFunctions.FocusLOOC, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.Num3,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },
        {
            ContentKeyFunctions.FocusOOC, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.Num3,
                    Mod1    = Keyboard.Key.Alt
                }
            }
        },
        {
            ContentKeyFunctions.FocusRadio, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.Num1,
                    Mod1    = Keyboard.Key.Alt
                }
            }
        },
        {
            ContentKeyFunctions.FocusWhisperChat, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.Num1,
                    Mod1    = Keyboard.Key.Alt,
                    Mod2    = Keyboard.Key.Shift
                }
            }
        },

        #endregion

        #region Ghost

        {
            ContentKeyFunctions.GhostBar, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.B,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },
        {
            ContentKeyFunctions.GhostReturnToBody, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.R,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },
        {
            ContentKeyFunctions.GhostReturnToRound, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.R,
                    Mod1    = Keyboard.Key.LSystem,
                    Mod2    = Keyboard.Key.Alt
                }
            }
        },
        {
            ContentKeyFunctions.GhostRoles, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.L,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },
        {
            ContentKeyFunctions.GhostWarp, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.W,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },

        #endregion

        #region Map Editor

        {
            ContentKeyFunctions.InspectEntity, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.MouseLeft,
                    Mod1    = Keyboard.Key.LSystem,
                    Mod2    = Keyboard.Key.Control
                }
            }
        },

        #endregion

        #region Developer

        {
            EngineKeyFunctions.ShowDebugMonitors, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.M,
                    Mod1    = Keyboard.Key.LSystem,
                    Mod2    = Keyboard.Key.Control,
                    Type    = KeyBindingType.Toggle
                }
            }
        },
        {
            EngineKeyFunctions.HideUI, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.U,
                    Mod1    = Keyboard.Key.LSystem,
                    Mod2    = Keyboard.Key.Control,
                    Type    = KeyBindingType.Toggle
                }
            }
        },

        #endregion

        #region System

        {
            EngineKeyFunctions.TextCopy, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.C,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },
        {
            EngineKeyFunctions.TextPaste, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.V,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },
        {
            EngineKeyFunctions.TextCut, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.X,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        },
        {
            EngineKeyFunctions.TextSelectAll, new()
            {
                new()
                {
                    BaseKey = Keyboard.Key.A,
                    Mod1    = Keyboard.Key.LSystem
                }
            }
        }

        #endregion
    };
}
