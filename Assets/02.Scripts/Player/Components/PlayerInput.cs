using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerAutoMove _playerAutoMove;
    private PlayerMovementComponent _playerMovementComponent;
    private PlayerFireComponent _playerFireComponent;
    private BoomSkillComponent _boomSkillComponent;

    private Animator _animator;

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
        _boomSkillComponent = GetComponent<BoomSkillComponent>();
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
        // 자동 모드
        if (Input.GetKeyDown(KeyCode.Alpha1) || 
            Input.GetKeyDown(KeyCode.Keypad1))
        {
            _autoMode = true;
            _playerAutoMove.StartDetect(true);
        }
        // 조작 모드
        if (Input.GetKeyDown(KeyCode.Alpha2) || 
            Input.GetKeyDown(KeyCode.Keypad2))
        {
            _autoMode = false;
            _playerAutoMove.StartDetect(false);
        }

        Vector2 direction;

        // 자동 전투
        if (_autoMode)
        {
            direction = _playerAutoMove.GetMoveDirection();
            _playerMovementComponent.SetMoveDirection(direction);
            _playerFireComponent.ExecuteFire();
        }

        // 수동 입력 감지
        else
        {
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

            if(Input.GetKeyDown(KeyCode.Alpha3) ||
                Input.GetKeyDown(KeyCode.Keypad3))
            {
                _boomSkillComponent.Boom();
            }
        }

        // 애니메이션

        // 방식 1. Play 메서드를 이용한 강제 적용
        //if (direction.x < 0f) _animator.Play("Left");
        //if (direction.x == 0f) _animator.Play("Idle");
        //if (direction.x > 0f) _animator.Play("Right");
        // Fade, Timing, State가 무시되고 어디서 애니메이션을 수정하는지 알 수 없어지게되어 비권장하는 방식

        // 방식 2.
        _animator.SetInteger("x", Mathf.RoundToInt(direction.x));

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
