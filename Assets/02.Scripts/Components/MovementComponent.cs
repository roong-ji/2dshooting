using UnityEditor.UIElements;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class MovementComponent : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rigidbody2D;

    [Header("이동 속도")]
    [SerializeField] protected float _speed;

    [Header("이동 방향")]
    [SerializeField] protected Vector2 _direction;

    private void FixedUpdate()
    {
        Move();
    }

    protected abstract void Move();

    public virtual void Knockback() { }

}
