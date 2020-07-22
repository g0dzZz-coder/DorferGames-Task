using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This class receives drag input and rotates level around pivot to drag delta.
/// </summary>
public class LevelRotator : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private GameObject level = null;
    [SerializeField]
    private GameObject pivot = null;
    [SerializeField]
    private Vector2 rotationSensitivity = new Vector2(0.05f, 0.05f);
    [SerializeField]
    private Vector2 xRotationLimits = new Vector2(-5f, 5f);
    [SerializeField]
    private Vector2 zRotationLimits = new Vector2(-5f, -5f);

    public bool IsRotationEnabled { get; set; } = true;

    private GameManager gameMgr;

    /// <summary>
    /// Component initialization.
    /// </summary>
    public void Init(GameManager gameMgr)
    {
        this.gameMgr = gameMgr;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsRotationEnabled)
            return;

        RotateLevel(eventData.delta);
    }

    /// <summary>
    /// Rotate level geometry around pivot.
    /// </summary>
    /// <param name="delta">Rotation angle delta</param>
    private void RotateLevel(Vector2 delta)
    {
        level.transform.RotateAround(pivot.transform.position, Vector3.back,
            delta.x * rotationSensitivity.x / Screen.width * 320);
        level.transform.RotateAround(pivot.transform.position, Vector3.right,
            delta.y * rotationSensitivity.y / Screen.height * 526);

        ClampRotation(delta);
    }

    /// <summary>
    /// Clamp rotation inside limits on x and z components.
    /// </summary>
    /// <param name="delta">Level rotation delta</param>
    private void ClampRotation(Vector2 delta)
    {
        ClampRotationOnAxis(delta.x, Vector3.back, zRotationLimits, rotationSensitivity.x);
        ClampRotationOnAxis(delta.y, Vector3.right, xRotationLimits, rotationSensitivity.y);
    }

    /// <summary>
    /// Get angle between level's up vector projected on axis plane
    /// and rotate level to minus delta if angle not between limits.
    /// </summary>
    /// <param name="angleDelta">Level rotation delta</param>
    /// <param name="axis">Axis for finding up vector projection and for rotating level around</param>
    /// <param name="limits">Limits to check angle</param>
    /// <param name="sensitivity">Level rotation sensitivity</param>
    private void ClampRotationOnAxis(float angleDelta, Vector3 axis, Vector2 limits, float sensitivity)
    {
        Vector3 levelUpProjection = level.transform.up;
        levelUpProjection.x *= 1 - Mathf.Abs(axis.x);
        levelUpProjection.y *= 1 - Mathf.Abs(axis.y);
        levelUpProjection.z *= 1 - Mathf.Abs(axis.z);
        float angle = Vector3.Angle(levelUpProjection, Vector3.up);

        if (angle <= limits.x || angle >= limits.y)
        {
            level.transform.RotateAround(pivot.transform.position, axis, -angleDelta * sensitivity);
        }
    }

    /// <summary>
    /// Set new level to rotate around pivot.
    /// </summary>
    /// <param name="newLevel">New level</param>
    public void SetNewLevel(GameObject newLevel)
    {
        level = newLevel;
    }
}
