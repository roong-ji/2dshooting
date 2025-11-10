using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerAutoMove _playerAutoMove;
    private PlayerMovementComponent _playerMovementComponent;
    private PlayerFireComponent _playerFireComponent;
    [SerializeField] private GameObject _detectZone;

    private Camera _mainCamera;

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
        // 자동 모드
        if (Input.GetKeyDown(KeyCode.Alpha1) || 
            Input.GetKeyDown(KeyCode.Keypad1))
        {
            _autoMode = true;
            _detectZone.SetActive(true);
        }
        // 조작 모드
        if (Input.GetKeyDown(KeyCode.Alpha2) || 
            Input.GetKeyDown(KeyCode.Keypad2))
        {
            _autoMode = false;
            _detectZone.SetActive(false);
        }

        // 자동 전투
        if (_autoMode)
        {
            Vector2 direction = _playerAutoMove.GetMoveDirection();
            _playerMovementComponent.SetMoveDirection(direction);
            _playerFireComponent.ExecuteFire();
        }

        // 수동 입력 감지
        else
        {
            Vector2 direction = Vector2.zero;
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");

            _playerMovementComponent.SetMoveDirection(direction.normalized);

            // R키를 눌러 원점 복귀
            if (Input.GetKey(KeyCode.R))
            {
                _playerMovementComponent.GoOrigin();
            }

            // Shift 키를 누르면 가속
            if (Input.GetKey(KeyCode.LeftShift) ||
                Input.GetKey(KeyCode.RightShift))
            {
                _playerMovementComponent.GoFaster();
            }
            else _playerMovementComponent.GoNormal();


            if (Input.GetKey(KeyCode.Space)) 
            {
                _playerFireComponent.ExecuteFire();
            }
        }

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
