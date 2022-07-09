using ECS.References.MainScene;
using ECS.Tags.Events.LoadingWindow;
using Leopotam.Ecs;

namespace ECS.Systems.Events.LoadingWindow
{
    public sealed class OpenLoadingWindowSystem : IEcsRunSystem
    {
        private readonly EcsFilter<OpenLoadingWindowTag> _events = null;
        private readonly MainSceneServices _services = null;

        public void Run()
        {
            foreach (var idx in _events)
            {
                _services.MainSceneEventsService.OpenLoadingWindowDualEvent.Execute();
                _services.MainSceneEventsService.OpenMenuCanvasDualEvent.Execute();
                
                ref EcsEntity entity = ref _events.GetEntity(idx);
                entity.Del<OpenLoadingWindowTag>();
            }
        }
    }
}