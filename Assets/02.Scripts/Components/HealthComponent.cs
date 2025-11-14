using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [Header("체력")]
    [SerializeField] protected float _health;
    [SerializeField] protected float _maxHealth;

    private ParticleComponent _particleComponent;

    private void Awake()
    {
        _particleComponent = GetComponent<ParticleComponent>();
    }

    private void OnEnable()
    {
        InitHealth();
    }

    public virtual void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health > 0f) return;
        MakeExplosionEffect();
        PlayDeathSound();
        gameObject.SetActive(false);
        
    }

    protected void MakeExplosionEffect()
    {
        if(_particleComponent ==null) return;
        _particleComponent.PlayParticleEffect();
    }
    protected virtual void PlayDeathSound()
    {
        SoundManager.Instance.PlayGameOverSound();
    }

    public void Heal(float amount)
    {
        _health += amount;
    }

    protected virtual void InitHealth()
    {
        _health = _maxHealth;
    }

}
