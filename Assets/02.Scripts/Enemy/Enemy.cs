using UnityEngine;

[RequireComponent(typeof(HealthComponent), typeof(MovementComponent))]
public class Enemy : MonoBehaviour
{
    private HealthComponent _healthComponent;
    private KnockbackComponent _knockbackComponent;
    private EnemyAnimatorComponent _enemyAnimatorComponent;

    [Header("공격력")]
    [SerializeField] private float _damage;

    private void Awake()
    {
        _healthComponent = GetComponent<HealthComponent>();
        _knockbackComponent = GetComponent<KnockbackComponent>();
        _enemyAnimatorComponent = GetComponent<EnemyAnimatorComponent>();
    }

    public void TakeDamage(float damage)
    {
        _healthComponent.TakeDamage(damage);
        _enemyAnimatorComponent.PlayHitAnimation();
    }

    public void Knockback()
    {
        if (_knockbackComponent == null) return;
        _knockbackComponent.Knockback();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == false) return;
        collision.gameObject.GetComponent<HealthComponent>().TakeDamage(_damage);
        gameObject.SetActive(false);
    }

}
