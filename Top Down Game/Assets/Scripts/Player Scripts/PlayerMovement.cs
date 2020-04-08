using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Moves the player with the Unity physics engine
    private Rigidbody2D rb;

    [SerializeField]
    private float walkSpeed = 2f;

    public float WalkSpeed
    {
        get { return walkSpeed; }
    }

    // moveSpeed property
    public float MoveSpeed { get; set; }

    // Moves the player
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        MoveSpeed = walkSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Use Update to register the input
    void Update()
    {
        // GetAxisRaw() prevents smoothing of input. Will always be -1, 0, or 1
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    // Use FixedUpdate to register the movement
    private void FixedUpdate()
    {
        // Moves the rb to a new position and collides with anything along the way
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }
}
