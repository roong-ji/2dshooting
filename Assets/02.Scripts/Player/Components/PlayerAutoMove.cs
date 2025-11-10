using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoMove : MovementComponent
{

    private Transform _closestEnemy;
    private float _closestEnemyDistance = 100f;
    private float _distance = 2f;

    protected override void Move()
    {
        if (_closestEnemy == null) return;

        // 가장 가까운 적 오브젝트를 찾아가서 일정 거리 유지하며 공격

        // x축은 쫓아가기, y축은 일정 거리
        _direction = (Vector2)(_closestEnemy.position - transform.position);

        _direction.y = _direction.y < _distance ? -1 : _direction.y;

        _rigidbody2D.linearVelocity = _direction.normalized * _speed;

    }
    public override void MoveSpeedup(float amount)
    {
        _speed += amount;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") == false) return;

        float distance = (transform.position - collision.transform.position).sqrMagnitude;

        if (distance < _closestEnemyDistance)
        {
            _closestEnemyDistance = distance;
            _closestEnemy = collision.transform;
        }
    } 

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") == false) return;
        if (collision.transform != _closestEnemy) return;

        _closestEnemyDistance = 100f;
        _closestEnemy = null;
    }


}
