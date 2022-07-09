namespace CustomUI.WinWindow
{
    public sealed class WinWindowPresenter : IWinWindowPresenter
    {
        private readonly IWinWindowView _view;
        private readonly WinWindowSettings _settings;

        public WinWindowPresenter(IWinWindowView view
            , WinWindowSettings settings)
        {
            _view = view;
            _settings = settings;
        }

        public void OpenView()
        {
            _view.Open();
        }

        public void CloseView()
        {
            _view.Close();
        }

        public float GetWindowDisplayTime()
        {
            return _settings.WindowDisplayTime;
        }
    }
}