using UnityEngine;

public abstract class FireComponent : MonoBehaviour
{
    [Header("발사 위치")]
    [SerializeField] protected Transform[] _firePosition;
    [SerializeField] protected Quaternion[] _fireRotation;

    protected float _timer = 0f;

    [Header("공격 속도")]
    [Tooltip("1초당 공격 횟수")]
    [SerializeField] protected float _fireSpeed;

    [Header("총알 종류")]
    [SerializeField] protected EBulletType[] _bulletTypes;

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
