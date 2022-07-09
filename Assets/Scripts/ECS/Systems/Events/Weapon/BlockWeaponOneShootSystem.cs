using ECS.Components.BlockWeaponShootDuration;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Events.Weapon
{
    public sealed class BlockWeaponOneShootSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BlockWeaponOneShootDurationComponent> _ecsFilter = null;


        public void Run()
        {
            foreach (int i in _ecsFilter)
            {
                ref BlockWeaponOneShootDurationComponent block = ref _ecsFilter.Get1(i);

                ref float timer = ref block.oneShotDelay;

                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    ref EcsEntity entity = ref _ecsFilter.GetEntity(i);
                    entity.Del<BlockWeaponOneShootDurationComponent>();
                }
            }
        }
    }
}