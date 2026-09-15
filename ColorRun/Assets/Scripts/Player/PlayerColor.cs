using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private TrailRenderer trailRenderer;

    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
        trailRenderer.startColor = color;
        trailRenderer.endColor = color;
    }
}
