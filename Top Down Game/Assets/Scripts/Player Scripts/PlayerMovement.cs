using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] FloatVariable playerSpeed;

    // Moves the player with the Unity physics engine
    private Rigidbody2D rb;

    // Stores the player movement values
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
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
        rb.MovePosition(rb.position + movement * playerSpeed.RuntimeValue * Time.fixedDeltaTime);
    }
}
