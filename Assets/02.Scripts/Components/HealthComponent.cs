using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [Header("체력")]
    [SerializeField] protected float _health;

    private ParticleComponent _particleComponent;

    private void Awake()
    {
        _particleComponent = GetComponent<ParticleComponent>();
    }

    public virtual void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health > 0f) return;
        MakeExplosionEffect();
        Destroy(gameObject);
        
    }

    protected void MakeExplosionEffect()
    {
        if(_particleComponent ==null) return;
        _particleComponent.PlayParticleEffect();
    }

    public void Heal(float amount)
    {
        _health += amount;
    }

}
