using UnityEngine;
using System;

public class Slowing : MonoBehaviour
{
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

    private void Awake()
    {
        Point.OnPlayerEnter += RememberLastVelocity;
        Point.OnPlayerEnter += RememberLastGravityScale;
        Point.OnPlayerEnter += ToDownSpeed;

        Point.OnPlayerExit += () => rigidbody2D.gravityScale = lastGravityScale;

        Point.OnPlayerExit += () =>
        {
            if (!HadChangesOnDirection())
            {
                rigidbody2D.velocity = lastVelocity;
            }
        };
    }

}
