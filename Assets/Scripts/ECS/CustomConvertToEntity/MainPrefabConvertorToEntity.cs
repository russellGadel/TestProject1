using Leopotam.Ecs;
using UnityEngine;

namespace ECS.CustomConvertToEntity
{
    public class MainPrefabConvertorToEntity : MonoBehaviour
    {
        [Header("First element is main Entity")] [SerializeField]
        private ConvertPrefabToEntity[] _subEntities;

        public void Convert()
        {
            for (int i = 0; i < _subEntities.Length; i++)
            {
                _subEntities[i].Convert();
            }
        }

        public EcsEntity GetMainEntity()
        {
            return _subEntities[0].Entity;
        }
    }
}