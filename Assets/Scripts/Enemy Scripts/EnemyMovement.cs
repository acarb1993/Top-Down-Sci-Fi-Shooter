using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] FloatVariable floatVariable = null;

    private Rigidbody2D rb2d;
    private float moveSpeed;
    
    public Vector3 StartPosition { get; private set; }
    // Where the enemy is moving to
    public Vector3 TargetPosition { get; set; }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        moveSpeed = floatVariable.RuntimeValue;
        StartPosition = transform.position;
    }

    void FixedUpdate()
    {
        if(TargetPosition != null) { MoveToTarget(); }
    }

    private void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetPosition, moveSpeed * Time.fixedDeltaTime);
    }
}
