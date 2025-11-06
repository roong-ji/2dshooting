using UnityEngine;

public class EvadeMovementComponent : EnemyMovementComponent
{
    [SerializeField] private LayerMask _playerBulletLayer;
    [SerializeField] private float _evadeDistance;
    [SerializeField] private Vector2[] _evadeVector;
    private float _directionRate = 0.5f;

    protected override void Move()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Direction, _evadeDistance, _playerBulletLayer);

        if(hit) Evade();

        _rigidbody2D.linearVelocity = Direction * Speed;
    }

    private void Evade()
    {
        _isKnockback = true;
        Direction = Random.value > _directionRate ? _evadeVector[0] : _evadeVector[1];
    }

}
