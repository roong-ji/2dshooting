using UnityEngine;

public class EnemyFireComponent : FireComponent
{
    [Header("총알 종류")]
    [SerializeField] private EBulletType _bulletType;

    protected override void Fire()
    {
        if (_timer < 1f / _fireSpeed) return;

        if(_firePosition == null) return;

        BulletFactory.Instance.MakeBullet(_bulletType, _firePosition[0].position, Quaternion.identity);
        BulletFactory.Instance.MakeBullet(_bulletType, _firePosition[1].position, Quaternion.identity);

        _timer = 0f;
    }
}
