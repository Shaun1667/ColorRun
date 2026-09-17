using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISkin : MonoBehaviour
{
    [SerializeField]
    private Image skinIcon;
    [SerializeField]
    private TextMeshProUGUI priceText;
    [SerializeField]
    private Button button;

    [Header("상태별 표시 텍스트")]
    [SerializeField]
    private string ownedText = "보유중";
    [SerializeField]
    private string equippedText = "장착중";

    private Action<int> onClick;
    private int index;
    private Color skinColor;

    private void Awake()
    {
        if (button == null) button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }

    private void OnClickButton()
    {
        onClick?.Invoke(index);
    }

    public void Setup(SkinData data, int skinIndex, Action<int> onClickCallback)
    {
        index = skinIndex;
        onClick = onClickCallback;
        skinColor = data.color;
        priceText.text = data.price.ToString();
    }

    public void Refresh(bool owned, bool equipped)
    {
        if (equipped)
        {
            skinIcon.color = skinColor;
            priceText.text = equippedText;
        }
        else if (owned)
        {
            skinIcon.color = skinColor;
            priceText.text = ownedText;
        }
        else
        {
            //잠금 상태 : 어둡게 표시
            Color locked = skinColor * 0.4f;
            locked.a = 1f;
            skinIcon.color = locked;
        }
    }
}
