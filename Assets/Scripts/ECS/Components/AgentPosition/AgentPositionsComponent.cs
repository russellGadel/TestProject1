using System;
using UnityEngine;

namespace ECS.Components.AgentPosition
{
    [Serializable]
    public struct AgentPositionsComponent
    {
        public Transform spawnTransform;
        [Header("Size shouldn't be not less than 2 items")] public Transform[] patrolGoalsPositions;
    }
}