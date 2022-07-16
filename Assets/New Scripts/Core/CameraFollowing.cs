using UnityEngine;

namespace Throwing_Self.Assets.New_Scripts
{
    public class CameraFollowing : MonoBehaviour
    {
        [SerializeField] private Transform follow;
        [SerializeField] private float offsetDistance;
        [SerializeField] private Vector2 smoothTime;

        private Vector2 velocity;

        private Vector2 ComputeOffset()
        {
            var mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var followPosition = (Vector2)follow.position;
            var distance = Mathf.Clamp(Vector2.Distance(mousePosition, followPosition), 0, offsetDistance);
            return (mousePosition - followPosition).normalized * distance;
        }

        private void FixedUpdate()
        {
            if(GameManager.isDefeat()) {

            }

            var position = transform.position;
            var offset = ComputeOffset();

            position.x = Mathf.SmoothDamp(position.x, follow.position.x + offset.x, ref velocity.x, smoothTime.x);
            position.y = Mathf.SmoothDamp(position.y, follow.position.y + offset.y, ref velocity.y, smoothTime.y);

            transform.position = position;
        }
    }
}