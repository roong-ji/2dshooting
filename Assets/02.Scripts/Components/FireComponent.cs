using UnityEngine;

public abstract class FireComponent : MonoBehaviour
{
    [Header("총알 프리팹")]
    [SerializeField] protected GameObject[] _bulletPrefab;

    [Header("발사 위치")]
    [SerializeField] protected Transform _firePositionLeft;
    [SerializeField] protected Transform _firePositionRight;

    [SerializeField] protected Quaternion _leftRotation;
    [SerializeField] protected Quaternion _rightRotation;

    protected float _timer = 0f;

    [Header("공격 속도")]
    [Tooltip("1초당 공격 횟수")]
    [SerializeField] protected float _fireSpeed;

    protected int _bulletType; // 현재 총알 종류
    protected int _typeNumber; // 총알 종류 개수

    private void Start()
    {
        _bulletType = 0;
        _typeNumber = _bulletPrefab.Length;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        Fire();
    }

    protected abstract void Fire();

    public void FireSpeedup(float amount)
    {
        _fireSpeed += amount;
    }
}
