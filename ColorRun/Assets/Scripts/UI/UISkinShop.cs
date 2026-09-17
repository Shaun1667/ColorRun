using TMPro;
using UnityEngine;

public class UISkinShop : MonoBehaviour
{
    [SerializeField]
    private UISkin skinPrefab;
    [SerializeField]
    private Transform skinParent; //scrollview의 content(스킨 ui의 부모)
    [SerializeField]
    private TextMeshProUGUI textStarCount; //q별의 개수 출력 UI
    private int skincount; //스킨 개수

    private UISkin[] skinList; //스킨 UI 목록

    private void Awake()
    {
        Sprite[] skinSprites = Resources.LoadAll<Sprite>(Constants.SKIN_PATH);
        skincount = skinSprites.Length;
        skinList = new UISkin[skincount];

        for(int i = 0; i < skincount; i++)
        {
            //스킨 UI 생성
            skinList[i] = Instantiate(skinPrefab, skinParent);
        }
    }

    private void OnEnable()
    {
        textStarCount.text = PlayerPrefs.GetInt(Constants.STARCOUNT).ToString();
    }
}
