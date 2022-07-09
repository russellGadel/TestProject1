using ECS.Components.BlockWeaponReloadDuration;
using ECS.Components.Weapon;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Events.Weapon
{
    public class BlockWeaponShootThenReloadSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BlockWeaponReloadDurationComponent, WeaponComponent> _ecsFilter = null;


        public void Run()
        {
            foreach (int i in _ecsFilter)
            {
                ref BlockWeaponReloadDurationComponent block = ref _ecsFilter.Get1(i);
                
                ref float timer = ref block.reloadDelay;

                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    ref EcsEntity entity = ref _ecsFilter.GetEntity(i);
                    ref WeaponComponent weaponComponent = ref _ecsFilter.Get2(i);
                    
                    weaponComponent.bulletsResidueAtMagazine = weaponComponent.magazineCapacity;
                    entity.Del<BlockWeaponReloadDurationComponent>();
                }
            }
        }
    }
}