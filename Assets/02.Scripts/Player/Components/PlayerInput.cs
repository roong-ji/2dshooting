using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerAutoMove _playerAutoMove;
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private PlayerFireComponent _playerFireComponent;
    [SerializeField] private GameObject _detectZone;

    private Camera _mainCamera;

    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxY;
    [SerializeField] private float _minY;

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
        InputMode();
    }

    private void LateUpdate()
    {
        Inside();
    }

    private void InputMode()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            // 자동 모드
            _playerFireComponent._autoFire = true;
            _playerAutoMove.enabled = true;
            _playerMove.enabled = false;
            _detectZone.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            // 조작 모드
            _playerFireComponent._autoFire = false;
            _playerAutoMove.enabled = false;
            _playerMove.enabled = true;
            _detectZone.SetActive(false);
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
