using ECS.Components.MovementSpeed;
using ECS.Tags.Bullet;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Init
{
    public sealed class InitBulletsSystem : IEcsInitSystem
    {
        private readonly EcsFilter<BulletTag, MovementSpeedComponent> _bullets = null;

        public void Init()
        {
            foreach (int idx in _bullets)
            {
                ref MovementSpeedComponent movementSpeed = ref _bullets.Get2(idx);
                movementSpeed.reverseSpeed = 1 / movementSpeed.speed;
            }
        }
    }
}