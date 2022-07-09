using ECS.Components.Weapon;
using Leopotam.Ecs;

namespace ECS.Systems.Init
{
    public sealed class InitWeaponsSystem : IEcsInitSystem
    {
        private readonly EcsFilter<WeaponComponent> _weapons = null;

        public void Init()
        {
            foreach (int idx in _weapons)
            {
                ref WeaponComponent weaponComponent = ref _weapons.Get1(idx);
                weaponComponent.bulletsResidueAtMagazine = weaponComponent.magazineCapacity;
            }
        }
    }
}