using UnityEngine;

namespace Services.Bullets
{
    public sealed class BulletsSettings : MonoBehaviour
    {
        [SerializeField] private float _bulletLifeTimeAfterHit;
        public float BulletLifeTimeAfterHit => _bulletLifeTimeAfterHit;
    }
}