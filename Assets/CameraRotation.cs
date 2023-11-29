/*using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationAmount = 90.0f;
    public float rotationAmountLeft = -90.0f;
    public float rotationDuration = 1.0f; // Time taken for the rotation

    public Transform squareObject; // Reference to the square object

    private bool isRotating = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private float rotationTimer = 0.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isRotating)
        {
            StartRotation(rotationAmount);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isRotating)
        {
            StartRotation(rotationAmountLeft);
        }

        if (isRotating)
        {
            RotateCamera();
        }
    }

    void StartRotation(float rotationAngle)
    {
        initialRotation = transform.rotation;
        targetRotation = initialRotation * Quaternion.Euler(0, 0, rotationAngle);
        isRotating = true;
        rotationTimer = 0.0f;
    }

    void RotateCamera()
    {
        rotationTimer += Time.deltaTime / rotationDuration;
        transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, rotationTimer);

        if (rotationTimer >= 1.0f)
        {
            isRotating = false;
        }
    }
}*/

using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationAmount = -90.0f;
    public float rotationAmountLeft = 90.0f;
    public float rotationDuration = 1.0f; // Time taken for the rotation

    public Transform squareObject; // Reference to the square object

    private bool isRotating = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private float rotationTimer = 0.0f;

    void Update()
    {
        if (Time.timeScale == 1.0f) // Check if game time is set to 1
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && !isRotating)
            {
                StartRotation(rotationAmount);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && !isRotating)
            {
                StartRotation(rotationAmountLeft);
            }
        }

        if (isRotating)
        {
            RotateCamera();
        }
    }

    void StartRotation(float rotationAngle)
    {
        initialRotation = transform.rotation;
        targetRotation = initialRotation * Quaternion.Euler(0, 0, rotationAngle);
        isRotating = true;
        rotationTimer = 0.0f;
    }

    void RotateCamera()
    {
        rotationTimer += Time.deltaTime / rotationDuration;
        transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, rotationTimer);

        if (rotationTimer >= 1.0f)
        {
            isRotating = false;
        }
    }
}
