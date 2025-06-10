using Content.Client.UserInterface.Controls;

namespace Content.Client.Administration.UI.CustomControls
{
    public sealed class UICommandButton : CommandButton
    {
        public  Type?        WindowType { get; set; }
        private FancyWindow? _window;

        protected override void Execute(ButtonEventArgs obj)
        {
            if (WindowType == null)
                return;
            _window = (FancyWindow) IoCManager.Resolve<IDynamicTypeFactory>().CreateInstance(WindowType);
            _window?.OpenCentered();
        }
    }
}
