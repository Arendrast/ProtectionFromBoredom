using UnityEngine;

public class SpawnBackgroundSound : MonoBehaviour
{
    [SerializeField] private GameObject _Prefab;
    private void Start()
    {
        if (FindObjectOfType<BackgroundMusicInMenu>() == null)
            Instantiate(_Prefab);
    }
}
