using UnityEngine;

public class Impulse : MonoBehaviour
{
    [SerializeField] new private Rigidbody2D rigidbody2D;
    [SerializeField] private float throwingForce;

    private bool canImpulse = true;

    private IDirectionProvider directionProvider;

    private void ReloadImpulse()
    {
        canImpulse = true;
    }

    private bool MustThrowSelf()
    {
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

    private void StartSimulation () {
        rigidbody2D.simulated = true;
    }

    private void StopSimulation () {
        rigidbody2D.simulated = false;
    }

    private void Awake()
    {
        TryGetComponent(out directionProvider);

        Point.OnPlayerEnter += ReloadImpulse;
        Defeat.OnDefeat += StopSimulation;
    }

    private void Update()
    {
        if (MustThrowSelf())
        {
            if(canImpulse == false) {
                return;
            }

            if(rigidbody2D.simulated == false) {
                StartSimulation();
            }

            
            ResetForces();
            Throw();
        }
    }
}
