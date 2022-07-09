using ECS.CustomConvertToEntity;
using ECS.Tags.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Triggers
{
    public sealed class OnMouseExitTrigger : MonoBehaviour
    {
        [SerializeField] private ConvertPrefabToEntity _entityConvertor;

        private void OnMouseExit()
        {
            if (_entityConvertor.Entity.Has<OnMouseExitEventTag>() == false)
            {
                _entityConvertor.Entity.Replace(new OnMouseExitEventTag());
            }
        }
    }
}