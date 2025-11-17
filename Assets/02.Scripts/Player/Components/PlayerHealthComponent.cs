using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthComponent : HealthComponent
{
    [Header("체력 UI")]
    [SerializeField] private Image _healthUI;
    [SerializeField] private Text _healthTextUI;
    private float _healthRate;

    protected override void InitHealth()
    {
        _health = _maxHealth;
        _healthRate = _health / _maxHealth;
    }

    public override void TakeDamage(float damage)
    {
        _health -= damage;
        UpdateHealthUI();

        if (_health > 0f) return;
        Death();
    }

    public override void Death()
    {
        MakeExplosionEffect();
        PlayDeathSound();
        gameObject.SetActive(false);
    }

    protected override void PlayDeathSound()
    {
        SoundManager.Instance.PlayGameOverSound();
    }

    public void Heal(float amount)
    {
        _health += amount;
        _health = Mathf.Min(_health, _maxHealth);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        _healthTextUI.text = ((int)_health).ToString();

        _healthRate = _health / _maxHealth;
        _healthUI.fillAmount = _healthRate;
    }
}
