using UnityEngine;

namespace Throwing_Self.Assets.New_Scripts
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D body;
        [SerializeField] private float force;

        private bool isOnJumpArea;

        private Vector2 ComputeDirection()
        {
            var mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var ballPosition = (Vector2)transform.position;

            return (mousePosition - ballPosition).normalized;
        }

        private void Update()
        {

            if (Input.GetMouseButtonDown(0) && isOnJumpArea == true)
            {
                body.isKinematic = false;
                body.velocity = Vector2.zero;
                body.AddForce(ComputeDirection() * force, ForceMode2D.Impulse);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Goal")) {
                GameManager.Notify(new Victory());
            } 

            if(other.CompareTag("Point")) {
                isOnJumpArea = true;
                
            }

            if(other.CompareTag("Harmful")) {
                GameManager.Notify(new Defeat());
            }

            body.velocity = body.velocity / 3;
            body.gravityScale = body.gravityScale / 3;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            isOnJumpArea = false;
            body.gravityScale = body.gravityScale * 3;
        }
    }
}