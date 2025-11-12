using UnityEngine;
using UnityEngine.UIElements;

public class PlayerFireComponent : FireComponent
{
    [Header("사운드")]
    [SerializeField] private AudioSource _fireSound;

    private bool _fireRequested = false;

    // 1초에 n 번 공격하려면 1/n초에 한번 공격해야함
    protected override void Fire()
    {
        // 커맨드 입력 체크
        if (_fireRequested == false) return;
        _fireRequested = false;

        // 발사 쿨타임 체크
        if (1f / _fireSpeed > _timer) return;

        // 총알 발사
        Instantiate(_bulletPrefab[_bulletType], _firePositionLeft.position, _leftRotation);
        Instantiate(_bulletPrefab[_bulletType], _firePositionRight.position, _rightRotation);

        // 사운드 재생
        _fireSound.Play();

        // 다음 총알 장전
        _bulletType = ++_bulletType % _typeNumber;
        _timer = 0f;
    }

    public void ExecuteFire()
    {
        _fireRequested = true;
    }

}
