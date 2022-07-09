using ECS.CustomConvertToEntity;
using ECS.Tags.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Triggers
{
    public sealed class OnMouseEnterTrigger : MonoBehaviour
    {
        [SerializeField] private ConvertPrefabToEntity _entityConvertor;

        private void OnMouseEnter()
        {
            if (_entityConvertor.Entity.Has<OnMouseEnterEventTag>() == false)
            {
                _entityConvertor.Entity.Replace(new OnMouseEnterEventTag());
            }
        }
    }
}