using UnityEngine;
using static UnityEngine.GraphicsBuffer;

enum EBulletType
{
    PlayerBullet,
    EnemyBullet
}

public class Bullet : MonoBehaviour
{

    [Header("공격력")]
    [SerializeField] private float _damage;
    [SerializeField] private float _criticalRate;

    [Header("총알 타입")]
    [SerializeField] private EBulletType _bulletType;

    private bool ShouldHit(GameObject target)
    {
        if(_bulletType == EBulletType.PlayerBullet && target.CompareTag("Enemy"))
        {
            AttackEnemy(target);
            return true;
        }
        else if(_bulletType == EBulletType.EnemyBullet && target.CompareTag("Player"))
        {
            AttackPlayer(target);
            return true;
        }
        return false;
    }

    private void AttackPlayer(GameObject target)
    {
        Player player = target.GetComponent<Player>();
        player.TakeDamage(_damage);
    }

    private void AttackEnemy(GameObject target)
    {
        Enemy enemy = target.GetComponent<Enemy>();
        HitboxComponent hitbox = target.GetComponent<HitboxComponent>();

        if (hitbox != null) _damage *= hitbox.DamageRate;
        enemy.TakeDamage(_damage);

        bool critical = Random.value < _criticalRate;
        if (critical) enemy.Knockback();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ShouldHit(collision.gameObject) == false) return;
        Destroy(gameObject);
    }

}
