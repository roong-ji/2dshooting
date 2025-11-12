using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // UI 요소는 변수명 뒤에 UI 붙임
    [SerializeField] private Text _bestScoreTextUI;
    [SerializeField] private Text _currentScoreTextUI;

    private string _scoreKey = "Score";

    private int _bestScore = 0;
    private int _currentScore = 0;
    
    private float _textScore = 0;
    private float _textBestScore = 0;
    private float _timer = 0f;
    private float _lerpTime = 1f;

    private float _maxScale = 1.5f;
    private Vector3 _originScale = Vector3.one;

    private string _current = "현재";
    private string _best = "최고";

    private void Start()
    {
        LoadScore();
        _currentScoreTextUI.text = $"현재 점수 : {_currentScore}";
        _bestScoreTextUI.text = $"최고 점수 : {_bestScore}";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerPrefs.SetInt(_scoreKey, 0);
            _bestScore = 0;
            _bestScoreTextUI.text = $"최고 점수 : {_bestScore}";
        }

        _timer += Time.deltaTime;

        if (_timer > _lerpTime) return;
        LerpScore(_currentScoreTextUI, ref _textScore, ref _current);

        if (_bestScore > _currentScore) return;
        LerpScore(_bestScoreTextUI, ref _textBestScore, ref _best);
    }

    private void LerpScore(Text text, ref float score, ref string type)
    {
        score = Mathf.Lerp(score, _currentScore, _timer / _lerpTime);
        text.text = $"{type} 점수 : {Mathf.RoundToInt(score)}";

        text.rectTransform.localScale = Vector3.Lerp(
        text.rectTransform.localScale,
        _originScale,
        _timer / _lerpTime
        );
    }

    public void AddScore(int score)
    {
        _timer = 0f;
        _currentScore += score;
        _currentScoreTextUI.rectTransform.localScale = _originScale * _maxScale;

        if (_bestScore > _currentScore) return;
        _bestScoreTextUI.rectTransform.localScale = _originScale * _maxScale;
        _bestScore = _currentScore;
        SaveScore();
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt(_scoreKey, _bestScore);
    }

    private void LoadScore()
    {
        _bestScore = PlayerPrefs.GetInt(_scoreKey, 0);
    }

    /*
    private void TestSave()
    {
        // 유니티에서 값을 저장할 때 PlayerPrefs 모듈을 사용
        // 저장 가능한 자료형 : int, float, string
        // 이름 key, 값 value 형태로 저장
        PlayerPrefs.SetInt("level", 22);
        PlayerPrefs.SetString("name", "최강전사");
        Debug.Log("저장 완료");
    }

    private void TestLoad()
    {
        // 데이터가 있는지 검증
        // 직접 검사 방식
        int level = 0; // 기본 값
        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }

        // default 인자
        string name = PlayerPrefs.GetString("name", "이름없는모험가");
        Debug.Log($"{name} : {level}");
    }
    */
}
