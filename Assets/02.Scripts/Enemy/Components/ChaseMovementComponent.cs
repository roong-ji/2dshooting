using UnityEngine;

public class ChaseMovementComponent : EnemyMovementComponent
{
    [SerializeField] private Transform _playerTransform;
    private Vector2 _directionToPlayer;

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
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(_directionToPlayer.y, _directionToPlayer.x) * Mathf.Rad2Deg);

        // 설정된 방향으로 이동
        _direction = transform.right;
        _rigidbody2D.linearVelocity = _direction * _speed;
    }
    protected override void KnockbackMove()
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
}
