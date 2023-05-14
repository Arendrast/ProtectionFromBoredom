using UnityEngine;
using UnityEngine.UI;

public class IndicatorNumberRays : MonoBehaviour
{
    [Header("Strips")]
    [SerializeField] private Image _imageComponentOfIndicatiorOfLeftRay;
    [SerializeField] private Image _imageComponentOfIndicatiorOfRightRay;
    [SerializeField] private Sprite _fiveChargeStrip, _fourChargeStrip, _threeChargeStrip, _twoChargeStrip, _oneChargeStrip, _zeroChargeStrip;
    
    private int _numberOfChargeOfLeftRay = 5;
    private int _numberOfChargeOfRightRay = 5;
    
    private const float _timeChargeRefresh = 2.5f;
    private const float _timeOfLossOfCharge = 1f;
    private float _timeToChargeBoostOfStripOfLeftRay = 2.5f;
    private float _timeToChargeBoostOfStripOfRightRay = 2.5f;
    private float _timeToDischargeOfStripOfLeftRay = 1f;
    private float _timeToDischargeOfStripOfRightRay = 1f;

    [Space] [Header("Links")] [SerializeField]
    private ShootingSystemLibrary _shootingSystemLibrary;

    private void Update()
    {
        UpdateDisplayOfIndicator(ref _imageComponentOfIndicatiorOfLeftRay, _numberOfChargeOfLeftRay);
        UpdateDisplayOfIndicator(ref _imageComponentOfIndicatiorOfRightRay, _numberOfChargeOfRightRay);
        UpdateTimeBeforeAddingCharge(ref _timeToChargeBoostOfStripOfLeftRay, ref _numberOfChargeOfLeftRay);
        UpdateTimeBeforeAddingCharge(ref _timeToChargeBoostOfStripOfRightRay, ref _numberOfChargeOfRightRay);
        UpdateTimeBeforeDecreaseCharge(_shootingSystemLibrary.IsShootingLeftRay, ref _timeToDischargeOfStripOfLeftRay, ref _numberOfChargeOfLeftRay);
        UpdateTimeBeforeDecreaseCharge(_shootingSystemLibrary.IsShootingRightRay, ref _timeToDischargeOfStripOfRightRay, ref _numberOfChargeOfRightRay);
        AdjustingShootingPermission();
        
    }
    private void UpdateDisplayOfIndicator(ref Image imageComponent, int numberOfCharge)
    {
        imageComponent.sprite = numberOfCharge switch
        {
            5 => _fiveChargeStrip,
            4 => _fourChargeStrip,
            3 => _threeChargeStrip,
            2 => _twoChargeStrip,
            1 => _oneChargeStrip,
            _ => _zeroChargeStrip
        };
    }

    private void AdjustingShootingPermission()
    {
        _shootingSystemLibrary.SetIsCanShootingLeftRay(_numberOfChargeOfLeftRay != 0);
        _shootingSystemLibrary.SetIsCanShootingRightRay(_numberOfChargeOfRightRay != 0);
    }

    private void UpdateTimeBeforeAddingCharge(ref float timeToChargeUpdate, ref int numberOfCharge)
    {
        if (timeToChargeUpdate < 0)
        {
            numberOfCharge++;
            timeToChargeUpdate = _timeChargeRefresh;
        }
        if (numberOfCharge < 5)
            timeToChargeUpdate -= Time.deltaTime;
    }

    private void UpdateTimeBeforeDecreaseCharge(bool isShootingRay, ref float timeToDischarge, ref int numberOfCharge)
    {
        if (isShootingRay)
            timeToDischarge -= Time.deltaTime;

        if (timeToDischarge < 0)
        {
            numberOfCharge--;
            timeToDischarge = _timeOfLossOfCharge;
        }
    }
}
