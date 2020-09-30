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

        private static bool gameStarted = false;

        private int playerNumber = -1;

        public void Initialize(int _playerNumber)
        {
            Debug.Log("initializing player " + _playerNumber);
            playerNumber = _playerNumber;
        }

        private void Update()
        {
            if (!isLocalPlayer) return;
            // if (playerManager == null) return;

            if (Input.GetButtonDown("Jump") && gameStarted) rb.AddForce(GetJumpForce());
            // if (transform.position.y > 20) playerManager.PlayerWon(playerNumber);
            if (Input.GetKeyDown("return") && playerNumber == 0) gameStarted = true;
        }

        private Vector2 GetJumpForce()
        {
            float forceX = Random.Range(-forceXRange, forceXRange);
            return new Vector2(forceX, forceY);
        }
    }
}
