using ECS.Components.Weapon;
using ECS.Tags;
using ECS.Tags.Events.Weapon;
using ECS.Tags.PlayerElementsTag;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Player
{
    public sealed class PlayerMouseInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerElementsTag, WeaponComponent, ActiveObjectTag> _playerWeapon = null;

        public void Run()
        {
            if (Input.GetMouseButtonDown(0))
            {
                foreach (int idx in _playerWeapon)
                {
                    ref EcsEntity playerEntity = ref _playerWeapon.GetEntity(idx);
                    playerEntity.Replace(new WeaponShootEventTag());
                }
            }
        }
    }
}