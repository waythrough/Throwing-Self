using UnityEngine;

public class Slowing : MonoBehaviour
{
    [SerializeField] new private Rigidbody2D rigidbody2D;
    [SerializeField] private float slowValue;

    private Vector2 lastVelocity;

    private bool HadChangesOnDirection () {
        return lastVelocity.normalized != rigidbody2D.velocity.normalized;
    }

    private void RememberLastVelocity () {
        lastVelocity = rigidbody2D.velocity;
    }

    private void ToDownSpeed () {
        rigidbody2D.velocity *= slowValue;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RememberLastVelocity();
        ToDownSpeed();
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(HadChangesOnDirection()) {
            return;
        }
        
        rigidbody2D.velocity = lastVelocity;    
    }
}
