/*using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public float gravityStrength = 9.81f;

    void Update()
    {
        float zRotation = transform.eulerAngles.z;

        if (zRotation >= 315 || zRotation < 45) // Z rotation close to 0 (normal gravity)
        {
            Physics2D.gravity = new Vector2(0, -gravityStrength);
        }
        else if (zRotation >= 45 && zRotation < 135) // Z rotation close to 90 degrees
        {
            Physics2D.gravity = new Vector2(gravityStrength, 0);
        }
        else if (zRotation >= 135 && zRotation < 225) // Z rotation close to 180 degrees
        {
            Physics2D.gravity = new Vector2(0, gravityStrength);
        }
        else if (zRotation >= 225 && zRotation < 315) // Z rotation close to -90 degrees
        {
            Physics2D.gravity = new Vector2(-gravityStrength, 0);
        }
    }
}*/


/*using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public float gravityStrength = 9.81f;
    public float movementRight = 10.0f;

    void Update()
    {
        float zRotation = transform.eulerAngles.z;

        if (zRotation >= 315 || zRotation < 45) // Z rotation close to 0 (normal gravity)
        {
            float adjustedMovementRight = movementRight * Mathf.Abs(Mathf.Cos(zRotation * Mathf.Deg2Rad));
            Physics2D.gravity = new Vector2(-gravityStrength * Mathf.Sin(zRotation * Mathf.Deg2Rad), -gravityStrength * Mathf.Cos(zRotation * Mathf.Deg2Rad)) + new Vector2(adjustedMovementRight, 0);
        }
        else if (zRotation >= 45 && zRotation < 135) // Z rotation close to 90 degrees
        {
            Physics2D.gravity = new Vector2(gravityStrength, 0);
        }
        else if (zRotation >= 135 && zRotation < 225) // Z rotation close to 180 degrees
        {
            Physics2D.gravity = new Vector2(0, gravityStrength);
        }
        else if (zRotation >= 225 && zRotation < 315) // Z rotation close to -90 degrees
        {
            Physics2D.gravity = new Vector2(-gravityStrength, 0);
        }
    }
}*/

using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public float gravityStrength = 9.81f;
    public float movementStrength = 10.0f;

    void Update()
    {
        float zRotation = transform.eulerAngles.z;

        Vector2 gravityDirection = Vector2.zero;

        if (zRotation >= 315 || zRotation < 45) // Z rotation close to 0 (normal gravity)
        {
            gravityDirection = new Vector2(0, -gravityStrength);
        }
        else if (zRotation >= 45 && zRotation < 135) // Z rotation close to 90 degrees
        {
            gravityDirection = new Vector2(gravityStrength, 0);
        }
        else if (zRotation >= 135 && zRotation < 225) // Z rotation close to 180 degrees
        {
            gravityDirection = new Vector2(0, gravityStrength);
        }
        else if (zRotation >= 225 && zRotation < 315) // Z rotation close to -90 degrees
        {
            gravityDirection = new Vector2(-gravityStrength, 0);
        }

        Vector2 lateralMovement = Vector2.zero;

        if (gravityDirection != Vector2.zero)
        {
            lateralMovement = new Vector2(-gravityDirection.y, gravityDirection.x).normalized * movementStrength;
        }

        Physics2D.gravity = gravityDirection + lateralMovement;
    }
}




