using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] FloatVariable playerSpeed = null;

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
        // Moves the rigid body based on key input
        rb.MovePosition(rb.position + movement * playerSpeed.RuntimeValue * Time.fixedDeltaTime);
    }

    public void Walk()
    {
        playerSpeed.RuntimeValue = playerSpeed.InitialValue;
    }
}
