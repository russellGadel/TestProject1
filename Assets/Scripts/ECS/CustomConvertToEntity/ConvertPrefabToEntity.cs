using ECS.Tags;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace ECS.CustomConvertToEntity
{
    public class ConvertPrefabToEntity : MonoBehaviour
    {
        [SerializeField] private ConvertMode _convertMode;
        public ConvertMode ConvertMode => _convertMode;
        public EcsEntity Entity { get; internal set; }


        public void Convert()
        {
            // Creating new Entity
            EcsEntity entity = WorldHandler.GetWorld().NewEntity();

            foreach (Component component in gameObject.GetComponents<Component>())
            {
                if (component is IConvertToEntity entityComponent)
                {
                    // Adding Component to entity
                    entityComponent.Convert(entity);
                    Destroy(component);
                }
            }

            entity.Replace(new InactiveObjectTag());

            switch (_convertMode)
            {
                case ConvertMode.ConvertAndDestroy:
                    Destroy(gameObject);
                    break;
                case ConvertMode.ConvertAndInject:
                    Destroy(this);
                    break;
                case ConvertMode.ConvertAndSave:
                    Entity = entity;
                    break;
            }
        }
    }
}