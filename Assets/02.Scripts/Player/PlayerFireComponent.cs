using UnityEngine;
using UnityEngine.UIElements;

// 스페이스바를 누르면 총알을 만들어서 발사
public class PlayerFireComponent : FireComponent
{
    private bool _autoFire = true;

    // 1초에 n 번 공격하려면 1/n초에 한번 공격해야함
    protected override void Fire()
    {
        InputMode();

        // 1. 발사 버튼을 누르면
        if ((_autoFire || Input.GetKey(KeyCode.Space)) && 1f/_fireSpeed <= _timer)
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
