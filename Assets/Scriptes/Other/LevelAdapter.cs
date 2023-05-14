using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelAdapter : MonoBehaviour
{
    public void OpenLevelSnake() => SceneManager.LoadScene(3);
    public void OpenLevelRunner() => SceneManager.LoadScene(4);
    public void OpenLevelCosmos() => SceneManager.LoadScene(5);
}

