using UnityEngine;

public class ChargeMovementComponent : EnemyMovementComponent
{

    private void Start()
    {
        Direction = Vector2.down;
    }

    protected override void Move()
    {
        _rigidbody2D.linearVelocity = Direction * Speed;
    }

}
