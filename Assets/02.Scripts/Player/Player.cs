using UnityEngine;

[RequireComponent(typeof(HealthComponent), typeof(MovementComponent), typeof(FireComponent))]
public class Player : MonoBehaviour
{
    private HealthComponent _healthComponent;
    private PlayerMovementComponent _playerMovementComponent;
    private FireComponent _fireComponent;

    private void Awake()
    {
        _healthComponent = GetComponent<HealthComponent>();
        _playerMovementComponent = GetComponent<PlayerMovementComponent>();
        _fireComponent = GetComponent<FireComponent>();
    }

    public void TakeDamage(float damage)
    {
        _healthComponent.TakeDamage(damage);
    }

    public void Heal(float amount)
    {
        _healthComponent.Heal(amount);
    }

    public void MoveSpeedup(float amount)
    {
        _playerMovementComponent.MoveSpeedup(amount);
    }

    public void FireSpeedup(float amount)
    {
        _fireComponent.FireSpeedup(amount);
    }

}
