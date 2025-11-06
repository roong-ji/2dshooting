using UnityEngine;

public class EvadeMovementComponent : EnemyMovementComponent
{
    [SerializeField] private LayerMask _playerBulletLayer;
    [SerializeField] private float _evadeDistance;
    [SerializeField] private Vector2[] _evadeVector;
    private float _directionRate = 0.5f;

    protected override void Move()
    {
        // 플레이어의 총알이 일정 거리 내에 있으면 회피 동작 수행
        if (Physics2D.Raycast(transform.position, _direction, _evadeDistance, _playerBulletLayer)) Evade();

        _rigidbody2D.linearVelocity = _direction * _speed;
    }

    private void Evade()
    {
        _isKnockback = true;
        _direction = Random.value > _directionRate ? _evadeVector[0] : _evadeVector[1];
    }
    protected override void KnockbackMove()
    {
        if (_isKnockback == false) return;

        _timer += Time.fixedDeltaTime;

        if (_timer >= _knockbackDuration)
        {
            _isKnockback = false;
            _timer = 0f;
            _direction = Vector2.down;
            return;
        }

        _direction = Vector2.Lerp(_direction, Vector2.zero, _timer / _knockbackDuration);
    }

}
