using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] FloatVariable floatVariable = null;

    // Where the enemy is moving to
    private Rigidbody2D rb2d;
    private float moveSpeed;
    
    public Vector3 StartPosition { get; private set; }
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
