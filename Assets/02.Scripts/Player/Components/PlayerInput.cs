using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerAutoMove _playerAutoMove;
    private PlayerMovementComponent _playerMovementComponent;
    private PlayerFireComponent _playerFireComponent;

    private Animator _animator;

    [Header("조이 스틱")]
    [SerializeField] private Joystick _joystick;

    private Camera _mainCamera;

    [Header("가동 범위")]
    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxY;
    [SerializeField] private float _minY;

    private bool _autoMode = false;

    private void Awake()
    {
        _playerAutoMove = GetComponent<PlayerAutoMove>();
        _playerMovementComponent = GetComponent<PlayerMovementComponent>();
        _playerFireComponent = GetComponent<PlayerFireComponent>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _mainCamera = Camera.main;
        _maxX = 1f;
        _minX = 0f;
        _maxY = 0.5f;
        _minY = 0f;
    }


    private void Update()
    {
        GetInput();
    }

    private void LateUpdate()
    {
        Inside();
    }

    private void GetInput()
    {
        Vector2 direction;

        // 자동 전투
        if (_autoMode == true)
        {
            direction = _playerAutoMove.GetMoveDirection();
            _playerMovementComponent.SetMoveDirection(direction);
        }

        // 수동 입력 감지
        else
        {
            direction.x = _joystick.Horizontal;
            direction.y = _joystick.Vertical;

            _playerMovementComponent.SetMoveDirection(direction.normalized);
        }

        _playerFireComponent.ExecuteFire();

        // 애니메이션
        _animator.SetInteger("x", Mathf.RoundToInt(direction.x));

    }

    public void ToggleAutoMode()
    {
        _autoMode = !_autoMode;
        _playerAutoMove.StartDetect(_autoMode);
    }

    private void Inside()
    {
        // 화면 밖으로 나가지 않도록 위치 제한
        Vector3 viewPos = _mainCamera.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp(viewPos.x, _minX, _maxX);
        viewPos.y = Mathf.Clamp(viewPos.y, _minY, _maxY);
        transform.position = _mainCamera.ViewportToWorldPoint(viewPos);
    }
}
