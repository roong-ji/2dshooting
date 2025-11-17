using UnityEngine;

public class EnemyFireComponent : FireComponent
{
    [Header("총알 종류")]
    [SerializeField] private EBulletType _bulletType;

    protected override void Fire()
    {
        if (_timer < 1f / _fireSpeed) return;

        foreach (var firePosition in _firePosition)
        {
            if (firePosition == null) return;
            BulletFactory.Instance.MakeBullet(_bulletType, firePosition);
        }

        _timer = 0f;
    }
}