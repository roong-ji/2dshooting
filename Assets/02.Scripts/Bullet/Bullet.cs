using System.Threading;
using Unity.VisualScripting;
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
    [SerializeField] private float _zeroSpeed;

    private float _timer;
    private float _deltaTime;

    [Header("공격력")]
    [SerializeField] private float _damage;
    [SerializeField] private float _criticalRate;

    private Quaternion _originRotation;
    private Quaternion _flipedRotation;
    private float _originAngle;
    private float _flipedAngle;
    private const float _lerpAngle = 180f;

    private void Start()
    {
        //_originRotation = transform.rotation;
        //_flipedRotation = Quaternion.Euler(0f, 0f, transform.eulerAngles.z + 180f);
        _originAngle = transform.rotation.eulerAngles.z;
        _flipedAngle = _originAngle > _lerpAngle ? _originAngle + _lerpAngle : _originAngle - _lerpAngle;
    }

    private void FixedUpdate()
    {
        _deltaTime = Time.deltaTime;
        _timer += _deltaTime;

        Move();

        // 보고 있는 방향으로 이동
        _rigidbody2D.linearVelocity = transform.up * _speed;
    }

    private void Move()
    {
        _timer = Mathf.Min(_timer, _zeroSpeed);

        // 등가속 운동
        _speed = _minSpeed + (_maxSpeed - _minSpeed) * (_timer / _zeroSpeed);

        // 180도 회전 보간
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(_originAngle, _flipedAngle, _timer / _zeroSpeed));
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
        transform.rotation = Quaternion.Lerp(_originRotation, _flipedRotation, _timer / _zeroSpeed);

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
        (_originRotation, _flipedRotation) = (_flipedRotation, _originRotation);
        _timer = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") == false) return; // 코드를 간결하게 만드는 조기 리턴
        EnemyHit enemy = collision.GetComponent<EnemyHit>();

        bool critical = Random.value < _criticalRate;
        enemy.TakeDamage(_damage, critical);
        Destroy(gameObject);
    }

}
