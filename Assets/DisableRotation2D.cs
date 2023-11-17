using UnityEngine;

public class DisableRotation2D : MonoBehaviour
{
    private Rigidbody2D cubeRigidbody;

    void Start()
    {
        // Get the Rigidbody2D component of the cube object
        cubeRigidbody = GetComponent<Rigidbody2D>();

        // Disable rotation for the cube's Rigidbody2D
        cubeRigidbody.freezeRotation = true;
    }
}
