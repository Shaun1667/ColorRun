using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("InGame")]
    [SerializeField]
    private GameObject inGamePanel;
    [SerializeField]
    TextMeshProUGUI textInGameCurrentScore;
    [SerializeField]
    TextMeshProUGUI textInGameBestScore;
    [Header("main")]
    [SerializeField]
    private GameObject mainPanel;
    [Header("GameOver")]
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private TextMeshProUGUI textGameOverCurrentScore;
    [SerializeField]
    private TextMeshProUGUI textGameOverBestScore;

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

    //GameOver 시 해야 할 일들을 모아놓은 함수
    public void GameOver(int current, int best, bool isBest)
    {
        inGamePanel.SetActive(false);
        gameOverPanel.SetActive(true);

        textGameOverCurrentScore.text = $"Score\n{current:D4}";
        string bestScoreText = isBest == true ? $"Best(New)": $"Best";
        textGameOverBestScore.text = $"{bestScoreText}\n{best:D4}";
    }

    public void OnClickMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
