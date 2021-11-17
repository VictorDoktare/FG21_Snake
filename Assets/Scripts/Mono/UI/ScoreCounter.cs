using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score = 0;
    private TextMeshProUGUI _scoreCounter;

    public int Score => _score;

    #region Unity Event Functions
    void Start()
    {
        EventManager.Instance.ONPickup += UpdateScore;

        _scoreCounter = GetComponent<TextMeshProUGUI>();
    }
    private void OnDestroy()
    {
        if (EventManager.Instance != null)
        {
            EventManager.Instance.ONPickup -= UpdateScore;
        }
    }
    #endregion

    private void UpdateScore()
    {
        _score += 15;
        _scoreCounter.text =_score.ToString();
    }
}
