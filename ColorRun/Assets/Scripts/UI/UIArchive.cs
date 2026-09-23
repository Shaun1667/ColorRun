using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIArchive : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textStarData;
    [SerializeField]
    private TextMeshProUGUI textGamePlayData;
    [SerializeField]
    private TextMeshProUGUI textDestroyAllObject;
    [SerializeField]
    private GameObject colorPrefab;
    [SerializeField]
    private Transform colorParent;
    [SerializeField]
    private PlayerData playerData;
    private TextMeshProUGUI[] textDestroyObjects;

    public void Setup(Color[] colors)
    { 
        textDestroyObjects = new TextMeshProUGUI[colors.Length];

        for (int i = 0; i < colors.Length; i++)
        {
            //생성
            GameObject clone = Instantiate(colorPrefab, colorParent);
            //색상 설정
            clone.GetComponent<Image>().color = colors[i];
            //각 텍스트 컴포넌트 접근
            textDestroyObjects[i] = clone.GetComponentInChildren<TextMeshProUGUI>();
        }
    }
    private void OnEnable()
    {
        textStarData.text = $"Star (Storage/Get)\n{PlayerPrefs.GetInt(Constants.STARCOUNT)}/{PlayerPrefs.GetInt(Constants.MAXSTARCOUNT)}";
        textGamePlayData.text = $"Game Play\n{PlayerPrefs.GetInt(Constants.GAMEPLAYCOUNT)}";
        textDestroyAllObject.text = $"Destroy Object\n{PlayerPrefs.GetInt(Constants.OBJECTDESTROYCOUNT)}";

        int index = 0;
        foreach (var item in playerData.DicDestroyObjectCount)
        {
            textDestroyObjects[index].text =
                PlayerPrefs.GetInt($"{Constants.OBJECTDESTROYCOUNT}{item.Key}").ToString();
            index++;
        }
    }
}
