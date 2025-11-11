using UnityEngine;

public class EnemyFireComponent : FireComponent
{

    protected override void Fire()
    {
        if (_timer < 1f / _fireSpeed) return;

        if (_firePositionLeft == null || _firePositionRight == null) return;

        Instantiate(_bulletPrefab[_bulletType], _firePositionLeft.position, _leftRotation);
        Instantiate(_bulletPrefab[_bulletType], _firePositionRight.position, _rightRotation);

        _timer = 0f;
    }
}
