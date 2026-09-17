using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<int> onChagedCurrentScore;

    private int currentScore = 0;

    public int CurrentScore
    {
        set
        {
            currentScore = value;
            onChagedCurrentScore?.Invoke(currentScore);
        }
        get => currentScore;
    }

     private int currentStarCount =0;
    public int CurrentStarCount
    {
        set => currentStarCount = Mathf.Max(0, value);
        get => currentStarCount;
    }



}
