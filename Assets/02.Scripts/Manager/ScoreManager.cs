using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // 적 처지 시 점수를 올리고 현재 점수를 UI에 표시
    [SerializeField] private Text _currentScoreTextUI; // UI 요소는 변수명 뒤에 UI 붙임

    private string _scoreKey = "Score";

    private float _textScore = 0;
    private int _currentScore = 0;
    private float _lerpSpeed = 15f;

    private void Start()
    {
        _currentScoreTextUI.text = $"현재 점수 : {_currentScore}";
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.S)) SaveScore();
        if (Input.GetKeyUp(KeyCode.L)) LoadScore();


        RefreshScore();
    }

    private void RefreshScore()
    {
        _textScore = Mathf.Lerp(_textScore, _currentScore, _lerpSpeed * Time.deltaTime);
        _currentScoreTextUI.text = $"현재 점수 : {Mathf.RoundToInt(_textScore)}";
    }

    public void AddScore(int score)
    {
        _currentScore += score;
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt(_scoreKey, _currentScore);
    }

    private void LoadScore()
    {
        _currentScore = PlayerPrefs.GetInt(_scoreKey, 0);
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
