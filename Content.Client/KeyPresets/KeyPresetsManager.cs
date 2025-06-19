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

using System.Linq;
using Content.Shared.CCVar;
using Robust.Client.Input;
using Robust.Shared.Configuration;
using Robust.Shared.Reflection;
using Robust.Shared.Sandboxing;


namespace Content.Client.KeyPresets;


public sealed class KeyPresetsManager
{
    [Dependency] private readonly IConfigurationManager _configurationManager = null!;
    [Dependency] private readonly IInputManager _inputManager = null!;
    [Dependency] private readonly IReflectionManager _reflectionManager = null!;
    [Dependency] private readonly ISandboxHelper _sandboxHelper = null!;

    private List<KeysPreset> _keyPresets = [];

    public void Initialize()
    {
        foreach (var preset in _reflectionManager.GetAllChildren<KeysPreset>())
        {
            if (preset.IsAbstract)
                continue;

            _keyPresets.Add((_sandboxHelper.CreateInstance(preset) as KeysPreset)!);
        }

        _keyPresets = _keyPresets.OrderBy(p => p.Name).ToList();
    }

    public IReadOnlyList<KeysPreset> GetKeyPresets() => _keyPresets;

    public void ApplyPreset(KeysPreset preset)
    {
        _configurationManager.SetCVar(CCVars.ControlKeysPreset, preset.Name);
        preset.Apply(_inputManager);
        _configurationManager.SaveToFile();
        _inputManager.SaveToUserData();
    }
}
