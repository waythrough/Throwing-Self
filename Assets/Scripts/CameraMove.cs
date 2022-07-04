using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform follow;
    [SerializeField] private Vector2 smoothTime;

    private Vector2 velocity;

    private void FixedUpdate()
    {
        var currentPosition = transform.position;
        
        currentPosition.x = Mathf.SmoothDamp(currentPosition.x, follow.position.x, ref velocity.x, smoothTime.x);
        currentPosition.y = Mathf.SmoothDamp(currentPosition.y, follow.position.y, ref velocity.y, smoothTime.y);

        transform.position = currentPosition;
    }
}
