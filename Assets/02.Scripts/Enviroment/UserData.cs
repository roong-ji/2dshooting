using System;
using UnityEngine;

[Serializable]
public class UserData
{
    public int BestScore;
    public int TotalScore;
    public float Damage;

    public UserData()
    {
        BestScore = 0;
        TotalScore = 0;
        Damage = 100f;
    }

}