using UnityEngine;

namespace Extensions
{
    public static class LookAtObject
    {
        public static void LookAtObjectImmediately(this Rigidbody me, in Vector3 targetPosition)
        {
            Vector3 relativePos = targetPosition - me.position;
            me.transform.LookAt(relativePos, Vector3.up);
        }

        public static void LookAtObjectAtFixedUpdate(this Transform me, in Vector3 targetPosition,
            in float rotationSpeed)
        {
            Vector3 relativePos = targetPosition - me.position;
            me.rotation = Quaternion.Slerp(me.transform.rotation, Quaternion.LookRotation(relativePos),
                Time.fixedDeltaTime * rotationSpeed);
        }
    }
}