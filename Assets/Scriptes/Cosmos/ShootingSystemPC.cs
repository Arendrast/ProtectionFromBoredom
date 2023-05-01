using UnityEngine;

public class ShootingSystemPC : MonoBehaviour
{
    private ShootingSystemLibrary SharedListLibraryScript;
    
    private void Start() => SharedListLibraryScript = FindObjectOfType<ShootingSystemLibrary>();
    
    private void Update()
    {
        if (Time.timeScale == 1)
        {
            ShootManagementBullets();
            ShootManagementRays();
            SharedListLibraryScript.ChangingCartridgeType();
        }
        else
        {
            while (!SharedListLibraryScript.OneCheckOnLose)
            {
                SharedListLibraryScript.RightRay.SetActive(false);
                SharedListLibraryScript.LeftRay.SetActive(false);
                SharedListLibraryScript.IsShootingLeftRay = false;
                SharedListLibraryScript.IsShootingRightRay = false;
                SharedListLibraryScript.SoundRay.mute = true;
                SharedListLibraryScript.OneCheckOnLose = true;
            }
        }
    }
    
    private void ShootManagementBullets()
    {
        if (SharedListLibraryScript.CartridgeTypeCounter % 2 == 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && SharedListLibraryScript.IsCanLeftBlasterShoot)
            {
                SharedListLibraryScript.DeterminingPositionsOfLeftBlasters();
                SharedListLibraryScript.CreateBulletInShell(SharedListLibraryScript.CurrentPositionForLeftBullets);
            }
            else
                SharedListLibraryScript.IsShootingLeftBlaster = false;

            if (Input.GetKeyDown(KeyCode.Mouse1) &&  SharedListLibraryScript.IsCanRightBlasterShoot)
            {
                SharedListLibraryScript.DeterminingPositionsOfRightBlasters();
                SharedListLibraryScript.CreateBulletInShell(SharedListLibraryScript.CurrentPositionForRightBullets);
            }
            else
                SharedListLibraryScript.IsShootingRightBlaster = false;
            
        }
    }

    private void ShootManagementRays()
    {
        if (SharedListLibraryScript.CartridgeTypeCounter % 2 is 1 or -1)
        {
            if (Input.GetKey(KeyCode.Mouse0) &&  SharedListLibraryScript.IsCanLeftRayShoot)
                SharedListLibraryScript.CreateRayInLeftShell();
            else
            {
                SharedListLibraryScript.LeftRay.SetActive(false);
                SharedListLibraryScript.IsShootingLeftRay = false;
            }

            if (Input.GetKey(KeyCode.Mouse1) &&  SharedListLibraryScript.IsCanRightRayShoot)
                SharedListLibraryScript.CreateRayInRightShell();
            else
            {
                SharedListLibraryScript.RightRay.SetActive(false);
                SharedListLibraryScript.IsShootingRightRay = false;
            }
            SharedListLibraryScript.SoundRay.mute = !SharedListLibraryScript.IsShootingLeftRay && !SharedListLibraryScript.IsShootingRightRay;
        } 
    }
}
