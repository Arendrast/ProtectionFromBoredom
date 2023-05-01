using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public void ButtonPlay() => SceneManager.LoadScene(2);
    public void ButtonDonate() => SceneManager.LoadScene(1);
    public void CloseMenuGame() => SceneManager.LoadScene(0);
    public void CloseLevel() => SceneManager.LoadScene(2);
    public void ButtonNewGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void ExitGame() => Application.Quit();
}
