using System.Collections;
using Core.BootstrapExecutor;
using Services.CursorService;
using Zenject;

namespace CustomEvents
{
    public sealed class StartGameEvent : IBootstrapper
    {
        private readonly OpenLoadingWindowDualEvent _openLoadingWindowDualEvent;
        private readonly StartWindowEvents _startWindowEvents;
        private readonly ICursorService _cursorService;

        [Inject]
        public StartGameEvent(OpenLoadingWindowDualEvent openLoadingWindowDualEvent
            , StartWindowEvents startWindowEvents, ICursorService cursorService)
        {
            _openLoadingWindowDualEvent = openLoadingWindowDualEvent;
            _startWindowEvents = startWindowEvents;
            _cursorService = cursorService;
        }

        IEnumerator IBootstrapper.Execute()
        {
            _openLoadingWindowDualEvent.Undo();
            _startWindowEvents.Execute();
            _cursorService.Unlock();

            yield return null;
        }
    }
}