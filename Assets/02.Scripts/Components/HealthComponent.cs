using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private ItemDropComponent _dropComponent;

    [Header("체력")]
    [SerializeField] private float _health;

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health > 0f) return;
        Destroy(gameObject);

        if (_dropComponent == null) return;
        _dropComponent.DropItem();
    }

    public void Heal(float amount)
    {
        _health += amount;
    }

}
