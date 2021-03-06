using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiActions : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverObj;

    #region Unity Event Functions
    private void OnEnable()
    {
        EventManager.Instance.ONEndGame += ShowGameOverUi;
    }
    
    private void OnDestroy()
    {
        if (EventManager.Instance != null)
        {
            EventManager.Instance.ONEndGame -= ShowGameOverUi;
        }
    }

    #endregion

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }

    private void ShowGameOverUi()
    {
        _gameOverObj.SetActive(true);
    }
    
    
}
