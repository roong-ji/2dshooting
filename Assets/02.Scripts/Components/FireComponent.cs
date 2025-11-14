using UnityEngine;

public abstract class FireComponent : MonoBehaviour
{
    [Header("발사 위치")]
    [SerializeField] protected Transform[] _firePosition;

    protected float _timer = 0f;

    [Header("공격 속도")]
    [Tooltip("1초당 공격 횟수")]
    [SerializeField] protected float _fireSpeed;

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
