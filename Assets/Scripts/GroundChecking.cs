using UnityEngine;
using System.Collections.Generic;

public interface IGroundCheckingObserver
{
    void Notify(bool isGrounded);
}

public interface IGroundChecking
{
    void Attach(IGroundCheckingObserver observer);
    void Dettach(IGroundCheckingObserver observer);
}

public class GroundChecking : MonoBehaviour, IGroundChecking
{
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] new private Collider2D collider2D;
    [SerializeField] private float extraHeight;

    private bool isGrounded;

    private List<IGroundCheckingObserver> observers = new List<IGroundCheckingObserver>();

    public void Attach(IGroundCheckingObserver observer)
    {
        if (observers.Contains(observer))
        {
            return;
        }

        observers.Add(observer);
    }

    public void Dettach(IGroundCheckingObserver observer)
    {
        if (!observers.Contains(observer))
        {
            return;
        }

        observers.Remove(observer);
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

    private RaycastHit2D GetRaycastHit2D()
    {
        var origin = transform.position;
        var direction = Vector2.down;
        var distance = (collider2D.bounds.size.y / 2) + extraHeight;
        var layerMask = groundLayerMask;

        var hit = Physics2D.Raycast(origin, direction, distance, layerMask);

        return hit;
    }

    private void Notify () {
        foreach(IGroundCheckingObserver observer in observers) {
            observer?.Notify(isGrounded);
        }
    }

    private void Update()
    {
        var hit = GetRaycastHit2D();

        if (hit.collider == null)
        {
            if(isGrounded == false) {
                return;
            }

            isGrounded = false;
            Notify();
        }

        if (hit.collider != null)
        {
            if(isGrounded == true) {
                return;
            }

            isGrounded = true;
            Notify();
        }
    }
}
