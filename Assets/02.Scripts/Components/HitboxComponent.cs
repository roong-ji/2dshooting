using UnityEngine;

public class HitboxComponent : MonoBehaviour
{

    [Header("데미지 비율")]
    [SerializeField] private float damageRate;
    public float DamageRate => damageRate;

}
