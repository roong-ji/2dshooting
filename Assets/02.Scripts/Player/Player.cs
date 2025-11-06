using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("플레이어 체력")]
    [SerializeField] private float _health;

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
