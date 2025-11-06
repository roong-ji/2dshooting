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
        _directionToPlayer = _playerTransform.position - transform.position;
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(_directionToPlayer.y, _directionToPlayer.x) * Mathf.Rad2Deg);
        Direction = transform.right;
        _rigidbody2D.linearVelocity = Direction * Speed;
    }

}
