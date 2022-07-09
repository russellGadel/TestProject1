namespace CustomUI.GameOverWindow
{
    public sealed class GameOverWindowPresenter : IGameOverWindowPresenter
    {
        private readonly IGameOverWindowView _view;
        private readonly GameOverWindowSettings _settings;

        public GameOverWindowPresenter(in GameOverWindowSettings settings
            , in IGameOverWindowView view)
        {
            _settings = settings;
            _view = view;
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