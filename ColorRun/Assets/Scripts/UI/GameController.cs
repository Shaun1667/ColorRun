using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private UIController uiController;

    public bool isGamePlay { get; private set; } = false;

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
        isGamePlay = true;
        uiController.GameStart();
    }
}
