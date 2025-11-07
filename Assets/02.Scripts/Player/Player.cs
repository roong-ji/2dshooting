using UnityEngine;

[RequireComponent(typeof(HealthComponent), typeof(MovementComponent), typeof(FireComponent))]
public class Player : MonoBehaviour
{
    private HealthComponent _healthComponent;
    private MovementComponent _movementComponent;
    private FireComponent _fireComponent;

    private void Awake()
    {
        _healthComponent = GetComponent<HealthComponent>();
        _movementComponent = GetComponent<MovementComponent>();
        _fireComponent = GetComponent<FireComponent>();
    }

    public void Heal(float amount)
    {
        _healthComponent.Heal(amount);
    }

    public void MoveSpeedup(float amount)
    {
        _movementComponent.MoveSpeedup(amount);
    }

    public void FireSpeedup(float amount)
    {
        _fireComponent.FireSpeedup(amount);
    }

}
