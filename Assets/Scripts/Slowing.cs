using UnityEngine;
using System;

public class Slowing : MonoBehaviour
{
    public static event Action OnEnter;

    [SerializeField] new private Rigidbody2D rigidbody2D;
    [SerializeField] private float slowValue;

    private Vector2 lastVelocity;
    private float lastGravityScale;

    private bool HadChangesOnDirection()
    {
        return lastVelocity.normalized != rigidbody2D.velocity.normalized;
    }

    private void RememberLastVelocity()
    {
        lastVelocity = rigidbody2D.velocity;
    }

    private void RememberLastGravityScale()
    {
        lastGravityScale = rigidbody2D.gravityScale;
    }

    private void ToDownSpeed()
    {
        rigidbody2D.velocity *= slowValue;
        rigidbody2D.gravityScale *= slowValue;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnEnter?.Invoke();

        RememberLastVelocity();
        RememberLastGravityScale();
        ToDownSpeed();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        rigidbody2D.gravityScale = lastGravityScale;

        if (HadChangesOnDirection())
        {
            return;
        }

        rigidbody2D.velocity = lastVelocity;
    }
}
