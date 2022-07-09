using ECS.Components.NavMeshAgentComponent;
using ECS.Components.RigidbodyComponent;
using ECS.Tags.Agent;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Init
{
    public sealed class InitAgentSystem : IEcsInitSystem
    {
        private readonly EcsFilter<AgentTag, NavMeshAgentComponent, RigidbodyComponent> _agents = null;
        
        public void Init()
        {
            foreach (int agentIdx in _agents)
            {
                ref RigidbodyComponent rigidbody = ref _agents.Get3(agentIdx);
                rigidbody.value.transform.rotation = Quaternion.Euler(0,0,0);
                
                ref NavMeshAgentComponent navMesh = ref _agents.Get2(agentIdx);
                navMesh.value.updateRotation = false;
            }
        }
    }
}