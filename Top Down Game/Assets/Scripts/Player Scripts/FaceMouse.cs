/* Has the player face the mouse cursor when it is moved, this way the player can shoot in the direction of the mouse*/

using UnityEngine;

public class FaceMouse : MonoBehaviour
{
    private Camera mainCam;
    private float offset;

    void Start()
    {
        mainCam = Camera.main;
        offset = 270; // So the sprite faces the Y-Axis
    }

    // Use FixedUpdate to avoid player jitter when rotating
    void FixedUpdate()
    {
        faceMouse();        
    }

    private void faceMouse()
    {
        // Difference between mouse position and objects position relative to screen space
        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        // Get the angle whose tangent is the quotient of the directions y and x value and convert from Radians to Degrees
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + offset;

        // Rotate the object by the calculated angle on the z axis to face the mouse
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
