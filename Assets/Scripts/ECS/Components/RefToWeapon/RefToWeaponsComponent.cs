using System;
using ECS.CustomConvertToEntity;

namespace ECS.Components.RefToWeapon
{
    [Serializable]
    public struct RefToWeaponsComponent
    {
        public ConvertPrefabToEntity mainWeapon;
    }
}