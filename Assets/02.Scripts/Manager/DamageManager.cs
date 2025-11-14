using UnityEngine;

public class DamageManager : MonoBehaviour
{
    private static DamageManager _instance;
    public static DamageManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    [Header("플레이어 공격력")]
    [SerializeField] private float _damage;
    [SerializeField] private float _damageIncrease;
    public float Damage => _damage;

    public void PowerUp()
    {
        _damage += _damageIncrease;
    }

}
