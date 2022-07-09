using ECS.Components;
using ECS.References.MainScene;
using ECS.Tags;
using ECS.Tags.Events;
using Leopotam.Ecs;

namespace ECS.Systems.Events
{
    // One Frame
    public sealed class WinEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<WinEventTag> _event = null;
        private readonly MainSceneServices _mainSceneServices = null;
        private readonly MainSceneData _mainSceneData = null;

        public void Run()
        {
            foreach (int idx in _event)
            {
                ref EcsEntity entity = ref _event.GetEntity(idx);
                entity.Del<WinEventTag>();


                if (IsExecutedVictoryCondition())
                {
                    entity.Replace(new StopGamePlayEventTag());
                    _mainSceneServices.MainSceneEventsService.WinEvent.Execute();
                }
            }
        }

        private bool IsExecutedVictoryCondition()
        {
            return GetCurrentDeactivatedAgentsAmount() >=
                   _mainSceneData.GamePlaySettings.playerMustDeactivateAgentsAmountForWin;
        }


        private readonly EcsFilter<GameTag, CurrentGameSessionDataComponent> _currentGameSession = null;

        private int GetCurrentDeactivatedAgentsAmount()
        {
            foreach (int idx in _currentGameSession)
            {
                ref CurrentGameSessionDataComponent gameData = ref _currentGameSession.Get2(idx);
                return gameData.DeactivatedAgentsAmount;
            }

            return 0;
        }
    }
}