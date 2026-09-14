using UnityEngine;

public class AreaController : MonoBehaviour
{
    [SerializeField]
    private ChangeColorBarController colorBar;
    [SerializeField]
    private PatternController[] patterns;

    [SerializeField]
    private SpriteRenderer[] nonPatterns;
    [SerializeField]
    private int activeStarCount = 10;
    [SerializeField]
    private GameObject[] stars;

    public void Setup(Color[] colors)
    {
        Color areaColor = colors[Random.Range(0, colors.Length)];
        colorBar.SetColor(areaColor);
        // 패턴 오브젝트 색상 설정
        for (int i = 0; i < patterns.Length; i++)
        {
            patterns[i].SetColor(colors, areaColor);
        }
        //비 패턴 오브젝트 색상 설정
        for (int i = 0; i < nonPatterns.Length; i++)
        {
            nonPatterns[i].color = colors[Random.Range(0,colors.Length)];
        }
        // 별
        int[] starIndexs = Utils.RandomNumberics(stars.Length, stars.Length);

        for (int i = 0;i < starIndexs.Length; ++i)
        {
            stars[i].SetActive(false);
        }
        for (int i = 0; i < starIndexs.Length; ++i)
        {
            stars[starIndexs[i]].SetActive(true);

            if(activeStarCount <= i+1)
            {
                break;
            }
        }

    }

}
