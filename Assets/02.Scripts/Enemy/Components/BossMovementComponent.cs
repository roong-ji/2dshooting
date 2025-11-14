using UnityEngine;

public class BossMovementComponent : KnockbackComponent
{
    [Header("최종 위치")]
    [SerializeField] private Vector2 _finalPosition;

    protected override void Init() 
    {
        _direction = Vector2.zero;
    }

    protected override void Move()
    {
        _direction = _finalPosition - (Vector2)transform.position;
        _rigidbody2D.linearVelocity = _direction * _speed;
    }
}
