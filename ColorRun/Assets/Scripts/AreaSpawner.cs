using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    //구역(area)의 길이 : 구역 프리팹을 제작할 때 이 길이에 맞춰서 제작
    private readonly float areaLength = 18;

    [SerializeField]
    private Color[] colors;


    [SerializeField]
    private GameObject[] areaPrefabs;
    [SerializeField]
    private Transform player;

    [SerializeField]
    private UIArchive uiArchive;
    private int areaIndex = 0;

    private void Awake()
    {
        player.GetComponent<PlayerData>().Setup(colors);
        uiArchive.SetUp(colors);
        SpawnArea();
    }

    public void SpawnArea()
    {
        int index = Random.Range(0, areaPrefabs.Length);
        Vector3 position = Vector3.up * areaLength * areaIndex;
        GameObject area = Instantiate(areaPrefabs[index], position, Quaternion.identity, transform);
        area.GetComponent<AreaController>().Setup(colors);

        areaIndex++;
    }

    public void DestroyArea()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (player.position.y - child.position.y >= areaLength)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
