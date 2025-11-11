using UnityEngine;

public class FireSpeedupItem : ItemComponent
{
    [Header("발사 속도 증가량")]
    [SerializeField] private float _fireSpeedupAmount;

    protected override void ApplyEffect(Player player)
    {
        player.FireSpeedup(_fireSpeedupAmount);
    }

}
