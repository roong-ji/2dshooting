using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Ω∫≈»")]
    public float _health;

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
