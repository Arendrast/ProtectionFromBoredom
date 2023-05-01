using UnityEngine.SceneManagement;
using UnityEngine;

public class BackgroundMusicInMenu : MonoBehaviour
{
    [SerializeField] private AudioSource BackgroundMusic;
    private bool IsIndestructible;

    private void Start() => DontDestroyOnLoad(gameObject);
    
    private void Update()
    {
        if (!IsIndestructible)
            IsIndestructible = true;
        BackgroundMusic.mute = SceneManager.GetActiveScene().buildIndex is not (0 or 1 or 2);
        Debug.Log(BackgroundMusic.mute);
    }
}
