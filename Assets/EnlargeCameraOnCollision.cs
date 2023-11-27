using UnityEngine;

public class EnlargeCameraOnCollision : MonoBehaviour
{
    public float enlargedSize = 10f; // Size to which you want to enlarge the camera

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // Getting the reference to the main camera

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Assuming "Player" is the tag of your character
        {
            Debug.Log("Player collided with trigger!");

            if (mainCamera != null)
            {
                Debug.Log("Enlarging camera...");

                // Enlarge the size of the camera
                mainCamera.orthographicSize = enlargedSize;
            }
            else
            {
                Debug.LogError("Main camera reference is null!");
            }
        }
    }
}

