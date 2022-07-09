using ECS.Components.MeshRendererComponent;
using ECS.Tags;
using ECS.Tags.Bullet;
using Leopotam.Ecs;

namespace ECS.Systems.Events.Bullet
{
    // One Frame
    public sealed class RunInitBulletSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BulletTag, RunInitTag, MeshRendererComponent> _bullets = null;

        public void Run()
        {
            foreach (int idx in _bullets)
            {
                ref MeshRendererComponent meshRenderer = ref _bullets.Get3(idx);
                meshRenderer.value.enabled = true;

                ref EcsEntity entity = ref _bullets.GetEntity(idx);
                entity.Del<RunInitTag>();
            }
        }
    }
}