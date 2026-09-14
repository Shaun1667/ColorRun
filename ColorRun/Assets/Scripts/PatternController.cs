using UnityEngine;

public class PatternController : MonoBehaviour
{
    [SerializeField]
    private bool isColorControll = true;

    public void SetColor(Color[] colors, Color areaColor)
    {
        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].color = colors[Random.Range(0,colors.Length)];
        }

        if (isColorControll)
        {
            int areaColorIndex = Random.Range(0, renderers.Length);
            renderers[areaColorIndex].color = areaColor;
        }
    }


}
