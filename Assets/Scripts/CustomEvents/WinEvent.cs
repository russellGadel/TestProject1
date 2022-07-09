using Core.CustomInvoker;
using Core.EventsLoader;
using CustomUI.WinWindow;
using Services.CursorService;
using Zenject;

namespace CustomEvents
{
    public class WinEvent : ICustomEvent
    {
        private readonly OpenMenuCanvasDualEvent _openMenuCanvasDualEvent;
        private readonly StartWindowEvents _startWindowEvents;
        private readonly ICursorService _cursorService;
        private readonly IWinWindowPresenter _winWindow;
        private readonly ICustomInvokerService _customInvokerService;

        [Inject]
        public WinEvent(OpenMenuCanvasDualEvent openMenuCanvasDualEvent
            , StartWindowEvents startWindowEvents
            , ICursorService cursorService
            , IWinWindowPresenter winWindow
            , ICustomInvokerService customInvokerService)
        {
            _openMenuCanvasDualEvent = openMenuCanvasDualEvent;
            _startWindowEvents = startWindowEvents;
            _cursorService = cursorService;
            _winWindow = winWindow;
            _customInvokerService = customInvokerService;
        }

        public void Execute()
        {
            _winWindow.OpenView();
            _openMenuCanvasDualEvent.Execute();

            _customInvokerService.CustomInvoke(DelayCloseWinWindow, _winWindow.GetWindowDisplayTime());
        }

        private void DelayCloseWinWindow()
        {
            _winWindow.CloseView();

            _startWindowEvents.Execute();
            _cursorService.Unlock();
        }
    }
}