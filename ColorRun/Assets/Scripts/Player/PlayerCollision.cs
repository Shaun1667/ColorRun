using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip[] clips;
    private AudioSource audioSource;
    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private PlayerColor playerColor;
    [SerializeField]
    private AreaSpawner areaSpawner;
    /*[Header("Player Die")]
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject playerRenderer;
    [SerializeField]
    private Collider2D playerCollider;*/
    [SerializeField]
    private UnityEvent onPlayerDie;
    [SerializeField]
    private ParticleSystem playerDieEffect;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ChangeColorBar"))
        {
            PlaySound(3);
            //플레이어 색상 변경
            playerColor.SetColor(collision.GetComponent<ChangeColorBarController>().CurrentColor);
            //이전 구역 삭제
            areaSpawner.DestryArea();

            // 구역 생성
            areaSpawner.SpawnArea();

            // 충돌한 물체를 삭제
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Item"))
        {
            PlaySound(2);           
            // 충돌한 물체를 삭제
            Destroy(collision.gameObject);
            playerData.CurrentStarCount++;
        }
        if (collision.CompareTag("Obstacle"))
        {
            if (collision.GetComponent<SpriteRenderer>().color == playerColor.CurrentColor)
            {
                PlaySound(1);
                // 충돌한 물체를 삭제
                Destroy(collision.gameObject);
                playerData.CurrentScore++; //플레이어 점수 증가
            }
            else
            {
                PlaySound(0);
                Debug.Log("Player Die");
                //플레이어 사망 효과 색상 설정
                ParticleSystem.MainModule main = playerDieEffect.main;
                main.startColor = playerColor.CurrentColor;
                /*
                 //플레이어 렌더러, 충돌 컴퍼넌트 비활성화
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
