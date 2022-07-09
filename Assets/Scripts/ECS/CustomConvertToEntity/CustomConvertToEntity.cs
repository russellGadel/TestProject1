using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace ECS.CustomConvertToEntity
{
    public class CustomConvertToEntity : MonoBehaviour
    {
        [SerializeField] private ConvertMode _convertMode;
        public ConvertMode ConvertMode => _convertMode;

        public EcsEntity Entity { get; internal set; }

        public void SetEntity(EcsEntity entity)
        {
            Entity = entity;
        }
    }
}