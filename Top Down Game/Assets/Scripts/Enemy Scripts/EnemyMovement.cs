using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] FloatVariable floatVariable;

    // Where the enemy is moving to
    private Transform target;
    private Rigidbody2D rb2d;
    private float moveSpeed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        moveSpeed = floatVariable.RuntimeValue;
    }

    private void Update()
    {
        if (target != null) { FaceTarget(); }
    }

    void FixedUpdate()
    {
        if(target != null) { MoveToTarget(); }
    }

    public void UpdateTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void MoveToTarget()
    {

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.fixedDeltaTime);

    }

    private void FaceTarget()
    {
        float offset = 90;
        Vector2 direction = transform.position - target.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + offset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
