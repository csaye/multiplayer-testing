using Mirror;
using UnityEngine;

namespace MultiplayerTesting
{
    public class RocketmanNetworkManager : NetworkManager
    {
        [Header("Attributes")]
        [SerializeField] private Color[] playerColors = null;

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            GameObject player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
            player.GetComponent<SpriteRenderer>().color = playerColors[numPlayers];
            NetworkServer.AddPlayerForConnection(conn, player);
        }

        public override void OnServerDisconnect(NetworkConnection conn)
        {
            base.OnServerDisconnect(conn);
        }
    }
}
