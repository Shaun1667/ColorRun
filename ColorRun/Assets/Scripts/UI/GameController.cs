using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private UIController uiController;

    private float deltaTime = 0f;



    public bool IsGamePlay { get; private set; } = false;

    private IEnumerator Start()
    {
        while (true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                GameStart();
                yield break;
            }

            yield return null;
        }
    }

    private void GameStart()
    {
        IsGamePlay = true;
        uiController.GameStart();
    }

    public void GameOver()
    {
        IsGamePlay = false;
        StartCoroutine(nameof(OnGameOver));
    }

    private IEnumerator OnGameOver()
    {
        float percent = 0;
        float time = 1.5f;

        while (percent < time)
        {
            percent += Time.deltaTime;
            yield return null;
        }

        //현재 스테이지에서 획득한 별 개수 추가
        PlayerPrefs.SetInt(Constants.STARCOUNT, PlayerPrefs.GetInt(Constants.STARCOUNT) + playerData.CurrentStarCount);
        playerData.SaveArchiveData();
        bool isBestScore = false;

        int bestScore = PlayerPrefs.GetInt(Constants.BESTSCORE);

        if (bestScore < playerData.CurrentScore)
        {
            isBestScore = true;
            bestScore = playerData.CurrentScore;
            PlayerPrefs.SetInt(Constants.BESTSCORE, bestScore);
        }

        

        //게임오버 UI 출력
        uiController.GameOver(playerData.CurrentScore, bestScore, isBestScore);
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(10, 200, Screen.width, Screen.height);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = 60;
        style.normal.textColor = Color.red;

        float ms = deltaTime * 1000f;
        float fps = 1f / deltaTime;
        string text = string.Format("{0:0.0} ms {1:0.}fps", ms, fps);
        GUI.Label(rect, text, style);
    }

}