using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    /*
    [Header("Player Die")]
    [SerializeField]
    private GameController gameController;
        [SerializeField]
    private GameObject playerRenderer;
        [SerializeField]
    private Collider2D playerCollider;

    */

    [SerializeField]
    private UnityEvent onPlayerDie;

    [SerializeField]
    private ParticleSystem playerDieEffect;

    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private AreaSpawner areaSpawner;

    [SerializeField]
    private PlayerColor playerColor;

    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip[] clips;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ChangeColorBar"))
        {
            PlaySound(0); // 예시: 첫 번째 오디오 클립 재생

            // 플레이어 색상 변경
            playerColor.SetColor(collision.GetComponent<ChangeColorBarController>().CurrentColor);

            areaSpawner.DestroyArea(); //이전 구역 삭제
            areaSpawner.SpawnArea();  // 새로운 구역 생성
            Destroy(collision.gameObject); // ChangeColorBar 오브젝트 삭제
        }

        if(collision.CompareTag("Item"))
        {
            PlaySound(1);
            Destroy(collision.gameObject);
            playerData.CurrentStarCount++; //별 개수 증가
        }

        if (collision.CompareTag("Obstacle"))
        {
            if (collision.GetComponent<SpriteRenderer>().color == playerColor.CurrentColor)
            {
                PlaySound(2);
                Destroy(collision.gameObject);
                playerData.CurrentScore ++; // 점수 증가
            }
            else
            {
                PlaySound(3);
                Debug.Log("Game Over!");
                //플레이어 사망 효과 색상 설정
                ParticleSystem.MainModule main = playerDieEffect.main;
                main.startColor = playerColor.CurrentColor;
                /*
                //플레이어 렌더러 충돌 컴포넌트 비활성화
                playerRenderer.SetActive(false);
                playerCollider.enabled = false;
                //플레이어 사망 효과 재생
                playerDieEffect.gameObject.SetActive(true);
                //GameController에 있는 GameOver()메소드 호출
                gameController.GameOver();
                */
                onPlayerDie?.Invoke();


            }
        }
    }

    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(clips[index]);
    }
}
