using ECS.CustomConvertToEntity;
using ECS.Tags.Agent;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Triggers
{
    public sealed class PlayerOutFromAgentAttackZoneTrigger : MonoBehaviour
    {
        [SerializeField] private ConvertPrefabToEntity _convertPrefabToEntity;

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(UnityTags.Player.ToString()))
            {
                _convertPrefabToEntity.Entity.Del<AgentShootToPlayerTag>();
            }
        }
    }
}