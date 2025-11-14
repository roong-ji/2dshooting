using UnityEngine;

public class EnemyBullet : Bullet
{
    protected override bool ShouldHit(GameObject target)
    {
        if (target.CompareTag("Player") == false) return false;

        Player player = target.GetComponent<Player>();
        player.TakeDamage(_damage);
        return true;
    }
}
