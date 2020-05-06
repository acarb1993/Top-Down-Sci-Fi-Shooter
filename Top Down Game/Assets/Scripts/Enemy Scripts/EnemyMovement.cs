using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] FloatVariable floatVariable;

    // Where the enemy is moving to
    private Vector3 targetPosition;
    private Rigidbody2D rb2d;
    private float moveSpeed, offset;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        moveSpeed = floatVariable.RuntimeValue;
        offset = 90;
    }

    private void Update()
    {
        if (targetPosition != null) { FaceTarget(); }
    }

    void FixedUpdate()
    {
        if(targetPosition != null) { MoveToTarget(); }
    }

    public void UpdateTarget(Vector3 newTargetPosition)
    {
        targetPosition = newTargetPosition;
    }

    private void MoveToTarget()
    {

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime);

    }

    private void FaceTarget()
    {
        Vector2 direction = transform.position - targetPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + offset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
