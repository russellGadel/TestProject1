using ECS.Components.RendererComponent;
using ECS.References.MainScene;
using ECS.Tags.Agent;
using ECS.Tags.Events;
using Leopotam.Ecs;

namespace ECS.Systems.Player
{
    // One frame
    public sealed class SetInitialColorToAgentPlayerNoLongerAimAtSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AgentTag, OnMouseExitEventTag, RendererComponent> _agents = null;
        private readonly MainSceneData _mainSceneData = null;

        public void Run()
        {
            foreach (int idx in _agents)
            {
                ref RendererComponent rendererComponent = ref _agents.Get3(idx);
                rendererComponent.renderer.material.color = _mainSceneData.AgentsSettings.AgentColor;

                ref EcsEntity entity = ref _agents.GetEntity(idx);
                entity.Del<OnMouseExitEventTag>();
            }
        }
    }
}