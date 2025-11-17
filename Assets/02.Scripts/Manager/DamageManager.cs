using UnityEngine;
using UnityEngine.UI;

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

    [Header("공격력 UI")]
    [SerializeField] private Text _damageTextUI;

    public float Damage => _damage;

    [Header("파워업 비용")]
    [SerializeField] private int _socreCost;

    private void Start()
    {
        UpdateDamageUI();
    }

    public void InitDamage(float damage)
    {
        _damage = damage;
    }

    public void PowerUp()
    {
        if (ScoreManager.Instance.CurrentScore < _socreCost) return;
        ScoreManager.Instance.PayScore(_socreCost);
        _damage += _damageIncrease;

        UpdateDamageUI();
    }

    private void UpdateDamageUI()
    {
        _damageTextUI.text = _damage.ToString();
    }

}
