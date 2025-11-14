using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    // UI 요소는 변수명 뒤에 UI를 붙인다.
    [SerializeField] private Text _bestScoreTextUI;
    [SerializeField] private Text _currentScoreTextUI;

    private UserData _userData;
    private const string DATA_KEY = "PlayerData";

    private int _bestScore = 0;
    private int _currentScore = 0;
    
    private float _textScore = 0;
    private float _textBestScore = 0;
    private float _timer = 0f;
    private const float LERP_TIME = 1f;

    private const float MAX_SACLE = 1.5f;
    private readonly Vector3 _originScale = Vector3.one;

    private const string CURRENT = "현재";
    private const string BEST = "최고";

    public int Score => _currentScore;

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
        if (Input.GetKeyDown(KeyCode.S))
        {
            _userData.BestScore = 0;
            SaveData(_userData);
            Debug.Log($"최고 점수 초기화");
        }
#endif

        _timer += Time.deltaTime;

        if (_timer > LERP_TIME) return;
        LerpScore(_currentScoreTextUI, ref _textScore, CURRENT);

        if (_bestScore > _currentScore) return;
        LerpScore(_bestScoreTextUI, ref _textBestScore, BEST);
    }

    private void LerpScore(Text text, ref float score, string type)
    {
        score = Mathf.Lerp(score, _currentScore, _timer / LERP_TIME);
        text.text = $"{type} 점수 : {Mathf.RoundToInt(score)}";

        text.rectTransform.localScale = Vector3.Lerp(
            text.rectTransform.localScale,
            _originScale,
            _timer / LERP_TIME
        );
    }

    public void AddScore(int score)
    {
        _timer = 0f;
        _currentScore += score;
        _currentScoreTextUI.rectTransform.localScale = _originScale * MAX_SACLE;

        //_currentScoreTextUI.rectTransform.DOScale(_originScale, _lerpTime);

        if (_bestScore > _currentScore) return;
        _bestScoreTextUI.rectTransform.localScale = _originScale * MAX_SACLE;
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
