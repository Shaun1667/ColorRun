using TMPro;
using UnityEngine;

public class UIArchive : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textStarData;
    [SerializeField]
    private TextMeshProUGUI textGamePlayData;
    [SerializeField]
    private TextMeshProUGUI textDestroyAllObject;
    [SerializeField]
    private GameObject colorPrefab;
    [SerializeField]
    private Transform colorParent;

    [SerializeField]
    private PlayerData playerData;
    private TextMeshProUGUI[] textDestroyObjects;

}