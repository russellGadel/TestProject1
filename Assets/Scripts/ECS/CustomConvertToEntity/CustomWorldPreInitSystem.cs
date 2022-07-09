using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace ECS.CustomConvertToEntity
{
    public class CustomWorldPreInitSystem : IEcsPreInitSystem, IEcsDestroySystem
    {
        readonly EcsWorld _world = null;

        public void PreInit()
        {
            var convertableGameObjects =
                GameObject.FindObjectsOfType<CustomConvertToEntity>();

            foreach (var convertable in convertableGameObjects)
            {
                AddEntity(convertable);
            }

            WorldHandler.Init(_world);
        }

        private void AddEntity(CustomConvertToEntity customConvertToEntity)
        {
            EcsEntity entity = WorldHandler.GetWorld().NewEntity();
            GameObject entityGameObject = customConvertToEntity.gameObject;

            foreach (Component component in entityGameObject.GetComponents<Component>())
            {
                if (component is IConvertToEntity entityComponent)
                {
                    entityComponent.Convert(entity);
                    GameObject.Destroy(component);
                }
            }

            switch (customConvertToEntity.ConvertMode)
            {
                case ConvertMode.ConvertAndDestroy:
                    GameObject.Destroy(entityGameObject);
                    break;
                case ConvertMode.ConvertAndInject:
                    GameObject.Destroy(customConvertToEntity);
                    break;
                case ConvertMode.ConvertAndSave:
                    customConvertToEntity.Entity = entity;
                    break;
            }
        }

        public void Destroy()
        {
            WorldHandler.Destroy();
        }
    }
}