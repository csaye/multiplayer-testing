using Mirror;
using UnityEngine;

namespace MultiplayerTesting
{
    public class LobbyPlayer : NetworkBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private float speed = 10;

        [Header("References")]
        [SerializeField] private Rigidbody2D rb = null;

        private void FixedUpdate()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            if (isLocalPlayer) rb.velocity = new Vector2(x, y) * speed * Time.deltaTime;
        }
    }
}
