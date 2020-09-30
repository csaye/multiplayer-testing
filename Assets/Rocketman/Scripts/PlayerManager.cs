using Mirror;
using TMPro;
using UnityEngine;

namespace MultiplayerTesting
{
    public class PlayerManager : NetworkBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI winText = null;

        public bool gameStarted {get; set;} = false;

        public void PlayerWon(int playerNumber)
        {
            gameStarted = false;
            winText.gameObject.SetActive(true);
            winText.text = $"Player {playerNumber} won";
        }
    }
}
