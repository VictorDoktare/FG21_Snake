using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score = 0;
    private TextMeshProUGUI _scoreCounter;

    public int Score => _score;
    
    void Start()
    {
        EventManager.Instance.onPickup += UpdateScore;

        _scoreCounter = GetComponent<TextMeshProUGUI>();
    }

    private void UpdateScore()
    {
        _score += 15;
        _scoreCounter.text =_score.ToString();
    }

    private void OnDestroy()
    {
        EventManager.Instance.onPickup -= UpdateScore;
    }
}
