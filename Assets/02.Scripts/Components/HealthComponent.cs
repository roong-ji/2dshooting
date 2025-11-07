using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [Header("체력")]
    [SerializeField] private float _health;

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(float amount)
    {
        _health += amount;
    }

}
