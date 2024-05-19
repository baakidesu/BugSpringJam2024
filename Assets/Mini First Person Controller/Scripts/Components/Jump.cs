using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rigidbody;
    public float jumpStrength = 2;
    public event System.Action Jumped;

    [SerializeField, Tooltip("Prevents jumping when the transform is in mid-air.")]
    GroundCheck groundCheck;

    private int jumpCount = 0;
    private int maxJumps = 2;

    void Reset()
    {
        // Try to get groundCheck.
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Awake()
    {
        // Get rigidbody.
        rigidbody = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        // If the player is on the ground, reset the jump count.
        if (groundCheck && groundCheck.isGrounded)
        {
            jumpCount = 0;
        }

        // Jump when the Jump button is pressed and we haven't exceeded the max jumps.
        if (Input.GetButtonDown("Jump") && (groundCheck && groundCheck.isGrounded || jumpCount < maxJumps))
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z); // Reset vertical velocity to ensure consistent jump height
            rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
            jumpCount++;
            Jumped?.Invoke();
        }
    }
}