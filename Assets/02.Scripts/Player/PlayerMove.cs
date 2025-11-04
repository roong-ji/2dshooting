using UnityEngine;
using UnityEngine.InputSystem.Controls;

// 플레이어 이동
public class PlayerMove : MonoBehaviour
{
    private Camera _mainCamera;

    [Header("이동 범위")]
    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxY;
    [SerializeField] private float _minY;

    [Header("이동 속도")]
    public float Speed;
    [SerializeField] private float _originSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _speedAcceleration;
    [SerializeField] private float _speedIncrement;

    [Header("이동 방향")]
    private Vector2 _direction;
    private Vector2 _newPosition;
    private Vector2 _position;
    private Vector2 _originPosition;

    private void Start()
    {
        _mainCamera = Camera.main;
        _originPosition = transform.position;
    }

    private void Update()
    {
        GetSpeed();
        Move();
        Inside();
    }

    private void FixedUpdate()
    {
        
    }

    private void GetSpeed()
    {
        // Q , E 키로 속도 조절, Shift 키로 가속
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _originSpeed += _speedIncrement;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _originSpeed -= _speedIncrement;
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Speed = _originSpeed * _speedAcceleration;
        }
        else Speed = _originSpeed;
        Speed = Mathf.Clamp(Speed, _minSpeed, _maxSpeed);


    }

    // 키보드 입력에 따라 방향을 구하고 그 방향으로 이동
    private void Move()
    {
        // 1, 키보드 입력을 감지한다.
        //float h = Input.GetAxisRaw("Horizontal");  // 수평 입력에 대한 값을 -1 ~ 1 로 가져온다.
        // float v = Input.GetAxisRaw("Vertical");    // 수직 입력에 대한 값을 -1 ~ 1 로 가져온다.

        // 2, 입력으로부터 방향을 구한다.
        //Vector2 direction = new Vector2(h, v);

        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");

        // 대각선으로 이동할 경우 속도가 빨라지는 것을 방지하기 위해 방향 벡터의 크기를 1로 정규화
        _direction.Normalize();

        // 3. 구한 방향으로 이동한다.
        _position = transform.position;


        // R 키를 누르면 원래 위치로 돌아감
        // Translate를 사용하면 간단하지만 정밀도 떨어짐
        if (Input.GetKey(KeyCode.R))
        {
            transform.Translate((_originPosition - _position) * Speed * Time.deltaTime);
        }

        // 새로운 위치 = 현재 위치 +     속도      * 시간
        // 새로운 위치 = 현재 위치 + (방향 * 속력) * 시간
        else
        {
            _newPosition = _position + _direction * Speed * Time.deltaTime;
            transform.position = _newPosition;
        }
    }

    private void Inside()
    {
        // 화면 밖으로 나가지 않도록 위치 제한
        Vector3 viewPos = _mainCamera.WorldToViewportPoint(transform.position);
        if (viewPos.x < _minX) viewPos.x = _maxX;
        if (viewPos.x > _maxX) viewPos.x = _minX;
        viewPos.y = Mathf.Clamp(viewPos.y, _minY, _maxY);
        transform.position = _mainCamera.ViewportToWorldPoint(viewPos);
    }

}
