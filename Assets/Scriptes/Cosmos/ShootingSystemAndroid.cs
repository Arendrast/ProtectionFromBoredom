using UnityEngine;

public class ShootingSystemAndroid : MonoBehaviour
{
    [SerializeField] private ButtonShootingCosmos LeftButtonShootingCosmosScript;
    [SerializeField] private ButtonShootingCosmos RightButtonShootingCosmosScript;
    [SerializeField] private ButtonShootingCosmos LeftButtonShootingBulletCosmosScript;
    [SerializeField] private ButtonShootingCosmos RightButtonShootingBulletCosmosScript;
    private ShootingSystemLibrary SharedListLibraryScript;
    private float DelayShootingLeftBlaster = 0.5f;
    private float DelayShootingRightBlaster = 0.5f;

    private void Start() => SharedListLibraryScript = FindObjectOfType<ShootingSystemLibrary>();
    
    
    private void Update()
    {
        if (Time.timeScale == 1)
        {
            ShootManagementBullets();
            ShootManagementRays();
            UpdateDelay();
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
    
    private void ShootManagementRays()
    {
        if (SharedListLibraryScript.CartridgeTypeCounter % 2 is 1 or -1)
        {
            if (LeftButtonShootingCosmosScript.IsButtonPressed && SharedListLibraryScript.IsCanLeftRayShoot)
               SharedListLibraryScript.CreateRayInLeftShell();
            else
            {
                SharedListLibraryScript.LeftRay.SetActive(false);
                SharedListLibraryScript.IsShootingLeftRay = false;
            }

            if (RightButtonShootingCosmosScript.IsButtonPressed && SharedListLibraryScript.IsCanRightRayShoot)
                SharedListLibraryScript.CreateRayInRightShell();
            else
            {
                SharedListLibraryScript.RightRay.SetActive(false);
                SharedListLibraryScript.IsShootingRightRay = false;
            }
            SharedListLibraryScript.SoundRay.mute = !SharedListLibraryScript.IsShootingLeftRay && !SharedListLibraryScript.IsShootingRightRay;
        }
    }
    
    private void ShootManagementBullets()
    {
        if (SharedListLibraryScript.CartridgeTypeCounter % 2 == 0)
        {
            if (LeftButtonShootingBulletCosmosScript.IsButtonPressed && SharedListLibraryScript.IsCanLeftBlasterShoot && DelayShootingLeftBlaster < 0)
            {
                SharedListLibraryScript.DeterminingPositionsOfLeftBlasters();
                SharedListLibraryScript.CreateBulletInShell(SharedListLibraryScript.CurrentPositionForLeftBullets);
                DelayShootingLeftBlaster = 0.5f;
            }
            else
                SharedListLibraryScript.IsShootingLeftBlaster = false;

            if (RightButtonShootingBulletCosmosScript.IsButtonPressed && SharedListLibraryScript.IsCanRightBlasterShoot && DelayShootingRightBlaster < 0)
            {
                SharedListLibraryScript.DeterminingPositionsOfRightBlasters();
                SharedListLibraryScript.CreateBulletInShell(SharedListLibraryScript.CurrentPositionForRightBullets);
                DelayShootingRightBlaster = 0.5f;
            }
            else
                SharedListLibraryScript.IsShootingRightBlaster = false;
        }
    }

    private void UpdateDelay()
    {
        if (DelayShootingLeftBlaster > 0)
            DelayShootingLeftBlaster -= Time.deltaTime;
        
        if (DelayShootingRightBlaster > 0)
            DelayShootingRightBlaster -= Time.deltaTime;
    }
}
