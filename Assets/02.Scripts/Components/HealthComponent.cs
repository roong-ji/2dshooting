using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [Header("체력")]
    [SerializeField] protected float _health;

    private ParticleComponent _particleComponent;
    protected SoundManager _soundManager;

    private void Awake()
    {
        _particleComponent = GetComponent<ParticleComponent>();
    }

    public virtual void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health > 0f) return;
        MakeExplosionEffect();
        PlayDeathSound();
        Destroy(gameObject);
        
    }

    protected void MakeExplosionEffect()
    {
        if(_particleComponent ==null) return;
        _particleComponent.PlayParticleEffect();
    }
    protected virtual void PlayDeathSound()
    {
        _soundManager = FindAnyObjectByType<SoundManager>();
        if (_soundManager == null) return;
        _soundManager.PlayGameOverSound();
    }

    public void Heal(float amount)
    {
        _health += amount;
    }

}
