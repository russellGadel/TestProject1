using ECS.Components;
using ECS.Components.ObjectMass;
using JetBrains.Annotations;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Player
{
    public sealed class PlayerHitByBulletSystem : IEcsRunSystem
    {
        [CanBeNull]
        private readonly EcsFilter<PlayerHitByBulletComponent, ObjectMassComponent> _player = null;

        private Vector3 _direction = Vector3.zero;
        private const int ZeroY = 0;

        public void Run()
        {
            foreach (int idx in _player)
            {
                ref ObjectMassComponent objectMassComponent = ref _player.Get2(idx);
                ref PlayerHitByBulletComponent bullet = ref _player.Get1(idx);

                _direction = -bullet.BulletDirection.normalized;
                
                if (_direction.y < ZeroY)
                {
                    _direction.y = -_direction.y;
                }

                ref EcsEntity entity = ref _player.GetEntity(idx);
                entity.Replace(new ForceComponent()
                {
                    Force = (_direction * bullet.BulletRepulsionForceOnImpact) / objectMassComponent.mass
                });

                entity.Del<PlayerHitByBulletComponent>();
            }
        }
    }
}