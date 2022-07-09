using ECS.References.MainScene;
using ECS.Tags.Events.LoadingWindow;
using Leopotam.Ecs;

namespace ECS.Systems.Events.LoadingWindow
{
    // One Frame
    public sealed class CloseLoadingWindowSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CloseLoadingWindowTag> _events = null;
        private readonly MainSceneServices _services = null;

        public void Run()
        {
            foreach (var idx in _events)
            {
                _services.MainSceneEventsService.OpenLoadingWindowDualEvent.Undo();
                _services.MainSceneEventsService.OpenMenuCanvasDualEvent.Undo();

                ref EcsEntity entity = ref _events.GetEntity(idx);
                entity.Del<CloseLoadingWindowTag>();
            }
        }
    }
}