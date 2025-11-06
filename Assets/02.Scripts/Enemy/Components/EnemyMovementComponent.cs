using UnityEditor.UIElements;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EnemyMovementComponent : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rigidbody2D;

    [Header("이동 속도")]
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _direction;

    private float _timer = 0f;
    private float _knockbackDuration = 0.5f;
    protected bool _isKnockback = false;

    private void FixedUpdate()
    {
        Move();

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

    protected abstract void Move();

    public void Knockback()
    {
        _isKnockback = true;
        _direction = -_direction;
    }

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public Vector2 Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

}
