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
}