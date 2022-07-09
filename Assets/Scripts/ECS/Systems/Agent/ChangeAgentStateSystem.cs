using ECS.Components;
using ECS.References.MainScene;
using ECS.Tags.Agent;
using Leopotam.Ecs;

namespace ECS.Systems.Agent
{
    public sealed class ChangeAgentStateSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AgentTag>.Exclude<BlockChangeAgentStateComponent> _agents = null;
        private readonly MainSceneData _mainSceneData = null;

        public void Run()
        {
            foreach (int idx in _agents)
            {
                ref EcsEntity entity = ref _agents.GetEntity(idx);

                if (entity.Has<AgentPatrolTag>())
                {
                    entity.Del<AgentPatrolTag>();
                    entity.Replace(new AgentStandStillTag());
                }
                else
                {
                    entity.Replace(new AgentPatrolTag());
                }

                entity.Replace(new BlockChangeAgentStateComponent()
                {
                    Timer = _mainSceneData.AgentsSettings.GetRandomDelayChangeState()
                });
            }
        }
    }
}