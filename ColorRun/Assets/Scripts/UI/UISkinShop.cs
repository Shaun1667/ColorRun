using TMPro;
using UnityEngine;

public class UISkinShop : MonoBehaviour
{

    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip[] clips;
    private AudioSource audioSource;

    [SerializeField]
    private UISkin skinPrefab;
    [SerializeField]
    private Transform skinParent; //scrollview의 content (스킨 ui의 부모)
    [SerializeField]
    private TextMeshProUGUI textStarCount; //별 개수 출력 UI
    private int skinCount; //스킨 개수
    private UISkin[] skinList; //스킨 UI 목록

    private int currentSkinIndex = 0;

    private readonly Color selectedColor = Color.white;
    private readonly Color notSelectedColor = Color.gray;


    private void Awake()
    {
        /*
        //Debug Test
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt(Constants.STARCOUNT, 1000);
        */
        audioSource = GetComponent<AudioSource>();

        Sprite[] skinSprites = Resources.LoadAll<Sprite>(Constants.SKIN_PATH);
        skinCount = skinSprites.Length;
        skinList = new UISkin[skinCount];

        for (int i = 0; i < skinCount; i++)
        {
            //스킨 UI 생성
            skinList[i] = Instantiate(skinPrefab, skinParent);

            if (int.TryParse(skinSprites[i].name.Split('_')[2], out int price))
            {
                skinList[i].Setup(this, i, price, skinSprites[i]);
            }
        }
    }
    private void OnEnable()
    {
        //현재 소지하고 있는 별 개수 출력
        textStarCount.text = PlayerPrefs.GetInt(Constants.STARCOUNT).ToString();

        //기본 스킨(Skin_00)은 항상 소유 상태로 설정
        PlayerPrefs.SetInt($"{Constants.IS_OWNED_SKIN_}0", 1);
        /*
        //디버그 테스트
        for (int i = 1; i < 7; i++)
        {
            PlayerPrefs.SetInt($"{Constants.IS_OWNED_SKIN_}{i}", 1);
        }
        */

        //현재 소유한 스킨 UI만 스킨 아이콘 설정
        //현재 소유한 모든 스튼 UI의 색상을 notSelectedColor로 설정
        for (int i = 0; i < skinCount; i++)
        {
            bool isOwnedSkin = PlayerPrefs.GetInt($"{Constants.IS_OWNED_SKIN_}{i}") == 1 ? true : false;
            if (isOwnedSkin == true)
            {
                skinList[i].SetActive();
                skinList[i].SetColor(notSelectedColor);
            }
        }

        //현재 선택한 스킨 UI의 색상을 selectedColor로 설정
        currentSkinIndex = PlayerPrefs.GetInt(Constants.SELECTED_SKIN_INDEX);
        skinList[currentSkinIndex].SetColor(selectedColor);
    }

    public void ChangeSelectSkin(int newIndex)
    {
        skinList[currentSkinIndex].SetColor(notSelectedColor);
        currentSkinIndex = newIndex;
        skinList[currentSkinIndex].SetColor(selectedColor);
        PlayerPrefs.SetInt(Constants.SELECTED_SKIN_INDEX, currentSkinIndex);
        PlaySound(2);
    }

    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(clips[index]);
    }

    public void TryPurchaseSkin(int index, int price)
    {
        int starCount = PlayerPrefs.GetInt(Constants.STARCOUNT);

        //구매 가능 조건
        if(starCount >= price)
        {
            //구매에 필요한 별 감소
            starCount -= price; //starCount - price
            //별 정보 갱신
            PlayerPrefs.SetInt(Constants.STARCOUNT, starCount);
            PlayerPrefs.SetInt($"{Constants.IS_OWNED_SKIN_}{index}", 1);
            //UI 별 정보 갱신
            textStarCount.text = starCount.ToString();
            //스킨 활성화
            skinList[index].SetActive();
            //스킨 선택
            ChangeSelectSkin(index);
            //스킨 구매 성공 사운드
            PlaySound(0);
        }
        else
        {
            PlaySound(1);
        }
    }
}