using System.Collections;
using UnityEngine;

public class MoveHorizontal : MonoBehaviour
{
    [SerializeField]
    private float start;
    [SerializeField]
    private float end;
    [SerializeField]
    private float unitPerSecond = 1f;


    private void OnEnable()
    {
        StartCoroutine(nameof(Process));
    }
    private void OnDisable()
    {
        StopCoroutine(nameof(Process));
    }

    IEnumerator  Process()
    {
        while (true)
        {
            yield return StartCoroutine(MoveTo(start,end));

            yield return StartCoroutine(MoveTo(end, start));

        }
    }

    IEnumerator MoveTo(float start, float end)
    {
        float percent = 0;
        float distance = Mathf.Abs(end - start);
        float moveTime = distance * unitPerSecond;

        while(percent < 1)
        {
            percent += Time.deltaTime / moveTime;

            Vector3 position = transform.position;
            position.x = Mathf.Lerp(start, end, percent);

            yield return null;
        }
    }
}
