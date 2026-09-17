using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private UIController uiController;

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

}