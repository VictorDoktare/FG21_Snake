using System.Collections;
using TMPro;
using UnityEngine;

public class StartTimer : MonoBehaviour
{
    [SerializeField] private GameObject _startBackdrop;
    
    private int _timerCount = 4;
    private TextMeshProUGUI _countText;

    private void Start()
    {
        _countText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        while (_timerCount >= 0)
        {
            yield return new WaitForSeconds(1);

            if (_timerCount == 0)
            {
                EventManager.Instance.StartGame();
                _startBackdrop.SetActive(false);
            }
            else if (_timerCount == 1)
            {
                _timerCount--;
                _countText.text = $"GO";
            }
            else
            {
                _timerCount--;
                _countText.text = $"{_timerCount}";  
            }
        }
    }
}
