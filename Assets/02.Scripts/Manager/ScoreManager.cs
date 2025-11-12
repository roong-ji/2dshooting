using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // UI 요소는 변수명 뒤에 UI를 붙인다.
    [SerializeField] private Text _bestScoreTextUI;
    [SerializeField] private Text _currentScoreTextUI;

    private UserData _userData;
    private string _scoreKey = "Score";
    private const string DATA_KEY = "PlayerData";

    private int _bestScore = 0;
    private int _currentScore = 0;
    
    private float _textScore = 0;
    private float _textBestScore = 0;
    private float _timer = 0f;
    private const float LerpTime = 1f;

    private const float MaxScale = 1.5f;
    private readonly Vector3 _originScale = Vector3.one;

    private string _current = "현재";
    private string _best = "최고";


    private void Start()
    {
        _userData = LoadData();
        _bestScore = _userData.BestScore;
        _currentScoreTextUI.text = $"현재 점수 : {_currentScore}";
        _bestScoreTextUI.text = $"최고 점수 : {_bestScore}";
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerPrefs.SetInt(_scoreKey, 0);
            _bestScore = 0;
            _bestScoreTextUI.text = $"최고 점수 : {_bestScore}";
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveData(_userData);
            Debug.Log($"저장 : {_userData.BestScore}");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            _userData = LoadData();
            Debug.Log($"로드 : {_userData.BestScore}");
        }
#endif

        _timer += Time.deltaTime;

        if (_timer > LerpTime) return;
        LerpScore(_currentScoreTextUI, ref _textScore, _current);

        if (_bestScore > _currentScore) return;
        LerpScore(_bestScoreTextUI, ref _textBestScore, _best);
    }

    private void LerpScore(Text text, ref float score, string type)
    {
        score = Mathf.Lerp(score, _currentScore, _timer / LerpTime);
        text.text = $"{type} 점수 : {Mathf.RoundToInt(score)}";

        text.rectTransform.localScale = Vector3.Lerp(
            text.rectTransform.localScale,
            _originScale,
            _timer / LerpTime
        );
    }

    public void AddScore(int score)
    {
        _timer = 0f;
        _currentScore += score;
        _currentScoreTextUI.rectTransform.localScale = _originScale * MaxScale;

        //_currentScoreTextUI.rectTransform.DOScale(_originScale, _lerpTime);

        if (_bestScore > _currentScore) return;
        _bestScoreTextUI.rectTransform.localScale = _originScale * MaxScale;
        _bestScore = _currentScore;

        _userData.BestScore = _bestScore;
        SaveData(_userData);
    }

    private void SaveData(UserData data)
    {
        string jsonData = JsonUtility.ToJson(data);

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
