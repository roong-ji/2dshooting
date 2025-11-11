using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private ItemDropper _itemDropper;

    [Header("체력")]
    [SerializeField] private float _health;

    [Header("폭팔 프리팹")]
    [SerializeField] private GameObject _explosionPrefab;

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health > 0f) return;
        Destroy(gameObject);
        MakeExploisionEffect();
        DropItem();
    }

    private void MakeExploisionEffect()
    {
        if (_explosionPrefab == null) return;
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
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
