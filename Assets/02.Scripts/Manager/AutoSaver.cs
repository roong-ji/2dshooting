using UnityEngine;

public class AutoSaver : MonoBehaviour
{
    private UserData _userData;
    private const string DATA_KEY = "PlayerData";

    private void Start()
    {
        _userData = LoadData();
        ScoreManager.Instance.InitScore(_userData.BestScore, _userData.TotalScore);
        DamageManager.Instance.InitDamage(_userData.Damage);
    }

    private void OnApplicationQuit()
    {
        Debug.Log("앱 종료 저장");
        SaveData();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause == false) return;
        Debug.Log("앱 일시정지 저장");
        SaveData();
    }

    private void SaveData()
    {
        _userData.BestScore = ScoreManager.Instance.BestScore;
        _userData.TotalScore = ScoreManager.Instance.TotalScore;
        _userData.Damage = DamageManager.Instance.Damage;

        string jsonData = JsonUtility.ToJson(_userData);

        PlayerPrefs.SetString(DATA_KEY, jsonData);
        PlayerPrefs.Save();
    }

    private UserData LoadData()
    {
        if (PlayerPrefs.HasKey(DATA_KEY) == false) return new UserData();

        string jsonData = PlayerPrefs.GetString(DATA_KEY);
        return JsonUtility.FromJson<UserData>(jsonData);
    }
}
