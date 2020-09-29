using TMPro;
using UnityEngine;

namespace MultiplayerTesting
{
    public class LobbyNetworkManagerHUD : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private LobbyNetworkManager manager = null;
        [SerializeField] private TMP_InputField addressInput = null;

        public void StartHost()
        {
            manager.StartHost();
        }

        public void StartClient()
        {
            manager.networkAddress = addressInput.text;
            manager.StartClient();
        }

        public void StopClient()
        {
            manager.StopClient();
        }
    }
}
