using ECS.CustomConvertToEntity;
using UnityEngine;

namespace ECS.References
{
    public sealed class ConvertPrefabToEntityRef : MonoBehaviour
    {
        [SerializeField] private ConvertPrefabToEntity entityConverter;

        public ConvertPrefabToEntity EntityConverter => entityConverter;
    }
}