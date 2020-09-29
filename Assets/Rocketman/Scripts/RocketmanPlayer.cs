using Mirror;
using UnityEngine;

namespace MultiplayerTesting
{
    public class RocketmanPlayer : NetworkBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private float forceY = 300;
        [SerializeField] private float forceXRange = 30;

        [Header("References")]
        [SerializeField] private Rigidbody2D rb = null;

        private PlayerManager playerManager;

        private int playerNumber;

        public void Initialize(PlayerManager _playerManager, int _playerNumber)
        {
            playerManager = _playerManager;
            playerNumber = _playerNumber;
        }

        private void Update()
        {
            if (playerManager == null) return;

            if (Input.GetButtonDown("Jump") && playerManager.gameStarted) rb.AddForce(GetJumpForce());
            if (transform.position.y > 20) playerManager.PlayerWon(playerNumber);
            if (Input.GetKeyDown("return") && playerNumber == 0) playerManager.gameStarted = true;
        }

        private Vector2 GetJumpForce()
        {
            float forceX = Random.Range(-forceXRange, forceXRange);
            return new Vector2(forceX, forceY);
        }
    }
}
