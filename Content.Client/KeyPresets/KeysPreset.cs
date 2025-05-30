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
