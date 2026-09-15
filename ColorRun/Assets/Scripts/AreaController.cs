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
        // 패턴 오브젝트 색상 설정
        colorBar.SetColor(areaColor);
        for(int i = 0; i < patterns.Length; i++)
        {
            patterns[i].SetColor(colors, areaColor);
        }
        // 비 패턴 오브젝트 색상 설정
        for(int i = 0; i < nonPatterns.Length; i++)
        {
            nonPatterns[i].color = colors[Random.Range(0, colors.Length)];
        }

        // 별 아이템 오브젝트 활성/비활성 설정
        int[] starIndexs = Utils.RandomNumerics(stars.Length, stars.Length);
        for(int i = 0; i < stars.Length; ++i)
        {
            stars[i].SetActive(false);
        }
        for(int i = 0; i < stars.Length; ++i)
        {
            stars[starIndexs[i]].SetActive(true);

            if (activeStarCount <= i+1)
            {
                break;
            }
        }
    }
}