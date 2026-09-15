using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
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
        }

        if (collision.CompareTag("Obstacle"))
        {
            if (collision.GetComponent<SpriteRenderer>().color == playerColor.CurrentColor)
            {
                PlaySound(2);
                Destroy(collision.gameObject);
            }
            else
            {
                PlaySound(3);
                // 게임 오버 처리
                Debug.Log("Game Over!");
            }
        }
    }

    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(clips[index]);
    }
}
