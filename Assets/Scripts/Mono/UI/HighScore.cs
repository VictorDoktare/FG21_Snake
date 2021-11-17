using System;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField] private ScoreCounter _score;
    
    private static int _highScore = 0;
    private TextMeshProUGUI _highScoreText;

    private void Start()
    {
        _highScoreText = GetComponent<TextMeshProUGUI>();
        _highScoreText.text = $"{_highScore}";
        
        EventManager.Instance.onEndGame += SaveHighscore;
    }

    private void SaveHighscore()
    {
        if (_score.Score > _highScore)
        {
            _highScore = _score.Score;
            _highScoreText.text = $"{_highScore}";
        }
    }

    private void OnDestroy()
    {
        EventManager.Instance.onEndGame -= SaveHighscore;
    }
}
