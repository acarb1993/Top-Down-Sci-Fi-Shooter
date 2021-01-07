using UnityEngine;

public class FaceTarget : MonoBehaviour
{
    [SerializeField] float offset = -90f;
    public Vector3 Target { get; set; }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Target != null) { faceTarget(); }
    }

    private void faceTarget()
    {
        Vector2 direction = transform.position - Target;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + offset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
