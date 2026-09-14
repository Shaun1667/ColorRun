using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private AreaSpawner areaSpawner;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ChangeColorBar"))
        {
            areaSpawner.DestroyArea();
            areaSpawner.SpawnArea();
            Destroy(collision.gameObject);
        }
    }
}
