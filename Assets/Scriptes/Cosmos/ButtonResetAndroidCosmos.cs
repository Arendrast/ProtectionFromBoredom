using UnityEngine;

public class ButtonResetAndroidCosmos : MonoBehaviour
{
    private ShootingSystemLibrary _shootingSystemLibrary;
    private void Start() => _shootingSystemLibrary = FindObjectOfType<ShootingSystemLibrary>();
    public void Reset() => _shootingSystemLibrary.AddValueInCartridgeTypeCounter();
}
