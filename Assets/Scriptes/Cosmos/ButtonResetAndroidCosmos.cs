using UnityEngine;

public class ButtonResetAndroidCosmos : MonoBehaviour
{
    private ShootingSystemLibrary LinkOnScriptShootingSystemLibrary;

    private void Start() => LinkOnScriptShootingSystemLibrary = FindObjectOfType<ShootingSystemLibrary>();

    public void Reset() => LinkOnScriptShootingSystemLibrary.CartridgeTypeCounter++;
}
