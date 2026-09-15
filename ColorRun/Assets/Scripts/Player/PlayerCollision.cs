using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // 이전 구역 삭제...
    // 충돌한 물체를 삭제...
    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip[] clips;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    [SerializeField]
    private PlayerColor playerColor;

    [SerializeField]
    private AreaSpawner areaSpawner;





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
            }
            else
            {
                PlaySound(3);
                //게임오버
                Debug.Log("Player Die");
            }

        }
    }

    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(clips[index]);
    }
}
