using UnityEngine;
using UnityEngine.UIElements;

public class PlayerFireComponent : FireComponent
{
    private bool _fireRequested = false;

    [Header("총알 종류")]
    [SerializeField] EBulletType[] _bulletType;
    private int _bulletIndex = 0;

    [Header("공격력")]
    [SerializeField] float _damage;

    // 1초에 n 번 공격하려면 1/n초에 한번 공격해야함
    protected override void Fire()
    {
        // 커맨드 입력 체크
        if (_fireRequested == false) return;
        _fireRequested = false;

        // 발사 쿨타임 체크
        if (1f / _fireSpeed > _timer) return;

        // 총알 발사
        foreach (var firePosition in _firePosition)
        {
            if (firePosition == null) return;
            BulletFactory.Instance.MakeBullet(_bulletType[_bulletIndex], firePosition);
        }

        // 다음 총알 장전
        _bulletIndex = ++_bulletIndex % _bulletType.Length;
        _timer = 0f;
    }

    public void ExecuteFire()
    {
        _fireRequested = true;
    }

}
