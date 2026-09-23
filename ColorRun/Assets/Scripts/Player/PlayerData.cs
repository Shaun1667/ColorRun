using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;  //ToHexString()

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<int> onChangedCurrentScore;

    private Dictionary<Color, int> dicDestroyObjectCount;
    public Dictionary<Color, int> DicDestroyObjectCount => dicDestroyObjectCount;

    public void Setup(Color[] colors)
    {
        dicDestroyObjectCount = new Dictionary<Color, int>();
        for(int i = 0; i < colors.Length; i++)
        {
            dicDestroyObjectCount.Add(colors[i], 0);
        }
    }

    public void AddDestroyObjectCountAt(Color color)
    {
        dicDestroyObjectCount[color] ++;
        //디버그 테스트
        Debug.Log($"<b><color=#{color.ToHexString()}>{dicDestroyObjectCount[color]}</color></b>");
    }

    public void SaveArchiveData()
    {
        //게임 플레이 횟수
        PlayerPrefs.SetInt(Constants.GAMEPLAYCOUNT, PlayerPrefs.GetInt(Constants.GAMEPLAYCOUNT) + 1);
        //별 획득 갯수 저장
        PlayerPrefs.SetInt(Constants.MAXSTARCOUNT, PlayerPrefs.GetInt(Constants.MAXSTARCOUNT) + 1);
        //오브젝트 파괴 개수 저장(색상별)
        int objectDestroyCountAll = 0;
        foreach(var item in dicDestroyObjectCount)
        {
            //item.key에 해당하는 색상의 오브젝트 파괴 개수
            int prevCount = PlayerPrefs.GetInt($"{Constants.OBJECTDESTROYCOUNT}{item.Key}");
            PlayerPrefs.SetInt($"{Constants.OBJECTDESTROYCOUNT}{item.Key}", prevCount + item.Value);

            objectDestroyCountAll += item.Value;
        }
        //오브젝트 파괴 개수 저장(통합)
        PlayerPrefs.SetInt(Constants.OBJECTDESTROYCOUNT, PlayerPrefs.GetInt(Constants.OBJECTDESTROYCOUNT) + objectDestroyCountAll);
    }

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
