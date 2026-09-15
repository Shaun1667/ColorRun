using UnityEngine;

public class CameraOrthographicSize : MonoBehaviour
{
    private void Awake()
    {
        float screenAspectRatio = (float)Screen.width / Screen.height;
        float orthographicSize = (float)(6 - (screenAspectRatio - 0.485f) * 11f);
        if(orthographicSize < 4)
        {
            orthographicSize = 4;
        }

        Camera.main.orthographicSize = orthographicSize;
    }
}
