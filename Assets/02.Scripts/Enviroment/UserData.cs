using System;
using UnityEngine;

[Serializable]
public class UserData
{
    public int BestScore;
    public float Damage;

    public UserData()
    {
        BestScore = 0;
        Damage = DamageManager.Instance.Damage;
    }

}