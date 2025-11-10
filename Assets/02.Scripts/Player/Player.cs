using UnityEngine;

[RequireComponent(typeof(HealthComponent), typeof(MovementComponent), typeof(FireComponent))]
public class Player : MonoBehaviour
{
    private HealthComponent _healthComponent;
    private MovementComponent _movementComponent;
    private MovementComponent _autoMovementComponent;
    private FireComponent _fireComponent;

    private void Awake()
    {
        _healthComponent = GetComponent<HealthComponent>();
        _movementComponent = GetComponent<PlayerMove>();
        _autoMovementComponent = GetComponent<PlayerAutoMove>();
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
        _movementComponent.MoveSpeedup(amount);
        _autoMovementComponent.MoveSpeedup(amount);
    }

    public void FireSpeedup(float amount)
    {
        _fireComponent.FireSpeedup(amount);
    }

}
