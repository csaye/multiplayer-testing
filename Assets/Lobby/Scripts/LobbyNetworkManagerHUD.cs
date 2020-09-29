using Mirror;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

namespace MultiplayerTesting
{
    public class LobbyNetworkManagerHUD : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private NetworkManager manager = null;
        [SerializeField] private TMP_InputField addressInput = null;
        [SerializeField] private TextMeshProUGUI addressField = null;
        [SerializeField] private GameObject joinButton = null, hostButton = null, joinBackButton = null, hostStopButton = null, goButton = null;

        public void Join()
        {
            joinButton.SetActive(false);
            hostButton.SetActive(false);
            addressInput.gameObject.SetActive(true);
            joinBackButton.SetActive(true);
            goButton.SetActive(true);
        }

        public void Host()
        {
            joinButton.SetActive(false);
            hostButton.SetActive(false);
            hostStopButton.SetActive(true);
            manager.StartHost();
            addressField.gameObject.SetActive(true);
            addressField.text = $"Hosting on: {GetLocalIP()}";
        }

        public void JoinBack()
        {
            joinButton.SetActive(true);
            hostButton.SetActive(true);
            addressInput.gameObject.SetActive(false);
            joinBackButton.SetActive(false);
            goButton.SetActive(false);
            manager.StopClient();
        }

        public void HostBack()
        {
            joinButton.SetActive(true);
            hostButton.SetActive(true);
            hostStopButton.SetActive(false);
            manager.StopHost();
            addressField.gameObject.SetActive(false);
        }

        public void Go()
        {
            string address = addressInput.text;
            if (string.IsNullOrWhiteSpace(address)) return;
            addressInput.gameObject.SetActive(false);
            goButton.SetActive(false);
            manager.networkAddress = address;
            manager.StartClient();
        }

        private string GetLocalIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "error (IP not found)";

            // return Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(f => f.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
        }
    }
}
