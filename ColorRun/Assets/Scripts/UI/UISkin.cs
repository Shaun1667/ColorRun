using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISkin : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Image skinImage;
    [SerializeField]
    private GameObject priceGameObject;
    [SerializeField]
    private TextMeshProUGUI skinPrice;

    private int price;
    private Sprite sprite;
    private UISkinShop uiSkinShop;
    private int index;


    public void Setup(UISkinShop uiSkinShop, int index,int price, Sprite sprite)
    {
        this.price = price;
        this.sprite = sprite;
        this.uiSkinShop = uiSkinShop;
        this.index = index;

        skinPrice.text = this.price.ToString();
    }

    public void SetActive()
    {
        skinImage.sprite = sprite;
        priceGameObject.SetActive(true);
    }

    public void SetColor(Color color)
    {
        skinImage.color = color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"{index}번째 스킨 선택");

        bool isOwned = PlayerPrefs.GetInt($"{Constants.IS_OWNED_SKIN_}{index}") == 1 ? true : false;

        if ( isOwned == true)
        {
            uiSkinShop.ChangeSelectSkin(index);
        }
        else
        {
            uiSkinShop.TryPurchaseSkin(index, price);
        }
    }

}
