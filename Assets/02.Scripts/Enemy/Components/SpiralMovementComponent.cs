using UnityEngine;

public class SpiralMovementComponent : MovementComponent
{
    [Header("회전 가속도")]
    [SerializeField] private float _speedAcceleration;
    [SerializeField] private float _spiralDuration;
    private float _deltaTime;
    private float _timer;


    protected override void Init()
    {
        _timer = 0f;
        _speed = 0f;
    }

    protected override void Move()
    {
        _deltaTime = Time.deltaTime;
        _timer += _deltaTime;
        _timer %= _spiralDuration;

        // 등가속 운동으로 중심에서 점점 멀어짐
        _speed += _speedAcceleration * _deltaTime;

        // 주기적으로 360도 회전
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(0f, 360f, _timer / _spiralDuration));

        // 나선형 이동 완성
        _rigidbody2D.linearVelocity = -transform.up * _speed;
    }
 }
