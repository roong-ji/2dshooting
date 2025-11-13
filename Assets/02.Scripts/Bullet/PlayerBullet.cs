using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override bool ShouldHit(GameObject target)
    {
        if (target.CompareTag("Enemy") == false) return false;

        HitboxComponent hitbox = target.GetComponent<HitboxComponent>();
        if (hitbox == null)
        {
            Destroy(target);
            return true;
        }

        _damage *= hitbox.DamageRate;
        hitbox.TakeDamage(_damage);

        bool critical = Random.value < _criticalRate;
        if (critical) hitbox.Knockback(); return true;
    }

}
