using UnityEngine;

public abstract class KnockbackComponent : MovementComponent
{
    [Header("넉백 시간")]
    [SerializeField] private float _knockbackDuration;
    [SerializeField] private float _knockbackForce;
    private bool _isKnockback;
    private float _timer;

    [Header("초기값 설정")]
    [SerializeField] private float _originSpeed;
    [SerializeField] private Vector2 _originDirection;

    protected override void Init()
    {
        _isKnockback = false;
        _timer = 0f;
        _speed = _originSpeed;
        _direction = _originDirection;
    }

    protected void KnockbackMove()
    {
        if (_isKnockback == false) return;

        _timer += Time.fixedDeltaTime;

        if (_timer >= _knockbackDuration)
        {
            _isKnockback = false;
            _direction = _originDirection;
            return;
        }

        _speed = Mathf.Lerp(_speed, _originSpeed, _timer / _knockbackDuration);
    }

    public void Knockback()
    {
        _timer = 0f;
        _isKnockback = true;
        _speed = _originSpeed * _knockbackForce;
    }
}
