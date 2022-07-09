using ECS.Components;
using ECS.Components.BulletCurrentSettings;
using ECS.Components.TransformComponent;
using ECS.CustomConvertToEntity;
using ECS.Tags.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Triggers
{
    public sealed class BulletHitPlayerTrigger : MonoBehaviour
    {
        [SerializeField] private ConvertPrefabToEntity _convertPrefabToEntity;

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(UnityTags.Bullet.ToString()))
            {
                EcsEntity bulletEntity = other.gameObject.GetComponent<ConvertPrefabToEntity>().Entity;

                ref BulletCurrentSettingsComponent bulletSettings =
                    ref bulletEntity.Get<BulletCurrentSettingsComponent>();
                ref TransformComponent bulletTransform = ref bulletEntity.Get<TransformComponent>();

                _convertPrefabToEntity.Entity.Replace(new PlayerHitByBulletComponent()
                {
                    BulletRepulsionForceOnImpact = bulletSettings.repulsionForceOnImpact,
                    BulletDirection = bulletTransform.value.forward
                });


                BulletActions(other);
            }
        }

        private void BulletActions(in Collider collision)
        {
            ConvertPrefabToEntity bulletEntityConvertor = collision.gameObject.GetComponent<ConvertPrefabToEntity>();
            bulletEntityConvertor.Entity.Replace(new BulletHitObjectEventTag());
        }
    }
}