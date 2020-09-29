using UnityEngine;

namespace MultiplayerTesting
{
    public class RocketmanPlayer : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private float forceY = 300;
        [SerializeField] private float forceXRange = 30;

        [Header("References")]
        [SerializeField] private Rigidbody2D rb = null;

        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(GetJumpForce());
            }
        }

        private Vector2 GetJumpForce()
        {
            float forceX = Random.Range(-forceXRange, forceXRange);
            return new Vector2(forceX, forceY);
        }
    }
}
