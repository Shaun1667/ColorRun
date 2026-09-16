using TMPro;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [Header("GameOver")]
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private TextMeshProUGUI textGameOverCurrentScore;
    [SerializeField]
    private TextMeshProUGUI textGameOverBestScore;

    [Header("InGame")]
    [SerializeField]
    private GameObject inGamePanel;
    [SerializeField]
    TextMeshProUGUI textInGameCurrentScore;

    [SerializeField]
    TextMeshProUGUI textInGameBestScore;

    [Header("Main")]
    [SerializeField]
    private GameObject mainPanel;


    public void GameStart()
    {
        mainPanel.SetActive(false);
        inGamePanel.SetActive(true);

        int bestScore = PlayerPrefs.GetInt(Constants.BESTSCORE);
        textInGameBestScore.text = $"BEST\n{bestScore:D4}";
    }

    public void UpdateCurrentScore(int score)
    {
        textInGameCurrentScore.text = $"{score:00}";
    }

    public void GameOver(int current, int best, bool isBest)
    {
        inGamePanel.SetActive(false);
        gameOverPanel.SetActive(true);

        textGameOverCurrentScore.text = $"SCORE\n{current:D4}";
        string bestScoreText = (isBest == true) ? $"Best(New)" : $"Best";
        textGameOverBestScore.text = $"{ bestScoreText}\n{ best:D4}";
    }

    public void OnClickMain()
    {
        SceneManager.LoadScene(0);
    }
}
