using UnityEngine;

public class ChargeMovementComponent : MovementComponent
{
    private float _timer = 0f;
    private float _knockbackDuration = 0.5f;
    private bool _isKnockback = false;

    protected override void Move()
    {
        _rigidbody2D.linearVelocity = _direction * _speed;
        KnockbackMove();
    }

    private void KnockbackMove()
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

    public override void Knockback()
    {
        _isKnockback = true;
        _direction = -_direction;
    }

}
