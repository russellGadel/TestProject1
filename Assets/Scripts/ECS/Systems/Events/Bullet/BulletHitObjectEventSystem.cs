using ECS.Components;
using ECS.Components.BulletParticleSystemsComponent;
using ECS.Components.MeshRendererComponent;
using ECS.References.MainScene;
using ECS.Tags.Bullet;
using ECS.Tags.Events;
using Leopotam.Ecs;

namespace ECS.Systems.Events.Bullet
{
    // One frame
    public sealed class BulletHitObjectEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BulletTag, BulletHitObjectEventTag, BulletParticleSystemsComponent
            , MeshRendererComponent> _bullets = null;

        public void Run()
        {
            foreach (int idx in _bullets)
            {
                ref EcsEntity bulletEntity = ref _bullets.GetEntity(idx);
                ref BulletParticleSystemsComponent bulletParticles = ref _bullets.Get3(idx);
                ref MeshRendererComponent meshRenderer = ref _bullets.Get4(idx);

                meshRenderer.value.enabled = false;
                bulletParticles.explosion.Play();
                
                DelayDeactivateBullet(bulletEntity);
                
                bulletEntity.Del<BulletHitObjectEventTag>();
            }
        }

        
        private readonly MainSceneData _mainSceneData = null;

        private void DelayDeactivateBullet(in EcsEntity bulletEntity)
        {
            ref DelayDeactivateObjectComponent delayDeactivateObjectComponent =
                ref bulletEntity.Get<DelayDeactivateObjectComponent>();
            
            delayDeactivateObjectComponent.Timer = _mainSceneData.BulletsSettings.BulletLifeTimeAfterHit;
        }
    }
}