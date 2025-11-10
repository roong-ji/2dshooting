using UnityEngine;

[RequireComponent(typeof(HealthComponent), typeof(MovementComponent))]
public class Enemy : MonoBehaviour
{
    private HealthComponent _healthComponent;
    private MovementComponent _movementComponent;

    private void Awake()
    {
        _healthComponent = GetComponent<HealthComponent>();
        _movementComponent = GetComponent<MovementComponent>();
    }

    public void TakeDamage(float damage)
    {
        _healthComponent.TakeDamage(damage);
    }

    public void Knockback()
    {
        _movementComponent.Knockback();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.gameObject.name == "Player") 오타에 취약!!
        if (collision.gameObject.CompareTag("Player") == false) return; // 코드를 간결하게 만드는 조기 리턴
        collision.gameObject.GetComponent<HealthComponent>().TakeDamage(1f);
        Destroy(gameObject);
    }

}
