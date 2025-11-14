using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override bool ShouldHit(GameObject target)
    {
        if (target.CompareTag("Enemy") == false) return false;

        HitboxComponent hitbox = target.GetComponent<HitboxComponent>();
        if (hitbox == null)
        {
            target.SetActive(false);
            return true;
        }

        float damage = _damage * hitbox.DamageRate;
        hitbox.TakeDamage(damage);

        bool critical = Random.value < _criticalRate;
        if (critical) hitbox.Knockback(); return true;
    }

}
