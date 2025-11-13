using UnityEngine;
using System.Collections.Generic;

public class FollowTargetComponent : MonoBehaviour
{
    [Header("타겟 정보")]
    [SerializeField] private Transform _targetTransform;
    private Queue<Vector2> _targetPositions;
    
    private Vector2 _lastPosition;
    private Vector2 _currentPosition;
    private Vector2 _nextPosition;

    [Header("펫 이동 딜레이")]
    [SerializeField] private int _followDelay;
    [SerializeField] private float _followSpeed;

    private void Awake()
    {
        _targetPositions = new Queue<Vector2>();
    }

    private void Update()
    {
        RecordTargetPosition();
        FollowTarget();
    }

    private void RecordTargetPosition()
    {
        // 타겟이 움직이고 있다면 현재 위치 기록
        _currentPosition = _targetTransform.position;
        if (_currentPosition == _lastPosition) return;

        _targetPositions.Enqueue(_currentPosition);
        _lastPosition = _currentPosition;

        SetTargetPosition();
    }

    private void SetTargetPosition()
    {
        // 딜레이 프레임이 지났다면 타겟 위치 추적
        if (_targetPositions.Count > _followDelay)
        {
            _nextPosition = _targetPositions.Dequeue();
        }
        else
        {
            _nextPosition = _targetTransform.position;
        }
    }

    private void FollowTarget()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            _nextPosition,
            _followSpeed * Time.deltaTime
            );
    }



}
