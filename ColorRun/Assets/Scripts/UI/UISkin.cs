using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UISkin : MonoBehaviour
{
    [SerializeField]
    private Image skinImage;
    [SerializeField]
    private GameObject priceGameObject;
    [SerializeField]
    private TextMeshProUGUI skinPrice;

    private int price;
    private Sprite sprite;


    public void Setup(int price, Sprite sprite)
    {
        this.price = price;
        this.sprite = sprite;

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
}
