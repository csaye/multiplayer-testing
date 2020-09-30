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

        [SyncVar]
        private bool gameStarted = false;

        private void Update()
        {
            if (!isLocalPlayer) return;
            // if (playerManager == null) return;

            if (Input.GetButtonDown("Jump") && gameStarted) rb.AddForce(GetJumpForce());
            // if (transform.position.y > 20) playerManager.PlayerWon(playerNumber);
            if (Input.GetKeyDown("return")) CmdStartGame();
        }

        private Vector2 GetJumpForce()
        {
            float forceX = Random.Range(-forceXRange, forceXRange);
            return new Vector2(forceX, forceY);
        }

        [Command]
        private void CmdStartGame() => gameStarted = true;
    }
}
