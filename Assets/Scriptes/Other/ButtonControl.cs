using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public void OpenMenuGames() => SceneManager.LoadScene(2);
    public void OpenSceneWithDonate() => SceneManager.LoadScene(1);
    public void CloseMenuGame() => SceneManager.LoadScene(0);
    public void CloseLevel() => SceneManager.LoadScene(2);
    public void StartNewGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void ExitGame() => Application.Quit();
}
