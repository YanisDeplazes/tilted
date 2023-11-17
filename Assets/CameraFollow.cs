using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The object the camera will follow
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Offset from the target object

    void Update()
    {
        if (target != null)
        {
            // Update the camera's position to follow the target object
            transform.position = target.position + offset;
        }
    }
}
