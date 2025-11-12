using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // 적 처지 시 점수를 올리고 현재 점수를 UI에 표시
    [SerializeField] private Text _currentScoreTextUI; // UI 요소는 변수명 뒤에 UI 붙임

    private int _currentScore = 0;

    private void Start()
    {
        RefreshScore();
    }

    private void RefreshScore()
    {
        _currentScoreTextUI.text = $"현재 점수 : {_currentScore}";
    }

    public void AddScore(int score)
    {
        _currentScore += score;
    }

}
