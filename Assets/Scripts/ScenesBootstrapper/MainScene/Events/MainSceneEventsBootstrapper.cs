using System.Collections;
using Core.BootstrapExecutor;
using Core.EventsLoader;
using CustomEvents;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public sealed class MainSceneEventsBootstrapper : IBootstrapper
    {
        public IEnumerator Execute()
        {
            AddEvents();
            _eventsLoader.Load();

            yield return null;
        }

        [Inject] private readonly ICustomEventsLoader _eventsLoader;
        [Inject] private readonly StartWindowEvents _startWindowEvents;

        private void AddEvents()
        {
            _eventsLoader.Clear();
            _eventsLoader.AddEvent(_startWindowEvents);
        }
    }
}