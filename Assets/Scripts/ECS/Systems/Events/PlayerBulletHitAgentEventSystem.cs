using ECS.Components;
using ECS.Components.AgentCurrentDataComponent;
using ECS.References.MainScene;
using ECS.Tags;
using ECS.Tags.Events;
using Leopotam.Ecs;

namespace ECS.Systems.Events
{
    // OneFrame
    public sealed class PlayerBulletHitAgentEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerBulletHitAgentEventTag, AgentCurrentDataComponent> _agents = null;
        private readonly MainSceneData _mainSceneData = null;


        public void Run()
        {
            foreach (int idx in _agents)
            {
                ref EcsEntity entity = ref _agents.GetEntity(idx);
                ref AgentCurrentDataComponent currentData = ref _agents.Get2(idx);

                currentData.CurrentHitsNumberByPlayer += 1;

                if (currentData.CurrentHitsNumberByPlayer >=
                    _mainSceneData.AgentsSettings.NumberOfHitsByPlayerToDeactivate)
                {
                    DeactivateAgent(entity);
                }

                entity.Del<PlayerBulletHitAgentEventTag>();
            }
        }

        private readonly EcsFilter<GameTag, CurrentGameSessionDataComponent> _currentGameSession = null;

        private void DeactivateAgent(in EcsEntity agentEntity)
        {
            foreach (int idx in _currentGameSession)
            {
                ref CurrentGameSessionDataComponent gameData = ref _currentGameSession.Get2(idx);
                gameData.DeactivatedAgentsAmount += 1;
            }
            
            agentEntity.Replace(new DeactivateObjectEventTag());
        }
    }
}