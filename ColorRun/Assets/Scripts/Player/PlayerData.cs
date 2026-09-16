using UnityEngine;
using UnityEngine.Events;
public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<int> onChagedCurtentScore;

    private int currentScore = 0;

   public int CurrentScore
    {
        set
        {
            currentScore = value;
            onChagedCurtentScore?.Invoke(currentScore);

        }
        get => currentScore;
    }

}


