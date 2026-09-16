using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    [SerializeField] private AreaSpawner areaSpawner;
    [SerializeField] private PlayerColor playerColor;

    [Header("Player Die")]
    [SerializeField] private GameController gameController;
    [SerializeField] private GameObject playerRenderer;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private ParticleSystem playerDieEffect;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip[] clips;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ChangeColorBar"))
        {
            PlaySound(0);

            //플레이어 색상 변경
            playerColor.SetColor(collision.GetComponent<ChangeColorBarController>().CurrentColor);

            //이전 구역 삭제
            areaSpawner.DestroyArea();

            //구역 생성
            areaSpawner.SpawnArea();

            //충돌한 물체를 삭제
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Item"))
        {
            PlaySound(1);
            Destroy(collision.gameObject);
            playerData.CurrentScore++;
        }

        if (collision.CompareTag("Obstacle"))
        {
            if(collision.GetComponent<SpriteRenderer>().color == playerColor.CurrentColor)
            {
                PlaySound(2);
                Destroy(collision.gameObject);
                playerData.CurrentScore++; //플레이어 점수 증가
                Debug.Log("점수" + playerData.CurrentScore);
            }
            else
            {
                PlaySound(3);
                //todo 게임 오버
                Debug.Log("Player Die");
                //플레이어 사망 효과 색상 설정
                ParticleSystem.MainModule main = playerDieEffect.main;
                main.startColor = playerColor.CurrentColor;
                //플레이어 렌더러, 충돌 컴포넌트 비활성화
                playerRenderer.SetActive(false);
                playerCollider.enabled = false;
                //플레이어 사망 효과 재생
                playerDieEffect.gameObject.SetActive(true);
                //GameController에 있는 GameOver()메소드 호출
                gameController.GameOver();
            }
        }
    }

    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(clips[index]);
    }
}
