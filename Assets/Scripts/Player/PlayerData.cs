using UnityEngine;
using UnityEngine.Events;
public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<int> onChangedCurrentScore;

    private int currentScore = 0;
    public int CurrentScore
    {
        set
        {
            currentScore = value;
            onChangedCurrentScore?.Invoke(currentScore);
        }
        get => currentScore;
    }

    private int currentStarCount = 0;
    public int CurrentStarCount
    {
        set => currentStarCount = Mathf.Max(0, value);
        get => currentStarCount;
    }
}