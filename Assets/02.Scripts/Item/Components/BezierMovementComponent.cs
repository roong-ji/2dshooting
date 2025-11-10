using UnityEngine;

public class BezierMovementComponent : MovementComponent
{

    [Header("대기 시간")]
    [SerializeField] private float _invokeTime;
    [SerializeField] private float _duration;

    [Header("휘어짐 정도")]
    [SerializeField] private float _curveHeight;
    private float _curveRate = 0.5f;

    private Vector2 _startPoint;
    private Vector2 _targetPoint;
    private Vector2 _controllPoint;

    private Transform _playerTransform;
    private float _timer;
    private float _deltaTime;
    private float _curTime;

    private void Start()
    {
        _timer = -_invokeTime;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;
        _playerTransform = player.transform;

        // 시작 지점과 끝 지점 저장
        _startPoint = transform.position;
        _targetPoint = _playerTransform.position;

        // 중간 제어점 계산
        _controllPoint = _targetPoint;
        _controllPoint.x += Random.value < _curveRate ? _curveHeight : -_curveHeight;
        _controllPoint.y -= _curveHeight;
    }

    protected override void Move()
    {
        _deltaTime = Time.fixedDeltaTime;
        _timer += _deltaTime;
        if (_timer < 0) return;

        // 선형 보간 값 갱신
        _curTime = _timer / _duration;

        // 플레이어 위치 갱신
        _targetPoint = _playerTransform.position;

        // 베지어 곡선 계산
        Vector2 a = Vector2.Lerp(_startPoint, _controllPoint, _curTime);
        Vector2 b = Vector2.Lerp(_controllPoint, _targetPoint, _curTime);

        Vector2 c = Vector2.Lerp(a, b, _curTime);

        _direction = c - (Vector2)transform.position;

        _rigidbody2D.linearVelocity = _direction / _deltaTime;
    }
}
