using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float jumpForce = 650f; // Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f; // How much to smooth out the movement
    [SerializeField] private LayerMask whatIsGround; // A mask determining what is ground to the character
	[SerializeField] private Transform groundCheck;	// A position marking where to check if the player is grounded.

	const float groundRadius = .2f; // Radius of the overlap circle to determine if grounded
	bool grounded;            // Whether or not the player is grounded.
	Rigidbody2D myRigidbody2D;
	bool m_FacingRight = true;  // For determining which way the player is currently facing.
	Vector3 m_Velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myRigidbody2D.gravityScale = 3f; // Gravity is 3
        myRigidbody2D.freezeRotation = true; // Freeze the z-axis rotation

        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }			
	}

	private void FixedUpdate()
	{
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    public void Move(float move, bool jump)
    {
        //only control the player if grounded or airControl is turned on
        if (grounded)
        {            
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, myRigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            myRigidbody2D.velocity = Vector3.SmoothDamp(myRigidbody2D.velocity, targetVelocity, ref m_Velocity, movementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
        // If the player should jump...
        if (grounded && jump)
        {
            // Add a vertical force to the player.
            grounded = false;
            myRigidbody2D.AddForce(new Vector2(0f, jumpForce));
        }
    }

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}