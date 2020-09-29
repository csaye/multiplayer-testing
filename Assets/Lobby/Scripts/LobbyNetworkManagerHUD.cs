using TMPro;
using UnityEngine;

namespace MultiplayerTesting
{
    public class LobbyNetworkManagerHUD : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private LobbyNetworkManager manager = null;
        [SerializeField] private TMP_InputField addressInput = null;
        [SerializeField] private GameObject joinButton = null, hostButton = null, backButton = null, goButton = null;

        public void StartHost()
        {
            manager.StartHost();
            Go();
        }

        public void StopHost()
        {
            manager.StopHost();
        }

        public void StartClient()
        {
            string address = addressInput.text;
            if (string.IsNullOrWhiteSpace(address)) return;
            manager.networkAddress = address;
            manager.StartClient();
            Go();
        }

        public void StopClient()
        {
            manager.StopClient();
        }

        public void Join()
        {
            joinButton.SetActive(false);
            hostButton.SetActive(false);
            addressInput.gameObject.SetActive(true);
            backButton.SetActive(true);
            goButton.SetActive(true);
        }

        public void Back()
        {
            StopHost();
            StopClient();
            joinButton.SetActive(true);
            hostButton.SetActive(true);
            addressInput.gameObject.SetActive(false);
            backButton.SetActive(false);
            goButton.SetActive(false);
        }

        public void Go()
        {
            joinButton.SetActive(false);
            hostButton.SetActive(false);
            addressInput.gameObject.SetActive(false);
            backButton.SetActive(true);
            goButton.SetActive(false);
        }
    }
}
