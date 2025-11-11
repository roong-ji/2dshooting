using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private ItemDropper _itemDropper;

    [Header("체력")]
    [SerializeField] private float _health;

    private ParticleComponent _particleComponent;

    private void Awake()
    {
        _particleComponent = GetComponent<ParticleComponent>();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health > 0f) return;
        MakeExplosionEffect();
        DropItem();
        Destroy(gameObject);
        
    }

    private void MakeExplosionEffect()
    {
        _particleComponent.PlayParticleEffect(transform);
    }

    private void DropItem()
    {

        if (_itemDropper == null) return;
        _itemDropper.DropItem(transform.position);
    }

    public void Heal(float amount)
    {
        _health += amount;
    }

}
