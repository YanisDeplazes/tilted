using UnityEngine;

public class ResetCameraSize : MonoBehaviour
{
    public float defaultSize = 4.85f;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (mainCamera != null)
            {
                mainCamera.orthographicSize = defaultSize;
            }
            else
            {
                Debug.LogError("Main camera reference is null!");
            }
        }
    }
}

