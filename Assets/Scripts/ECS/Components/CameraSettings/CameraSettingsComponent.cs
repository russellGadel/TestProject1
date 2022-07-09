using System;

namespace ECS.Components.CameraSettings
{
    [Serializable]
    public struct CameraSettingsComponent
    {
        public float sensivity;
        public float smoothTime;
        public float verticalRotationMin;
        public float verticalRotationMax;
    }
}