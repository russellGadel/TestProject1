using ECS.CustomConvertToEntity;
using ECS.Tags.Agent;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Triggers
{
    public class PlayerEnterToAgentAttackZoneTrigger : MonoBehaviour
    {
        [SerializeField] private ConvertPrefabToEntity _convertPrefabToEntity;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(UnityTags.Player.ToString()))
            {
                _convertPrefabToEntity.Entity.Replace(new AgentShootToPlayerTag());
            }
        }
        
      
    }
}