using UnityEngine;

public class BossFireComponent : FireComponent
{
    [Header("총알 종류")]
    [SerializeField] private EBulletType _bulletType;

    [Header("설정")]
    [SerializeField] private float _fireCount;
    [SerializeField] private float _currentCount;
    [SerializeField] private float[] _startRotation;
    [SerializeField] private float[] _endRotation;

    protected override void Fire()
    {
        if (_timer < 1f / _fireSpeed) return;

        for (int i = 0; i < _firePosition.Length; ++i)
        {
            _firePosition[i].rotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(_startRotation[i], _endRotation[i], Mathf.PingPong(++_currentCount / _fireCount, 1f)));
            BulletFactory.Instance.MakeBullet(_bulletType, _firePosition[i]);
        }

        _timer = 0f;
    }
}
