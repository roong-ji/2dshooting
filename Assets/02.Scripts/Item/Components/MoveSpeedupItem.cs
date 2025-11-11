using UnityEngine;

public class MoveSpeedupItem : ItemComponent
{

    [Header("이동 속도 상승치")]
    [SerializeField] private float _speedupAmount;

    protected override void ApplayEffect(Player player)
    {
        player.MoveSpeedup(_speedupAmount);
    }

}
