using UnityEngine;

public class BossMovementComponent : MovementComponent
{
    [Header("최종 위치")]
    [SerializeField] private Vector2 _finalPosition;

    private bool _endMove;

    protected override void Init() 
    {
        _direction = Vector2.zero;
        _endMove = false;
    }

    protected override void Move()
    {
        if (_endMove == true) return;

        _direction = _finalPosition - (Vector2)transform.position;
        _rigidbody2D.linearVelocity = _direction * _speed;

        if (_direction == Vector2.zero)
        {
            _endMove = true;
        }
    }
}
