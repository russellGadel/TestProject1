using ECS.References.MainScene;
using ECS.Tags.Events;
using Leopotam.Ecs;

namespace ECS.Systems.Events
{
    public sealed class GameOverEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GameOverEventTag> _gameOverEvent = null;

        private readonly MainSceneServices _mainSceneServices = null;
        
        public void Run()
        {
            foreach (int idx in _gameOverEvent)
            {
                ref EcsEntity gameOverEvent = ref _gameOverEvent.GetEntity(idx);
                gameOverEvent.Del<GameOverEventTag>();
                
                gameOverEvent.Replace(new StopGamePlayEventTag());
                _mainSceneServices.MainSceneEventsService.GameOverEvent.Execute();
            }
        }
    }
}