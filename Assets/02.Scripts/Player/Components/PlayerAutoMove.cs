using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{

    private Transform _closestEnemy;
    private float _closestEnemyDistance = 100f;
    private float _distance = 2f;

    public Vector2 GetMoveDirection()
    {
        if (_closestEnemy == null) return Vector2.zero;

        // 가장 가까운 적 오브젝트를 찾아가서 일정 거리 유지하며 공격

        // x축은 쫓아가기, y축은 일정 거리 유지 하기
        Vector2 direction = (Vector2)(_closestEnemy.position - transform.position);

        direction.y = direction.y < _distance ? -1 : direction.y;

        return direction.normalized;

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

    // 가장 가까운 적을 찾는다.
    // 해당 적의 방향으로 이동한다.
    // 만약 거리가 너무 가깝다면, y축은 아래로 이동한다.

}
