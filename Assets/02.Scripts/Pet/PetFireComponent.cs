using UnityEngine;

public class PetFireComponent : FireComponent
{
    [Header("총알 종류")]
    [SerializeField] private EBulletType _bulletType;

    protected override void Fire()
    {
        if (_timer < 1f / _fireSpeed) return;
        BulletFactory.Instance.MakeBullet(_bulletType, transform.position, Quaternion.identity);
        _timer = 0f;
    }
}
