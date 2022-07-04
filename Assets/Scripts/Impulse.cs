using UnityEngine;

public class Impulse : MonoBehaviour
{
    [SerializeField] new private Rigidbody2D rigidbody2D;
    [SerializeField] private float throwingForce;

    private IDirectionProvider directionProvider;

    private bool MustThrowSelf()
    {
        return Input.GetMouseButtonDown(0);
    }

    private void ResetForces () {
        rigidbody2D.velocity = Vector2.zero;
    }

    private void Throw()
    {
        rigidbody2D.AddForce(directionProvider.GetDirection() * throwingForce, ForceMode2D.Impulse);
    }

    private void Awake()
    {
        TryGetComponent(out directionProvider);
    }

    private void Update()
    {
        if (MustThrowSelf())
        {
            ResetForces();
            Throw();
        }
    }
}
