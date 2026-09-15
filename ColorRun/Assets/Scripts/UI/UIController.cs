using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("main")]
    [SerializeField]
    private GameObject mainPanel;

    public void GameStart()
    {
        mainPanel.SetActive(false);
    }
}
