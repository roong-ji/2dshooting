using UnityEngine;

public class PetFireComponent : FireComponent
{
    protected override void Fire()
    {
        if (_timer < 1f / _fireSpeed) return;
        BulletFactory.Instance.MakeBullet(_bulletTypes[0], transform.position, Quaternion.identity);
        _timer = 0f;
    }
}
