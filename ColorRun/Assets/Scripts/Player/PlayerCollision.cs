using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //이전 구역을 삭제
    //충돌한 물체를 삭제

    [SerializeField]
    private AreaSpawner areaSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ChangeColorBar"))
        {
            //이전 물체를삭제
            //충돌한 구역을 삭제
            areaSpawner.SpawnArea();
            areaSpawner.DestroyArea();
            Destroy(collision.gameObject);
        }
    }
}
