using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private TrailRenderer trailRenderer;

    public Color CurrentColor {  get; private set; }



    public void SetColor(Color color)
    {
        CurrentColor = color;
        spriteRenderer.color = color;
        trailRenderer.startColor = color;
        trailRenderer.endColor = color;

    }
}
