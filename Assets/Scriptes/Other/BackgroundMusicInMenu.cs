using UnityEngine.SceneManagement;
using UnityEngine;

public class BackgroundMusicInMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusic;
    private void Start() => DontDestroyOnLoad(gameObject);
    
    private void Update() => _backgroundMusic.mute = SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 2;
    
}
