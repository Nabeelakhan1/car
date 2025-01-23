using UnityEngine;

public class TouchRotateCamera : MonoBehaviour
{
    public Transform target; // The target object to rotate around
    public float rotationSpeed = 0.2f; // Speed of rotation

    private Vector2 previousTouchPosition;

    void Update()
    {
        if (Input.touchCount == 1) // Single finger touch
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                // Calculate rotation
                Vector2 touchDelta = touch.deltaPosition;
                float horizontalRotation = touchDelta.x * rotationSpeed;
                float verticalRotation = -touchDelta.y * rotationSpeed;

                // Rotate the camera around the target
                transform.RotateAround(target.position, Vector3.up, horizontalRotation);
                transform.RotateAround(target.position, transform.right, verticalRotation);
            }
        }
    }
}
