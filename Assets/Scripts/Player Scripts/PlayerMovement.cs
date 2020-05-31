using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] FloatVariable playerSpeed = null;

    // Moves the player with the Unity physics engine
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 target)
    {
        rb2d.MovePosition(rb2d.position + target * playerSpeed.RuntimeValue * Time.fixedDeltaTime);
    }
}
