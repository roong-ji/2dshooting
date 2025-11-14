using UnityEngine;
using UnityEngine.InputSystem.Controls;

// 플레이어 이동
public class PlayerMovementComponent : MovementComponent
{
    protected override void Init() { }

    public void MoveSpeedup(float amount)
    {
        _speed += amount;
    }

    public void SetMoveDirection(Vector2 direction)
    {
        _direction = direction;
    }

    protected override void Move()
    {
        _rigidbody2D.linearVelocity = _direction * _speed;
    }

}
