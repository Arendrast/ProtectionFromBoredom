using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelAdapter : MonoBehaviour
{
    public void StartLevelSnake() => SceneManager.LoadScene(3);
    public void StartLevelRunner() => SceneManager.LoadScene(4);
    public void StartLevelCosmos() => SceneManager.LoadScene(5);
}

