namespace CustomUI.GameOverWindow
{
    public interface IGameOverWindowPresenter
    {
        void OpenView();
        void CloseView();
        float GetWindowDisplayTime();
    }
}