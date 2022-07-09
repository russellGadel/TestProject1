using UnityEngine;

namespace CustomUI.CustomCamera
{
    public sealed class CameraView : MonoBehaviour
        , ICameraView
    {
        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}