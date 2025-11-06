using UnityEditor.UIElements;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EnemyMovementComponent : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rigidbody2D;

    [Header("이동 속도")]
    [SerializeField] protected float _speed;
    [SerializeField] protected Vector2 _direction;

    protected float _timer = 0f;
    protected float _knockbackDuration = 0.5f;
    protected bool _isKnockback = false;

    private void FixedUpdate()
    {
        Move();
        KnockbackMove();
    }

    protected abstract void Move();

    protected abstract void KnockbackMove();

    public void Knockback()
    {
        _isKnockback = true;
        _direction = -_direction;
    }

}
