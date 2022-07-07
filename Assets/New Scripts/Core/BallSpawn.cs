using UnityEngine;

namespace Throwing_Self.Assets.New_Scripts
{
    public class BallSpawn : MonoBehaviour
    {
        [SerializeField] private Collider2D myCollider2D;
        [SerializeField] private Transform ball;

        [ContextMenu("Call Ball")]
        private void CallBall()
        {
            myCollider2D.enabled = true;
            ball.position = transform.position;
            var ballBody = ball.GetComponent<Rigidbody2D>();
            ballBody.isKinematic = true;
            ballBody.velocity = Vector2.zero;
        }

        private void Start()
        {
            CallBall();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.transform == ball)
            {
                myCollider2D.enabled = false;
            }
        }
    }
}