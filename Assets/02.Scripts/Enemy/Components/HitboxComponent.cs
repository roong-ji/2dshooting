using System.Security.Cryptography;
using UnityEngine;

public class HitboxComponent : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    [Header("데미지 비율")]
    [SerializeField] private float damageRate;
    public float DamageRate => damageRate;

    public void TakeDamage(float damage)
    {
        _enemy.TakeDamage(damage);
    }

    public void Knockback()
    {
        _enemy.Knockback();
    }

}
