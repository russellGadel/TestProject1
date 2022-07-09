using UnityEngine;

namespace CustomUI.WinWindow
{
    public sealed class WinWindowSettings : MonoBehaviour
    {
        [SerializeField] private float windowDisplayTime;
        public float WindowDisplayTime => windowDisplayTime;
    }
}