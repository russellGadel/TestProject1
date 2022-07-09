using System;
using UnityEngine;

namespace ECS.Components.MovementSpeed
{
    [Serializable]
    public struct MovementSpeedComponent
    {
        public float speed;
        [HideInInspector] public float reverseSpeed;
    }
}