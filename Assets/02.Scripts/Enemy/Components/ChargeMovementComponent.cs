using UnityEngine;

public class ChargeMovementComponent : KnockbackComponent
{
    protected override void Move()
    {
        _rigidbody2D.linearVelocity = _direction * _speed;
        KnockbackMove();
    }
}
