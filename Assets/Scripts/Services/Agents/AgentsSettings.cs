using UnityEngine;

namespace Services.Agents
{
    public sealed class AgentsSettings : MonoBehaviour
        , IAgentsSettings
    {
        [SerializeField] private float _bodyRotationSpeed;
        public float BodyRotationSpeed => _bodyRotationSpeed;

        [SerializeField] private float _distanceToChangeGoal;
        public float DistanceToChangeGoal => _distanceToChangeGoal;

        [SerializeField] private int _numbersOfCartridgesInFiringQueuePerPlayer;
        public int NumbersOfCartridgesInFiringQueuePerPlayer => _numbersOfCartridgesInFiringQueuePerPlayer;

        [SerializeField] private float _delayFiringQueue;
        public float DelayFiringQueue => _delayFiringQueue;
        
        [SerializeField] private float _delayOneShot;
        public float DelayOneShot => _delayOneShot;

        [SerializeField] private float delayChangeStateMin;

        [SerializeField] private float delayChangeStateMax;

        public float GetRandomDelayChangeState()
        {
            return Random.Range(delayChangeStateMin, delayChangeStateMax);
        }

        [SerializeField] private Color _agentColor;
        public Color AgentColor => _agentColor;


        [SerializeField] private Color _colorWhenPlayerAims;
        public Color ColorWhenPlayerAims => _colorWhenPlayerAims;

        [SerializeField] private int _numberOfHitsByPlayerToDeactivate;
        public int NumberOfHitsByPlayerToDeactivate => _numberOfHitsByPlayerToDeactivate;
    }
}