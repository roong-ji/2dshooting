using UnityEngine;

public class EvadeMovementComponent : KnockbackComponent
{
    [SerializeField] private LayerMask _playerBulletLayer;
    [SerializeField] private float _evadeDistance;
    [SerializeField] private float _evadeForce;

    protected override void Move()
    {
        // 플레이어의 총알이 일정 거리 내에 있으면 회피 동작 수행
        if (Physics2D.Raycast(transform.position, _direction, _evadeDistance, _playerBulletLayer)) Evade();
        KnockbackMove();

        _rigidbody2D.linearVelocity = _direction * _speed;
    }

    private void Evade()
    {
        Knockback();
        _direction = Random.insideUnitCircle.normalized * _evadeForce;
    }
}
