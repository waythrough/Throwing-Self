using UnityEngine;

public class Impulse : MonoBehaviour
{
    [SerializeField] new private Rigidbody2D rigidbody2D;
    [SerializeField] private float throwingForce;

    private bool canImpulse = false;

    private IDirectionProvider directionProvider;

    private void ReloadImpulse()
    {
        canImpulse = true;
    }

    private bool MustThrowSelf()
    {
        if (canImpulse == false)
        {
            return false;
        }

        return Input.GetMouseButtonDown(0);
    }

    private void ResetForces()
    {
        rigidbody2D.velocity = Vector2.zero;
    }

    private void Throw()
    {
        rigidbody2D.AddForce(directionProvider.GetDirection() * throwingForce, ForceMode2D.Impulse);
        canImpulse = false;
    }

    private void Awake()
    {
        TryGetComponent(out directionProvider);
        Slowing.OnEnter += ReloadImpulse;
    }

    private void Update()
    {
        if (MustThrowSelf())
        {
            ResetForces();
            Throw();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.collider.CompareTag("Ground")) {
            return;
        }
        ReloadImpulse();
    }
}
