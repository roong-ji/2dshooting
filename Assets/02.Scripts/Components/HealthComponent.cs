using UnityEngine;

public abstract class HealthComponent : MonoBehaviour
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
    protected abstract void InitHealth();

    public abstract void TakeDamage(float damage);

    public abstract void Death();

    protected abstract void PlayDeathSound();

    protected void MakeExplosionEffect()
    {
        if(_particleComponent ==null) return;
        _particleComponent.PlayParticleEffect();
    }

}
