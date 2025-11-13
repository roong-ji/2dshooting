using UnityEngine;

public class EnemyFireComponent : FireComponent
{
    protected override void Fire()
    {
        if (_timer < 1f / _fireSpeed) return;

        if(_firePosition == null) return;

        BulletFactory.Instance.MakeBullet(_bulletTypes[0], _firePosition[0].position, Quaternion.identity);
        BulletFactory.Instance.MakeBullet(_bulletTypes[0], _firePosition[1].position, Quaternion.identity);

        _timer = 0f;
    }
}
