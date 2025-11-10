using UnityEngine;

public class ChaseMovementComponent : MovementComponent
{
    private Transform _playerTransform;
    private Vector2 _directionToPlayer;

    private float _timer = 0f;
    private float _knockbackDuration = 0.5f;
    private bool _isKnockback = false;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;
        _playerTransform = player.transform;
    }

    protected override void Move()
    {
        // 플레이어의 위치를 향해 이동 방향 설정
        _directionToPlayer = _playerTransform.position - transform.position;

        // 오브젝트의 회전을 이동 방향에 맞게 설정
        float angle = Vector2.SignedAngle(_direction, _directionToPlayer);
        transform.rotation = Quaternion.Euler(0f, 0f, transform.eulerAngles.z + angle);
        _direction = -transform.up;

        KnockbackMove();
        // 설정된 방향으로 이동
        _rigidbody2D.linearVelocity = _direction * _speed;
    }
    private void KnockbackMove()
    {
        if (_isKnockback == false) return;

        _timer += Time.fixedDeltaTime;

        if (_timer >= _knockbackDuration)
        {
            _isKnockback = false;
            _timer = 0f;
            return;
        }

        _direction = Vector2.Lerp(_direction, Vector2.zero, _timer / _knockbackDuration);
    }
    public override void Knockback()
    {
        _isKnockback = true;
        _direction = -_direction;
    }
}
