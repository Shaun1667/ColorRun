using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onPlayerDie;

    [SerializeField]
    private ParticleSystem playerDieEffect;

    [SerializeField]
    private PlayerMovement playerMovement;

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

            //플레이어 이동 속도 증가
            playerMovement.IncreaseMoveSpeed();

            //충돌한 물체를 삭제...
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Item"))
        {
            PlaySound(1);
            Destroy(other.gameObject);
            playerData.CurrentStar++; // 플레이어 점수 증가
        }

        if (other.CompareTag("Obstacle"))
        {
            if (other.GetComponent<SpriteRenderer>().color == playerColor.CurrentColor)
            {
                PlaySound(2);
                Destroy(other.gameObject);
                playerData.CurrentScore++; // 플레이어 점수 증가
                playerData.AddDestroyObjectCountAt(playerColor.CurrentColor);
            }
            else
            {
                PlaySound(3);
                //게임오버
                //플레이어 사망 효과 색상 설정
                ParticleSystem.MainModule main = playerDieEffect.main;
                main.startColor = playerColor.CurrentColor;
                onPlayerDie?.Invoke();
            }

        }
    }

    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(clips[index]);
    }
}
