using Mirror;
using TMPro;
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

        public void Initialize(int num) => playerNumber = num;

        private void Update()
        {
            if (!isLocalPlayer) return;

            if (Input.GetButtonDown("Jump") && gameStarted) rb.AddForce(GetJumpForce());
            if (transform.position.y > 20) CmdEndGame(playerNumber);
            if (Input.GetKeyDown("return")) CmdStartGame();
        }

        private Vector2 GetJumpForce()
        {
            float forceX = Random.Range(-forceXRange, forceXRange);
            return new Vector2(forceX, forceY);
        }

        [Command]
        private void CmdStartGame() => RpcSetGameStarted(true);

        [Command]
        private void CmdEndGame(int winner)
        {
            RpcSetGameStarted(false);
            GameObject.FindWithTag("WinText").GetComponent<TextMeshProUGUI>().text = $"Player {winner} won";
        }

        [ClientRpc]
        private void RpcSetGameStarted(bool b) => gameStarted = b;
    }
}
