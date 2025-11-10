using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoMove : MovementComponent
{

    private Vector2 _closestEnemyPosition;
    private float _closestEnemyDistance = 100f;
    private float _distance = -2f;

    protected override void Move()
    {
        if (_closestEnemyPosition == Vector2.zero) return;
        // 가장 가까운 적 오브젝트를 찾아가서 일정 거리 유지하며 공격

        // x축은 쫓아가기, y축은 일정 거리
        Vector2 direction = (Vector2)transform.position - _closestEnemyPosition;
        Debug.Log(direction);

        _direction.x = _closestEnemyPosition.x - transform.position.x;

        _direction.y = _direction.y < _distance ? 1 : -1;

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
            _closestEnemyPosition = collision.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") == false) return;

        _closestEnemyDistance = 100f;
        _closestEnemyPosition = Vector2.zero;
    }


}
