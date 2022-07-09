﻿using ECS.Components.GameObjectComponent;
using ECS.Tags;
using ECS.Tags.Events;
using Leopotam.Ecs;

namespace ECS.Systems.Events.ObjectsActivitySystem
{
    // One Frame System
    public sealed class DeactivateObjectsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<DeactivateObjectEventTag, GameObjectComponent> _objects = null;

        public void Run()
        {
            foreach (int idx in _objects)
            {
                ref EcsEntity entity = ref _objects.GetEntity(idx);

                entity.Del<ActiveObjectTag>();
                entity.Get<InactiveObjectTag>();

                ref GameObjectComponent gameObjectComponent = ref _objects.Get2(idx);
                gameObjectComponent.gameObject.SetActive(false);

                entity.Del<DeactivateObjectEventTag>();
            }
        }
    }
}