using UnityEngine;
using UnityEngine.InputSystem.Controls;

// 플레이어 이동
public class PlayerMovementComponent : MovementComponent
{
    [Header("이동 속도 조작")]
    [SerializeField] private float _finalSpeed;
    [SerializeField] private float _speedAcceleration;

    private Vector2 _originPosition;

    private void Start()
    {
        _originPosition = transform.position;
    }

    public void MoveSpeedup(float amount)
    {
        _speed += amount;
    }

    public void GoFaster()
    {
        _finalSpeed = _speed * _speedAcceleration;
    }

    public void GoNormal()
    {
        _finalSpeed = _speed;
    }

    public void GoOrigin()
    {
        _direction = _originPosition - (Vector2)transform.position;
    }

    public void SetMoveDirection(Vector2 direction)
    {
        _direction = direction;
    }

    protected override void Move()
    {
        _rigidbody2D.linearVelocity = _direction * _finalSpeed;
    }

}
