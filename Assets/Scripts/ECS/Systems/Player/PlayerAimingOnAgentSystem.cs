using ECS.Components.RendererComponent;
using ECS.References.MainScene;
using ECS.Tags.Agent;
using ECS.Tags.Events;
using Leopotam.Ecs;

namespace ECS.Systems.Player
{
    // One frame
    public sealed class PlayerAimingOnAgentSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AgentTag, OnMouseEnterEventTag, RendererComponent> _agents = null;
        private readonly MainSceneData _mainSceneData = null;

        public void Run()
        {
            foreach (int idx in _agents)
            {
                ref RendererComponent rendererComponent = ref _agents.Get3(idx);
                
                rendererComponent.renderer.material.color = _mainSceneData.AgentsSettings.ColorWhenPlayerAims;

                ref EcsEntity entity = ref _agents.GetEntity(idx);
                entity.Del<OnMouseEnterEventTag>();
            }
        }
    }
}