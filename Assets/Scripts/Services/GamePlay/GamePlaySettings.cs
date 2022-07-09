using UnityEngine;

namespace Services.GamePlay
{
    public sealed class GamePlaySettings : MonoBehaviour
    {
        public float timeDelayBeforeGameOverPlayer;
        
        [Header("Victory conditions")]
        public int playerMustDeactivateAgentsAmountForWin;
    }
}