using UnityEngine;
using UnityEngine.Events;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<int> onChangeCurrentScore;

    private int currentScore = 0;

    public int CurrentScore
    {
        set
        {
            currentScore = value;
            onChangeCurrentScore?.Invoke(currentScore);
        }
        get => currentScore;
    }

}
