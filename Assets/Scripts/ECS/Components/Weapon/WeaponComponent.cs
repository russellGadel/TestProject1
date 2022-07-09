using System;
using UnityEngine;

namespace ECS.Components.Weapon
{
    [Serializable]
    public struct WeaponComponent
    {
        public Transform muzzleTransformForBullet;
        public int magazineCapacity;
        public float bulletRange;
        [HideInInspector] public int bulletsResidueAtMagazine;

        public float blockWeaponOneShootDuration;
        public float blockWeaponShootThenReload;
    }
}