using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private AreaSpawner areaSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ChangeColorBar"))
        {
            areaSpawner.DestroyArea();  // 이전 구역 삭제
            areaSpawner.SpawnArea();    // 이후 구역 생성
            Destroy(collision.gameObject);
        }
    }
}
