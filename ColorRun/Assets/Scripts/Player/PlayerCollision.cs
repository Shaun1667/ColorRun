using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("Player Die")]
    [SerializeField]
    private GameObject playerRenderer;
    [SerializeField]
    private Collider2D playerCollider;
    [SerializeField]
    private ParticleSystem playerDieEffect;
    [SerializeField]
    private GameController gameController;

    [SerializeField]
    private PlayerData playerData;
    // 이전 구역 삭제...
    // 충돌한 물체를 삭제...
    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip[] clips;
    private AudioSource audioSource;

    [SerializeField]
    private PlayerColor playerColor;

    [SerializeField]
    private AreaSpawner areaSpawner;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ChangeColorBar"))
        {
            PlaySound(0);
            //플레이어 색상 변경
            playerColor.SetColor(other.GetComponent<ChangeColorBarController>().currentColor);

            // 이전 구역 삭제...
            areaSpawner.DestroyArea();

            //구역 생성
            areaSpawner.SpawnArea();

            //충돌한 물체를 삭제...
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Item"))
        {
            PlaySound(1);
            Destroy(other.gameObject); 
        }

        if (other.CompareTag("Obstacle"))
        {
            if (other.GetComponent<SpriteRenderer>().color == playerColor.CurrentColor)
            {
                PlaySound(2);
                Destroy(other.gameObject);
                playerData.CurrentScore++; // 플레이어 점수 증가
            }
            else
            {
                PlaySound(3);
                //게임오버
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
