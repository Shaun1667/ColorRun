using UnityEngine;
using UnityEngine.Events;

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
}
