using Mirror;
using UnityEngine;

namespace MultiplayerTesting
{
    public class RocketmanNetworkManager : NetworkManager
    {
        [Header("Attributes")]
        [SerializeField] private Color[] playerColors = null;
        [SerializeField] private Vector2[] playerPositions = null;

        [Header("References")]
        [SerializeField] private PlayerManager playerManager = null;

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            GameObject player = Instantiate(playerPrefab, playerPositions[numPlayers], Quaternion.identity);
            // player.GetComponent<SpriteRenderer>().color = playerColors[numPlayers];
            player.GetComponent<RocketmanPlayer>().Initialize(playerManager, numPlayers);
            NetworkServer.AddPlayerForConnection(conn, player);
        }

        public override void OnServerDisconnect(NetworkConnection conn)
        {
            base.OnServerDisconnect(conn);
        }
    }
}
