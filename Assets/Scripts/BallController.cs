using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This class handles ball control.
/// </summary>
public class BallController : MonoBehaviour, IDragHandler
{
    [SerializeField] 
    private Rigidbody ball = null;
    [SerializeField]
    private float forceFactor = 0.025f;

    public void OnDrag(PointerEventData eventData)
    {
        ball.AddForce(new Vector3(eventData.delta.x / Screen.width * 320, 
                                  0, 
                                  eventData.delta.y / Screen.height * 526) * forceFactor, ForceMode.Impulse);
    }
}
