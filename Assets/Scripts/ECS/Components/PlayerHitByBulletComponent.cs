using UnityEngine;

namespace ECS.Components
{
    public struct PlayerHitByBulletComponent
    {
        public float BulletRepulsionForceOnImpact;
        public Vector3 BulletDirection;
    }
}