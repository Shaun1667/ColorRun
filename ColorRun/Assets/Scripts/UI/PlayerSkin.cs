using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [SerializeField]
    private Sprite[] skinSprite;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = skinSprite[PlayerPrefs.GetInt(Constants.SELECTED_SKIN_INDEX)];

    }
}
