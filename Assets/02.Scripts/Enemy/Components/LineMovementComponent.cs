using UnityEngine;

public class LineMovementComponent : MovementComponent
{
    protected override void Init() { }

    protected override void Move()
    {
        _rigidbody2D.linearVelocity = transform.up * _speed;
    }
 }
