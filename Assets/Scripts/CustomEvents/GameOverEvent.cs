using Core.CustomInvoker;
using Core.EventsLoader;
using CustomUI.GameOverWindow;
using Services.CursorService;
using Zenject;

namespace CustomEvents
{
    public class GameOverEvent : ICustomEvent
    {
        private readonly OpenMenuCanvasDualEvent _openMenuCanvasDualEvent;
        private readonly StartWindowEvents _startWindowEvents;
        private readonly ICursorService _cursorService;
        private readonly IGameOverWindowPresenter _gameOverWindow;
        private readonly ICustomInvokerService _customInvokerService;

        [Inject]
        public GameOverEvent(OpenMenuCanvasDualEvent openMenuCanvasDualEvent
            , StartWindowEvents startWindowEvents
            , ICursorService cursorService
            , IGameOverWindowPresenter gameOverWindow
            , ICustomInvokerService customInvokerService)
        {
            _openMenuCanvasDualEvent = openMenuCanvasDualEvent;
            _startWindowEvents = startWindowEvents;
            _cursorService = cursorService;
            _gameOverWindow = gameOverWindow;
            _customInvokerService = customInvokerService;
        }

        public void Execute()
        {
            _gameOverWindow.OpenView();
            _openMenuCanvasDualEvent.Execute();

            _customInvokerService.CustomInvoke(DelayCloseGameOverWindow, _gameOverWindow.GetWindowDisplayTime());
        }

        private void DelayCloseGameOverWindow()
        {
            _gameOverWindow.CloseView();

            _startWindowEvents.Execute();
            _cursorService.Unlock();
        }
    }
}