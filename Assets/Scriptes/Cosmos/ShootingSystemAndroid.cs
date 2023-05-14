using UnityEngine;

public class ShootingSystemAndroid : MonoBehaviour
{
    [SerializeField] private ButtonShootingCosmos _leftButtonShootingCosmos;
    [SerializeField] private ButtonShootingCosmos _rightButtonShootingCosmos;

    private ShootingSystemLibrary _shootingSystemLibrary;
    
    private float _delayOfShootingOfLeftBlaster = 0.5f;
    private float _delayOfShootingOfRightBlaster = 0.5f;

    private bool _isDisableUnnecessary;

    private void Start() => _shootingSystemLibrary = GetComponent<ShootingSystemLibrary>();
    
    private void Update()
    {
        if (Time.timeScale == 1)
        {
            ShootManagementBlasters();
            ShootManagementRays();
            UpdateDelay();
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
            if (_leftButtonShootingCosmos.IsButtonPressed && _shootingSystemLibrary.IsCanLeftBlasterShoot && _delayOfShootingOfLeftBlaster < 0)
            {
                _shootingSystemLibrary.DeterminePositionOfLeftBlasters();
                MakeBlasterShot(ref _delayOfShootingOfLeftBlaster, _shootingSystemLibrary.CurrentPositionSpawnOfLeftBullets);
            }
            else
                _shootingSystemLibrary.SetIsShootingLeftRay(false);

            if (_rightButtonShootingCosmos.IsButtonPressed && _shootingSystemLibrary.IsCanRightBlasterShoot && _delayOfShootingOfRightBlaster < 0)
            {
                _shootingSystemLibrary.DeterminePositionOfRightBlasters();
                MakeBlasterShot(ref _delayOfShootingOfRightBlaster, _shootingSystemLibrary.CurrentPositionSpawnOfRightBullets);
            }
            else
                _shootingSystemLibrary.SetIsShootingRightRay(false);
        }
    }

    private void MakeBlasterShot(ref float delayOfShooting, Vector2 currentPosition)
    {
        _shootingSystemLibrary.CreateBulletInBlaster(currentPosition);
        delayOfShooting = 0.5f;
    }
    
    private void ShootManagementRays()
    {
        if (_shootingSystemLibrary.CartridgeTypeCounter % 2 == 1 || _shootingSystemLibrary.CartridgeTypeCounter % 2 == 1)
        {
            if (_leftButtonShootingCosmos.IsButtonPressed && _shootingSystemLibrary.IsCanLeftRayShoot)
                _shootingSystemLibrary.CreateRayInLeftBlaster();
            else
            {
                _shootingSystemLibrary.LeftRay.SetActive(false);
                _shootingSystemLibrary.SetIsShootingLeftRay(false);
            }

            if (_rightButtonShootingCosmos.IsButtonPressed && _shootingSystemLibrary.IsCanRightRayShoot)
                _shootingSystemLibrary.CreateRayInRightShell();
            else
            {
                _shootingSystemLibrary.RightRay.SetActive(false);
                _shootingSystemLibrary.SetIsShootingRightRay(false);
            }
            _shootingSystemLibrary.SoundRay.mute = !_shootingSystemLibrary.IsShootingLeftRay && !_shootingSystemLibrary.IsShootingRightRay;
        }
    }
    
    private void UpdateDelay()
    {
        if (_delayOfShootingOfLeftBlaster > 0)
            _delayOfShootingOfLeftBlaster -= Time.deltaTime;
        
        if (_delayOfShootingOfRightBlaster > 0)
            _delayOfShootingOfRightBlaster -= Time.deltaTime;
    }
}
