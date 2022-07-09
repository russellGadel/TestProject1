using ECS.Tags;
using ECS.Tags.Agent;
using Leopotam.Ecs;

namespace ECS.Systems.Agent
{
    // One Frame
    public sealed class AgentAttackPlayerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AgentTag, AgentAttackPlayerTag, ActiveObjectTag> _agents = null;
        
        public void Run()
        {
            foreach (int idxAgent in _agents)
            {
                ref EcsEntity agentEntity = ref _agents.GetEntity(idxAgent);
                agentEntity.Replace(new AgentShootToPlayerTag());
                agentEntity.Del<AgentAttackPlayerTag>();
            }
        }
    }
}