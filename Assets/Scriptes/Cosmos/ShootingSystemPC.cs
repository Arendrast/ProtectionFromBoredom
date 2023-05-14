using UnityEngine;

public class ShootingSystemPC : MonoBehaviour
{
    private ShootingSystemLibrary _shootingSystemLibrary;
    
    private void Start() => _shootingSystemLibrary = FindObjectOfType<ShootingSystemLibrary>();
    
    private bool _isDisableUnnecessary;
    
    private void Update()
    {
        if (Time.timeScale == 1)
        {
            ShootManagementBlasters();
            ShootManagementRays();
            _shootingSystemLibrary.ChangeCartridgeType();
            _shootingSystemLibrary.SoundRay.mute = !_shootingSystemLibrary.IsShootingLeftRay && !_shootingSystemLibrary.IsShootingRightRay;
        }
        else
        {
            if (!_isDisableUnnecessary)
            {
                _shootingSystemLibrary.DisableUnnecessaryWhenLosing();
                _isDisableUnnecessary = true;
            }
        }
    }
    
    private void ShootManagementBlasters()
    {
        if (_shootingSystemLibrary.CartridgeTypeCounter % 2 == 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && _shootingSystemLibrary.IsCanLeftBlasterShoot)
            {
                _shootingSystemLibrary.DeterminePositionOfLeftBlasters();
                _shootingSystemLibrary.CreateBulletInBlaster(_shootingSystemLibrary.CurrentPositionSpawnOfLeftBullets);
            }
            else
                _shootingSystemLibrary.SetIsShootingLeftBlaster(false);

            if (Input.GetKeyDown(KeyCode.Mouse1) &&  _shootingSystemLibrary.IsCanRightBlasterShoot)
            {
                _shootingSystemLibrary.DeterminePositionOfRightBlasters();
                _shootingSystemLibrary.CreateBulletInBlaster(_shootingSystemLibrary.CurrentPositionSpawnOfRightBullets);
            }
            else
                _shootingSystemLibrary.SetIsShootingRightBlaster(false);
        }
    }

    private void ShootManagementRays()
    {
        if (_shootingSystemLibrary.CartridgeTypeCounter % 2 == 1 || _shootingSystemLibrary.CartridgeTypeCounter % 2 == -1)
        {
            if (Input.GetKey(KeyCode.Mouse0) &&  _shootingSystemLibrary.IsCanLeftRayShoot)
                _shootingSystemLibrary.CreateRayInLeftBlaster();
            else
            {
                _shootingSystemLibrary.LeftRay.SetActive(false);
                _shootingSystemLibrary.SetIsShootingLeftRay(false);
            }

            if (Input.GetKey(KeyCode.Mouse1) &&  _shootingSystemLibrary.IsCanRightRayShoot)
                _shootingSystemLibrary.CreateRayInRightShell();
            else
            {
                _shootingSystemLibrary.RightRay.SetActive(false);
                _shootingSystemLibrary.SetIsShootingRightRay(false);
            }
        } 
    }
}
