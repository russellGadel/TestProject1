using UnityEngine;

namespace CustomUI.GameOverWindow
{
    public sealed class GameOverWindowSettings : MonoBehaviour
    {
        [SerializeField] private float windowDisplayTime;
        public float WindowDisplayTime => windowDisplayTime;
    }
}