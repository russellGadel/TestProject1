using CustomEvents;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public sealed class MainSceneEventsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLoadingWindowEvents();
            BindMainSceneEventsService();
            BindOpenCanvasDualEvent();
            BindStartGameEvent();
            BindStartWindowEvents();
            BindGameOverEvent();
            BindWinEvent();
        }

        private void BindLoadingWindowEvents()
        {
            Container.Bind<OpenLoadingWindowDualEvent>().AsSingle();
        }

        private void BindMainSceneEventsService()
        {
            Container.Bind<MainSceneEventsService>().AsSingle();
        }

        private void BindOpenCanvasDualEvent()
        {
            Container.Bind<OpenMenuCanvasDualEvent>().AsSingle();
        }

        private void BindStartGameEvent()
        {
            Container.Bind<StartGameEvent>().AsSingle();
        }

        private void BindStartWindowEvents()
        {
            Container.Bind<StartWindowEvents>().AsSingle();
        }

        private void BindGameOverEvent()
        {
            Container.Bind<GameOverEvent>().AsSingle();
        }

        private void BindWinEvent()
        {
            Container.Bind<WinEvent>().AsSingle();
        }
    }
}