using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkinShopController : MonoBehaviour
{
    [Header("연결 대상")]
    [SerializeField]
    private GameObject shopPanel;       //껐다 켜지는 상점 패널 (배경 + 그리드 + X버튼)
    [SerializeField]
    private GameObject skinItemPrefab;  //Assets/Prefabs/Skin.prefab
    [SerializeField]
    private Transform contentParent;    //ScrollView의 Content
    [SerializeField]
    private TextMeshProUGUI starCountText;
    [SerializeField]
    private PlayerColor playerColor;

    [Header("스킨 목록 (색상 / 가격)")]
    [SerializeField]
    private SkinData[] skins;

    private const string OWNED_KEY_PREFIX = "SKIN_OWNED_";
    private const string EQUIPPED_KEY = "SKIN_EQUIPPED_INDEX";

    private readonly List<UISkin> spawnedItems = new List<UISkin>();
    private bool isBuilt = false;

    private void Awake()
    {
        //게임 시작 시, 이전에 장착해둔 스킨 색상을 플레이어에게 바로 적용
        ApplyEquippedColor();
    }

    public void OpenShop()
    {
        if (shopPanel != null) shopPanel.SetActive(true);

        if (!isBuilt)
        {
            BuildGrid();
            isBuilt = true;
        }

        RefreshAll();
    }

    public void CloseShop()
    {
        if (shopPanel != null) shopPanel.SetActive(false);
    }

    private void BuildGrid()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            GameObject go = Instantiate(skinItemPrefab, contentParent);
            UISkin uiSkin = go.GetComponent<UISkin>();

            int index = i; //클로저 캡처용
            uiSkin.Setup(skins[i], index, OnClickSkin);
            spawnedItems.Add(uiSkin);
        }

        //0번 스킨은 기본 스킨으로 항상 보유 처리
        if (!IsOwned(0))
        {
            SetOwned(0, true);
        }
    }

    private void OnClickSkin(int index)
    {
        if (IsOwned(index))
        {
            Equip(index);
        }
        else
        {
            TryPurchase(index);
        }

        RefreshAll();
    }

    private void TryPurchase(int index)
    {
        int price = skins[index].price;
        int starCount = PlayerPrefs.GetInt(Constants.STARCOUNT);

        if (starCount < price)
        {
            Debug.Log("별이 부족합니다.");
            return;
        }

        PlayerPrefs.SetInt(Constants.STARCOUNT, starCount - price);
        SetOwned(index, true);
        Equip(index);
    }

    private void Equip(int index)
    {
        PlayerPrefs.SetInt(EQUIPPED_KEY, index);
        ApplyEquippedColor();
    }

    private void ApplyEquippedColor()
    {
        if (playerColor == null || skins == null || skins.Length == 0) return;

        int equippedIndex = PlayerPrefs.GetInt(EQUIPPED_KEY, 0);
        equippedIndex = Mathf.Clamp(equippedIndex, 0, skins.Length - 1);
        playerColor.SetColor(skins[equippedIndex].color);
    }

    private void RefreshAll()
    {
        int equippedIndex = PlayerPrefs.GetInt(EQUIPPED_KEY, 0);

        for (int i = 0; i < spawnedItems.Count; i++)
        {
            spawnedItems[i].Refresh(IsOwned(i), i == equippedIndex);
        }

        if (starCountText != null)
        {
            starCountText.text = PlayerPrefs.GetInt(Constants.STARCOUNT).ToString();
        }
    }

    private bool IsOwned(int index) => PlayerPrefs.GetInt(OWNED_KEY_PREFIX + index, 0) == 1;
    private void SetOwned(int index, bool owned) => PlayerPrefs.SetInt(OWNED_KEY_PREFIX + index, owned ? 1 : 0);
}
