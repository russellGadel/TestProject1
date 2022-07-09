using CustomEvents;
using Zenject;

namespace ScenesBootstrapper.LoadingScene
{
    public sealed class LoadingSceneEventsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLoadingWindowEvents();
        }
        
        private void BindLoadingWindowEvents()
        {
            Container
                .Bind<OpenLoadingWindowDualEvent>()
                .AsSingle();
        }
    }
}