using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private ItemDropper _itemDropper;

    [Header("체력")]
    [SerializeField] private float _health;

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health > 0f) return;
        Destroy(gameObject);

        if (_itemDropper == null) return;
        _itemDropper.DropItem(transform.position);
    }

    public void Heal(float amount)
    {
        _health += amount;
    }

}
