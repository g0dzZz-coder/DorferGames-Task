using UnityEngine;

/// <summary>
/// This class controls position of game camera.
/// </summary>
public class FollowingCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target = null;
    [SerializeField]
    private float smoothSpeed = 0.125f;
    [SerializeField]
    private Vector3 offset = new Vector3(0,0,0);

    private void FixedUpdate()
    {
        if (target)
        {
            // Set position of camera to target position with offset.
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Rotate camera to face target.
            transform.LookAt(target);
        }
    }
}
