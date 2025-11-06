using UnityEngine;
using UnityEngine.UIElements;

public class PlayerFire : MonoBehaviour
{
    // 스페이스바를 누르면 총알을 만들어서 발사

    [Header("총알 프리팹")]
    [SerializeField] private GameObject[] _bulletPrefab;

    [Header("발사 위치")]
    [SerializeField] private Transform _firePositionLeft;
    [SerializeField] private Transform _firePositionRight;

    [SerializeField] private Quaternion _leftRotation;
    [SerializeField] private Quaternion _rightRotation;

    private float _timer = 0f;

    [Header("공격 속도")]
    [SerializeField] private float _fireRate;

    private int _bulletType = 0; // 현재 총알 종류
    private int _typeNumber = 2; // 총알 종류 개수

    private bool _autoFire = true;

    private void Update()
    {
        _timer += Time.deltaTime;

        InputMode();
        Fire();

    }

    private void Fire()
    {
        // 1. 발사 버튼을 누르면
        if ((_autoFire || Input.GetKey(KeyCode.Space)) && _fireRate <= _timer)
        {
            // 2. 총알 프리팹을 복제해서 게임 오브젝트를 생성한다.
            //GameObject bullet = Instantiate(_bulletPrefab);

            // 3. 총알의 위치를 총구 위치로 바꾸기
            //bullet.transform.position = _firePosition[0].transform.position;

            Instantiate(_bulletPrefab[_bulletType], _firePositionLeft.position, _leftRotation);
            Instantiate(_bulletPrefab[_bulletType], _firePositionRight.position, _rightRotation);

            _bulletType = ++_bulletType % _typeNumber;
            _timer = 0f;
        }
    }

    private void InputMode()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            _autoFire = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            _autoFire = false;
        }
    }


}
