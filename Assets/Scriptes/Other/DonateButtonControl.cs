using UnityEngine;
using UnityEngine.SceneManagement;

public class DonateButtonControl : MonoBehaviour
{
    public void OpenBoosty() => Application.OpenURL("https://boosty.to/arendrast");
    public void CloseDonateMenu() => SceneManager.LoadScene(0);
}
