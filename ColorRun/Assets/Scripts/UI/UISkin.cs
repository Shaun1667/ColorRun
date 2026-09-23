using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class UISkin : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Image skinImage;
    [SerializeField]
    private GameObject priceGameObject;
    [SerializeField]
    private TextMeshProUGUI skinPrice;

    private UISkinShop uiskinShop;
    private int index;
    private int price;
    private Sprite sprite;

    public void Setup(UISkinShop uiskinShop,int index, int price, Sprite sprite)
    {
        this.price = price;
        this.sprite = sprite;
        this.uiskinShop = uiskinShop;
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

        if(isOwned == true)
        {
            uiskinShop.ChangeSelectSkin(index);

        }
        else
        {
            uiskinShop.TryPurchaseSkin(index, price);
        }
    }
}
