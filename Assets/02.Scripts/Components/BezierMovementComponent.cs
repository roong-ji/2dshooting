using UnityEngine;

public class BezierMovementComponent : MovementComponent
{

    [Header("대기 시간")]
    [SerializeField] private float _invokeTime;
    [SerializeField] private float _duration;

    [Header("휘어짐 정도")]
    [SerializeField] private float _curveHeight;

    private Vector2 _startPoint;
    private Vector2 _targetPoint;
    private Vector2 _controllPoint;

    private Transform _playerTransform;
    private float _timer;
    private float _squareTime;

    private void Start()
    {
        _timer = -_invokeTime;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;
        _playerTransform = player.transform;

        _startPoint = transform.position;
        _targetPoint = _playerTransform.position;

        _controllPoint = _targetPoint;
        _controllPoint.x += _curveHeight;
    }

    protected override void Move()
    {
        _timer += Time.fixedDeltaTime;
        if (_timer < 0) return;

        _squareTime = _timer / _duration;

        _targetPoint = _playerTransform.position;

        Vector2 a = Vector2.Lerp(_startPoint, _controllPoint, _squareTime);
        Vector2 b = Vector2.Lerp(_controllPoint, _targetPoint, _squareTime);

        Vector2 c = Vector2.Lerp(a, b, _squareTime);

        _direction = c - (Vector2)transform.position;

        _rigidbody2D.linearVelocity = _direction / Time.fixedDeltaTime;
    }
}
