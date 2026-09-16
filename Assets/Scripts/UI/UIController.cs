using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private GameObject mainPanel;

    [Header("InGame")]
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private TextMeshProUGUI textInGameCurrentScore;
    [SerializeField] private TextMeshProUGUI textInGameBestScore;

    [Header("GameOver")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI textGameOverCurrentScore;
    [SerializeField] private TextMeshProUGUI textGameOverBestScore;


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

    //GameOver시 해야할 일들을 모아놓은 함수
    public void GameOver(int current, int best, bool isBest)
    {
        inGamePanel.SetActive(false);
        gameOverPanel.SetActive(true);

        textGameOverCurrentScore.text = $"SCORE\n{current:D4}";
        string bestScoreText = (isBest == true) ? $"BEST(New)" : $"BEST";
        textGameOverBestScore.text = $"{bestScoreText}\n{best:D4}";
    }

    public void OnClickMain()
    {
        SceneManager.LoadScene(0);
    }
}
