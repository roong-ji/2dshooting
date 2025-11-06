using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{

    [Header("데미지 비율")]
    [SerializeField] private float damageRate;

    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyMovementComponent _enemyMovementComponet;
    public void TakeDamage(float damage, bool critical)
    {
        _enemy.TakeDamage(damage * damageRate);
        if(critical) _enemyMovementComponet.Knockback();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.gameObject.name == "Player") 오타에 취약!!
        if (collision.gameObject.CompareTag("Player") == false) return; // 코드를 간결하게 만드는 조기 리턴
        collision.gameObject.GetComponent<Player>().TakeDamage(1f);
        Destroy(gameObject);
    }

}
