using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ChangeColorBar"))
        {
            PlaySound(0);
            //플레이어 색상 변경
            playerColor.SetColor(collision.GetComponent<ChangeColorBarController>().CurrentColor);
            //이전 구역 삭제...
            areaSpawner.DestroyArea();
            //구역 생성
            areaSpawner.SpawnArea();
            //충돌한 물체를 삭제...
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Item"))
        {
            PlaySound(1);
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("Obstacle"))
        {
            if(collision.GetComponent<SpriteRenderer>().color == playerColor.CurrentColor)
            {
                PlaySound(2);
                Destroy(collision.gameObject);
            }
            else
            {
                PlaySound(3);
                //todo 게임오버
                Debug.Log("Player Die");
            }
        }
    }

    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(clips[index]);
    }
}
