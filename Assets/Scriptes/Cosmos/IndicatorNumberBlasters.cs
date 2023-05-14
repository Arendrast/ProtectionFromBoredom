using UnityEngine;
using UnityEngine.UI;

public class IndicatorNumberBlasters : MonoBehaviour
{ 
    [Header("Strips")]
    
    [SerializeReference] private Image _imageComponentOfIndicatorOfLeftBlaster;
    [SerializeReference] private Image _imageComponentOfIndicatorOfRightBlaster;
    
    [SerializeField] private Sprite _fiveChargeStrip,_fourChargeStrip, _threeChargeStrip, _twoChargeStrip, _oneChargeStrip, _zeroChargeStrip;
    
    private int _numberOfLeftBlasterCharge = 5;
    private int _numberOfRightBlasterCharge = 5;
    
    private const float _timeChargeRefresh = 2.5f;
    private float _timeToRechargeLeftBlaster = 2.5f;
    private float _timeToRechargeRightBlaster = 2.5f;
    
    private ShootingSystemLibrary _shootingSystemLibrary;

    private void Start() => _shootingSystemLibrary = GetComponent<ShootingSystemLibrary>();
    
    private void Update()
    {
        AdjustingShootingPermission();
        CheckingShootingBlaster();
        UpdateDisplayOfIndicator(ref _imageComponentOfIndicatorOfRightBlaster, _numberOfRightBlasterCharge);
        UpdateDisplayOfIndicator(ref _imageComponentOfIndicatorOfLeftBlaster, _numberOfLeftBlasterCharge);
        UpdateTimeBeforeAddingCharge(ref _timeToRechargeRightBlaster, ref _numberOfRightBlasterCharge);
        UpdateTimeBeforeAddingCharge(ref _timeToRechargeLeftBlaster, ref _numberOfLeftBlasterCharge);
    }
    private void CheckingShootingBlaster()
    {
        if (_shootingSystemLibrary.IsShootingLeftBlaster)
            _numberOfLeftBlasterCharge--;

        if (_shootingSystemLibrary.IsShootingRightBlaster)
            _numberOfRightBlasterCharge--;
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
        _shootingSystemLibrary.SetIsCanShootingRightBlaster(_numberOfRightBlasterCharge > 0);
        _shootingSystemLibrary.SetIsCanShootingLeftBlaster(_numberOfLeftBlasterCharge > 0);
        Debug.Log(_numberOfLeftBlasterCharge);
        Debug.Log(_numberOfRightBlasterCharge);
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
}
