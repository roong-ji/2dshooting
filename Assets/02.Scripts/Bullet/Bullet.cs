using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    [Header("공격력")]
    [SerializeField] private float _damage;
    [SerializeField] private float _criticalRate;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") == false) return; // 코드를 간결하게 만드는 조기 리턴
        EnemyHitbox enemy = collision.GetComponent<EnemyHitbox>();

        bool critical = Random.value < _criticalRate;
        enemy.TakeDamage(_damage, critical);
        Destroy(gameObject);
    }

}
