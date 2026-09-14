using UnityEngine;

public class pla : MonoBehaviour
{
    //이전 구역 삭제...
    //출돌한 물체를 삭제...

    [SerializeField]
    private AreaSpawner areaSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("ChangeColorBar"))
        {
            //이전 구역 삭제

            areaSpawner.DestroyArea();
            //구역 생성
            areaSpawner.SpawnArea();
            //충돌한 물체 삭제
            Destroy(collision.gameObject);
        }


    }
    }

