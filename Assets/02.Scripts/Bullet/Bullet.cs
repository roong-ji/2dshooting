using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [Header("이동 속도")]
    [SerializeField] private float _speed;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedAcceleration;
    [SerializeField] private float _timer;
    [SerializeField] private float _deltaTime;
    [SerializeField] private float _zeroSpeed;

    private Quaternion _originRoation;
    private Quaternion _flipedRotation;

    private void Start()
    {
        _originRoation = transform.rotation;
        _flipedRotation = Quaternion.Euler(0f, 0f, transform.eulerAngles.z * -1f);
        SetMoveS();
    }

    private void FixedUpdate()
    {
        _deltaTime = Time.deltaTime;
        _timer += _deltaTime;

        MoveS();

        // 보고 있는 방향으로 이동
        _rigidbody2D.linearVelocity = transform.up * _speed;
    }


    private void MoveI()
    {
        _speed = Mathf.Lerp(_minSpeed, _maxSpeed, _timer / _zeroSpeed);
        _speed = _minSpeed + (_maxSpeed - _minSpeed) * (_timer / _zeroSpeed);
        _speed = Mathf.Min(_speed, _maxSpeed);
    }

    private void SetMoveI()
    {
        _minSpeed = 3f;
        _maxSpeed = 8f;
        _zeroSpeed = 1.2f;
        _speed = _minSpeed;
    }

    private void MoveSpiral()
    {
        // 나선형 이동
        _speed += _speedAcceleration * _deltaTime;
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(0f, 360f, _timer / _zeroSpeed % _zeroSpeed));
    }

    private void SetMoveSpiral()
    {
        _speed = 0f;
        _zeroSpeed = 5f;
    }

    private void MoveS()
    {
        // 회전 보간
        transform.rotation = Quaternion.Lerp(_originRoation, _flipedRotation, _timer / _zeroSpeed);

        // 일정 시간마다 방향 전환
        if (_timer >= _zeroSpeed) Filp();

        // 위 두 줄 합친 코드
        //transform.rotation = Quaternion.Lerp(_originRoation, _flipedRotation, Mathf.PingPong(_timer / _zeroSpeed, 1f));
    }

    private void SetMoveS()
    {
        _maxSpeed = 8f;
        _speed = 8f;
        _zeroSpeed = 1.2f;
    }

    private void Filp()
    {
        (_originRoation, _flipedRotation) = (_flipedRotation, _originRoation);
        //_timer = 0f;
    }

}
