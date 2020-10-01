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

        [SyncVar]
        public int playerNum = -1;

        private void Update()
        {
            if (!isLocalPlayer) return;

            if (Input.GetButtonDown("Jump") && gameStarted) rb.AddForce(GetJumpForce());
            if (transform.position.y > 20 && gameStarted) CmdEndGame(playerNum);
            if (Input.GetKeyDown("return")) CmdStartGame();
        }

        private Vector2 GetJumpForce()
        {
            float forceX = Random.Range(-forceXRange, forceXRange);
            return new Vector2(forceX, forceY);
        }

        [Command]
        private void CmdStartGame() => RpcStartGame();

        [Command]
        private void CmdEndGame(int winner) => RpcEndGame(winner);

        [ClientRpc]
        private void RpcStartGame()
        {
            GameObject.Find("UI/Canvas/WinText").GetComponent<TextMeshProUGUI>().text = "Game started";
            gameStarted = true;
        }

        [ClientRpc]
        private void RpcEndGame(int winner)
        {
            GameObject.Find("UI/Canvas/WinText").GetComponent<TextMeshProUGUI>().text = $"Player {winner} won";
            gameStarted = false;
        }
    }
}
