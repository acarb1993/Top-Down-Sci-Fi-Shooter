using UnityEngine;

public class FaceTarget : MonoBehaviour
{
    [SerializeField] float offset = -90f;

    private EnemyMovement enemyMovement;
    private Vector3 target;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if (target != null) { faceTarget(); }
    }

    private void faceTarget()
    {
        target = enemyMovement.TargetPosition;
        Vector2 direction = transform.position - target;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + offset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
