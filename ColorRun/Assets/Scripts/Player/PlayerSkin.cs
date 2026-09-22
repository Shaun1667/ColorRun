using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [SerializeField]
    private Sprite[] skinSprites;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = skinSprites[PlayerPrefs.GetInt(Constants.SELECTED_SKIN_INDEX)];

    }    
}
