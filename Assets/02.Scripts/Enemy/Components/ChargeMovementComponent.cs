using UnityEngine;

public class ChargeMovementComponent : EnemyMovementComponent
{
    private void Start()
    {
        _direction = Vector2.down;
    }

    protected override void Move()
    {
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
            _direction = Vector2.down;
            return;
        }

        _rigidbody2D.linearVelocityY = Mathf.Lerp(_rigidbody2D.linearVelocityY, 0, _timer / _knockbackDuration);
    }

}
