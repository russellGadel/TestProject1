using ECS.Components.NavMeshAgentComponent;
using ECS.Components.TransformComponent;
using ECS.Tags;
using ECS.Tags.Agent;
using Leopotam.Ecs;

namespace ECS.Systems.Agent
{
    // One Frame
    public sealed class AgentStandStillSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AgentTag, NavMeshAgentComponent, TransformComponent
            , AgentStandStillTag, ActiveObjectTag> _agents = null;

        public void Run()
        {
            foreach (int agentIdx in _agents)
            {
                ref NavMeshAgentComponent navMesh = ref _agents.Get2(agentIdx);
                ref TransformComponent transform = ref _agents.Get3(agentIdx);
                navMesh.value.destination = transform.value.position;

                ref EcsEntity agentEntity = ref _agents.GetEntity(agentIdx);
                agentEntity.Del<AgentStandStillTag>();
            }
        }
    }
}