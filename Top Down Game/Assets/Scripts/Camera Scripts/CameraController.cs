// Allows the camera to follow the player while they move

using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");

        // Gets the difference of the Cameras z position and the Players z position
        float zOffset = transform.position.z - player.transform.position.z;

        // Give the offset a new vector only with a z value, the camera will snap to the player and follow on play 
        offset = new Vector3(0, 0, zOffset);
    }

    // Always keep camera movement in LateUpdate so it tracks player movement after Update is called
    void LateUpdate()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        // The new position of the camera is the Players position
        transform.position = player.transform.position + offset;
    }
}
