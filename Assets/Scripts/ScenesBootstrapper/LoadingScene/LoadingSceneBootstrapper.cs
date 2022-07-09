using Core.EventsLoader;
using CustomEvents;
using ScenesLoader;
using Services.CursorService;
using Zenject;

namespace ScenesBootstrapper.LoadingScene
{
    public sealed class LoadingSceneBootstrapper : ISceneBootstrapper
    {
        [Inject] private readonly OpenLoadingWindowDualEvent _openLoadingWindowDualEvent;
        [Inject] private readonly ICursorService _cursorService;
        [Inject] private readonly ICustomEventsLoader _loader;
        [Inject] private readonly ICustomScenesLoader _scenesLoader;

        public void Enter()
        {
            _cursorService.Lock();
            _openLoadingWindowDualEvent.Execute();
            
            AddEnterItems();
            _loader.Load();
        }

        public void Exit()
        {
            _openLoadingWindowDualEvent.Undo();
        }


        private void AddEnterItems()
        {
            _loader.Clear();
            _loader.AddEvent(new LoadMainSceneEvent(_scenesLoader, this));
        }
    }
}