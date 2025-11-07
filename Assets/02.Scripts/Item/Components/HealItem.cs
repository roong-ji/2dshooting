using UnityEngine;

public class HealItem : ItemComponent
{

    [Header("회복량")]
    [SerializeField] private float _healAmount;

    protected override void ApplayEffect(Player player)
    {
        player.Heal(_healAmount);
    }
}
