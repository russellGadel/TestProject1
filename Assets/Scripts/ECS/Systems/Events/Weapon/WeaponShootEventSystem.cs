using ECS.Components;
using ECS.Components.BlockWeaponReloadDuration;
using ECS.Components.BlockWeaponShootDuration;
using ECS.Components.MovementSpeed;
using ECS.Components.MoveTo;
using ECS.Components.ObjectsFactory;
using ECS.Components.TransformComponent;
using ECS.Components.Weapon;
using ECS.Tags;
using ECS.Tags.Bullet;
using ECS.Tags.BulletsServiceTag;
using ECS.Tags.Events;
using ECS.Tags.Events.Weapon;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Events.Weapon
{
    // One frame
    public sealed class WeaponShootEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<WeaponShootEventTag, WeaponComponent>
            .Exclude<BlockWeaponReloadDurationComponent, BlockWeaponOneShootDurationComponent> _weaponShootEvent = null;

        private readonly EcsFilter<BulletsServiceTag, ObjectsFactoryComponent> _bulletsFactory = null;

        private readonly EcsFilter<BulletTag, TransformComponent, MovementSpeedComponent, InactiveObjectTag>
            _bullets = null;


        public void Run()
        {
            foreach (int idx in _weaponShootEvent)
            {
                CheckBulletsAmountAndCreateIfNeed();

                ref WeaponComponent weaponComponent = ref _weaponShootEvent.Get2(idx);

                //one pass
                foreach (var bulletIdx in _bullets)
                {
                    ref EcsEntity bulletEntity = ref _bullets.GetEntity(bulletIdx);
                    ref TransformComponent transformComponent = ref _bullets.Get2(bulletIdx);
                    ref MovementSpeedComponent speedComponent = ref _bullets.Get3(idx);


                    RunInitBullet(bulletEntity);
                    MoveBulletToMuzzlePosition(transformComponent.value, weaponComponent);
                    SetBulletMovementDirection(bulletEntity, weaponComponent.muzzleTransformForBullet);
                    ActivateBullet(bulletEntity);

                    bulletEntity.Replace(new DelayDeactivateObjectComponent()
                    {
                        Timer = SolvingBulletFlightTime(weaponComponent, speedComponent)
                    });

                    break;
                }

                weaponComponent.bulletsResidueAtMagazine -= 1;

                ref EcsEntity playerShootEntity = ref _weaponShootEvent.GetEntity(idx);
                BlockShooting(weaponComponent, playerShootEntity);
                playerShootEntity.Del<WeaponShootEventTag>();
            }
        }

        private void RunInitBullet(in EcsEntity bulletEntity)
        {
            bulletEntity.Replace(new RunInitTag());
        }
        
        private void ActivateBullet(in EcsEntity bulletEntity)
        {
            bulletEntity.Replace(new ActivateObjectEventTag());
        }

        private void CheckBulletsAmountAndCreateIfNeed()
        {
            foreach (var bulletFactoryIdx in _bulletsFactory)
            {
                ref ObjectsFactoryComponent objectsFactoryComponent =
                    ref _bulletsFactory.Get2(bulletFactoryIdx);

                if (_bullets.GetEntitiesCount() < objectsFactoryComponent.value.MinBufferElementsAtPool)
                {
                    objectsFactoryComponent.value.CreateAdditionalElements();
                }
            }
        }

        private void MoveBulletToMuzzlePosition(in Transform bulletTransform,
            in WeaponComponent weaponComponent)
        {
            bulletTransform.position = weaponComponent.muzzleTransformForBullet.position;
            bulletTransform.rotation = Quaternion.identity;
        }

        private void SetBulletMovementDirection(in EcsEntity bulletEntity, in Transform muzzleTransform)
        {
            ref MoveToComponent bulletMoveComponent = ref bulletEntity.Get<MoveToComponent>();
            bulletMoveComponent.Direction = muzzleTransform.forward;
        }

        private float SolvingBulletFlightTime(in WeaponComponent weaponComponent,
            in MovementSpeedComponent speedComponent)
        {
            return weaponComponent.bulletRange * speedComponent.reverseSpeed;
        }

        private void BlockShooting(in WeaponComponent weaponComponent
            , in EcsEntity playerShootEntity)
        {
            if (weaponComponent.bulletsResidueAtMagazine == 0)
            {
                playerShootEntity.Replace(new BlockWeaponReloadDurationComponent
                {
                    reloadDelay = weaponComponent.blockWeaponShootThenReload
                });
            }
            else
            {
                playerShootEntity.Replace(new BlockWeaponOneShootDurationComponent()
                {
                    oneShotDelay = weaponComponent.blockWeaponOneShootDuration
                });
            }
        }
    }
}