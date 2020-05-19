using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] FloatVariable floatVariable;

    // Where the enemy is moving to
    private Rigidbody2D rb2d;
    private float moveSpeed, offset;
    
    public Vector3 StartPosition { get; private set; }
    public Vector3 TargetPosition { get; set; }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        moveSpeed = floatVariable.RuntimeValue;
        offset = -90;
        StartPosition = transform.position;
    }

    private void Update()
    {
        if (TargetPosition != null) { FaceTarget(); }
    }

    void FixedUpdate()
    {
        if(TargetPosition != null) { MoveToTarget(); }
    }

    private void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetPosition, moveSpeed * Time.fixedDeltaTime);
    }

    private void FaceTarget()
    {
        Vector2 direction = transform.position - TargetPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + offset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
