using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    //구역(area)의 길이 : 구역 프리팹을 제작할 때 이 길이에 맞춰서 제작
    private readonly float areaLength = 18;

    [SerializeField]
    private GameObject[] areaPrefabs;
    [SerializeField]
    private Transform plyaer;
    private int areaIndex = 0;

    private void Awake()
    {
        
    }

}
