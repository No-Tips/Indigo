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
using Robust.Client.Input;
using Robust.Shared.Input;


namespace Content.Client.KeyPresets;


public abstract class KeysPreset
{
    public abstract string Name { get; }

    protected abstract Dictionary<BoundKeyFunction, List<KeyBindingRegistration>> Registrations { get; set; }

    [Access(typeof(KeyPresetsManager), Friend = AccessPermissions.ReadWriteExecute, Other = AccessPermissions.None)]
    public virtual void Apply(IInputManager inputManager)
    {
        foreach (var (function, newBindings) in Registrations)
        {
            var oldBindings = inputManager.GetKeyBindings(function).ToList();

            foreach (var oldBinding in oldBindings)
                inputManager.RemoveBinding(oldBinding);

            foreach (var newBinding in newBindings)
            {
                newBinding.Function = function;
                inputManager.RegisterBinding(newBinding);
            }
        }
    }
}
