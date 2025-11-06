using UnityEngine;

public class FireComponent : MonoBehaviour
{
    [Header("총알 프리팹")]
    [SerializeField] private GameObject _bulletPrefab;

    [Header("발사 위치")]
    [SerializeField] private Transform _firePositionLeft;
    [SerializeField] private Transform _firePositionRight;

    [SerializeField] private Quaternion _leftRotation;
    [SerializeField] private Quaternion _rightRotation;

    private float _timer = 0f;

    [Header("공격 속도")]
    [SerializeField] private float _fireRate;

    private void Update()
    {
        _timer += Time.deltaTime;
        Fire();
    }
    private void Fire()
    {
        if(_timer < _fireRate) return;

        Instantiate(_bulletPrefab, _firePositionLeft.position, _leftRotation);
        Instantiate(_bulletPrefab, _firePositionRight.position, _rightRotation);

        _timer = 0f;
    }
}
