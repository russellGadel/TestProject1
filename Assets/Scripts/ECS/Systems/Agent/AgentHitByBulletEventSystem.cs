using ECS.Tags.Agent;
using ECS.Tags.Events;
using Leopotam.Ecs;

namespace ECS.Systems.Agent
{
    // One frame
    public sealed class AgentHitByBulletEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AgentTag, BulletHitObjectEventTag> _agents = null;

        public void Run()
        {
            foreach (int idx in _agents)
            {
                ref EcsEntity entity = ref _agents.GetEntity(idx);
                entity.Del<BulletHitObjectEventTag>();

                entity.Replace(new DeactivateObjectEventTag());
                entity.Replace(new OnMouseExitEventTag());
            }
        }
    }
}