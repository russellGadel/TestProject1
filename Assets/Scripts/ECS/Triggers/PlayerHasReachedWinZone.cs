using ECS.CustomConvertToEntity;
using ECS.Tags.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Triggers
{
    public class PlayerHasReachedWinZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(UnityTags.Player.ToString()))
            {
                ConvertPrefabToEntity converter = other.gameObject.GetComponent<ConvertPrefabToEntity>();
                converter.Entity.Replace(new WinEventTag());
            }
        }
    }
}