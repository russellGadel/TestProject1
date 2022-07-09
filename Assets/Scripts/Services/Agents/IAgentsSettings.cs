using UnityEngine;

namespace Services.Agents
{
    public interface IAgentsSettings
    {
        float BodyRotationSpeed { get; }
        float DistanceToChangeGoal { get; }
        int NumbersOfCartridgesInFiringQueuePerPlayer { get; }
        float DelayFiringQueue { get; }
        Color AgentColor { get; }
        Color ColorWhenPlayerAims { get; }
        int NumberOfHitsByPlayerToDeactivate { get; }
        float DelayOneShot { get; }
        float GetRandomDelayChangeState();
    }
}