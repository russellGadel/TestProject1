using ECS.CustomConvertToEntity;
using ECS.Tags.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Triggers
{
    public sealed class PlayerBulletHitAgentTrigger : MonoBehaviour
    {
        [SerializeField] private ConvertPrefabToEntity _convertPrefabToEntity;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(UnityTags.Bullet.ToString()))
            {
                _convertPrefabToEntity.Entity.Replace(new PlayerBulletHitAgentEventTag());
                BulletActions(other);
            }
        }
        

        private void BulletActions(in Collider other)
        {
            ConvertPrefabToEntity bulletEntityConvertor = other.gameObject.GetComponent<ConvertPrefabToEntity>();
            bulletEntityConvertor.Entity.Replace(new BulletHitObjectEventTag());
        }
    }
}