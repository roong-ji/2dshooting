using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoMove : MovementComponent
{
    private Camera _mainCamera;

    [Header("이동 범위")]
    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxY;
    [SerializeField] private float _minY;

    private Vector2 _closestEnemyPosition;
    private float _closestEnemyDistance = 100f;
    private float _distance = -2f;


    private void Start()
    {
        _mainCamera = Camera.main;
    }

    protected override void Move()
    {
        Inside();

        if (_closestEnemyPosition == Vector2.zero) return;
        // 가장 가까운 적 오브젝트를 찾아가서 일정 거리 유지하며 공격

        // x축은 쫓아가기, y축은 일정 거리
        Vector2 direction = (Vector2)transform.position - _closestEnemyPosition;
        Debug.Log(direction);

        _direction.x = _closestEnemyPosition.x - transform.position.x;

        _direction.y = _direction.y < _distance ? 1 : -1;

        _rigidbody2D.linearVelocity = _direction.normalized * _speed;

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

    private void Inside()
    {
        // 화면 밖으로 나가지 않도록 위치 제한
        Vector3 viewPos = _mainCamera.WorldToViewportPoint(transform.position);
        //if (viewPos.x < _minX) viewPos.x = _maxX;
        //if (viewPos.x > _maxX) viewPos.x = _minX;
        viewPos.x = Mathf.Clamp(viewPos.x, _minX, _maxX);
        viewPos.y = Mathf.Clamp(viewPos.y, _minY, _maxY);
        transform.position = _mainCamera.ViewportToWorldPoint(viewPos);
    }

}
