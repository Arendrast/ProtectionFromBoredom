using UnityEngine;
using UnityEngine.UI;

public class IndicatorNumberRays : MonoBehaviour
{
    [Header("Strips")]
    [SerializeField] private Image ImageComponentLeftRayChargeStrips;
    [SerializeField] private Image ImageComponentRightRayChargeStrips;
    [SerializeField] private Sprite FiveChargeStrips;
    [SerializeField] private Sprite FourChargeStrips;
    [SerializeField] private Sprite ThreeChargeStrips;
    [SerializeField] private Sprite TwoChargeStrips;
    [SerializeField] private Sprite OneChargeStrips;
    [SerializeField] private Sprite ZeroChargeStrips;
    private int NumberLeftRayCharge = 5;
    private int NumberRightRayCharge = 5;
    private const float TimeChargeRefresh = 2.5f;
    private float ChargeRefreshTimerLeftRay = 2.5f;
    private float ChargeRefreshTimerRightRay = 2.5f;
    private const float TimeOfLossOfCharge = 1f;
    private float ChargeDischargeTimerLeftRay = 1f;
    private float ChargeDischargeTimerRightRay = 1f;

    [Space] [Header("Links")] [SerializeField]
    private ShootingSystemLibrary ShootingSystemLibraryScript;

    private void Update()
    {
        DisplayingChargesRightRay();
        DisplayingChargesLeftRay();
        UpdateTimerRefreshStripesRightRay();
        UpdateTimerRefreshStripesLeftRay();
        AdjustingShootingPermission();
        UpdateTimerDischargeStripesLeftRay();
        UpdateTimerDischargeStripesRightRay();
    }
    private void DisplayingChargesLeftRay()
    {
        ImageComponentLeftRayChargeStrips.sprite = NumberLeftRayCharge switch
        {
            5 => FiveChargeStrips,
            4 => FourChargeStrips,
            3 => ThreeChargeStrips,
            2 => TwoChargeStrips,
            1 => OneChargeStrips,
            _ => ZeroChargeStrips
        };
    }
    private void DisplayingChargesRightRay()
    {
        ImageComponentRightRayChargeStrips.sprite = NumberRightRayCharge switch
        {
            5 => FiveChargeStrips,
            4 => FourChargeStrips,
            3 => ThreeChargeStrips,
            2 => TwoChargeStrips,
            1 => OneChargeStrips,
            _ => ZeroChargeStrips
        };
    }
    private void AdjustingShootingPermission()
    {
        ShootingSystemLibraryScript.IsCanRightRayShoot = NumberRightRayCharge != 0;
        ShootingSystemLibraryScript.IsCanLeftRayShoot = NumberLeftRayCharge != 0;   
    }

    private void UpdateTimerDischargeStripesLeftRay()
    {
        if (ShootingSystemLibraryScript.IsShootingLeftRay)
            ChargeDischargeTimerLeftRay -= Time.deltaTime;
        
        if (ChargeDischargeTimerLeftRay < 0)
        {
            NumberLeftRayCharge--;
            ChargeDischargeTimerLeftRay = TimeOfLossOfCharge;
        }
    }
    
    private void UpdateTimerDischargeStripesRightRay()
    {
        if (ShootingSystemLibraryScript.IsShootingRightRay)
            ChargeDischargeTimerRightRay -= Time.deltaTime;
        if (ChargeDischargeTimerRightRay < 0)
        {
            NumberRightRayCharge--;
            ChargeDischargeTimerRightRay = TimeOfLossOfCharge;   
        }
    }
    
    private void UpdateTimerRefreshStripesLeftRay()
    {
        if (ChargeRefreshTimerLeftRay < 0)
        {
            NumberLeftRayCharge++;
            ChargeRefreshTimerLeftRay = TimeChargeRefresh;
        }
        if (NumberLeftRayCharge < 5 && !ShootingSystemLibraryScript.IsShootingLeftRay)
            ChargeRefreshTimerLeftRay -= Time.deltaTime;
    }
    
    private void UpdateTimerRefreshStripesRightRay()
    {
        if (ChargeRefreshTimerRightRay < 0)
        {
            NumberRightRayCharge++;
            ChargeRefreshTimerRightRay = TimeChargeRefresh;
        }
        if (NumberRightRayCharge < 5  && !ShootingSystemLibraryScript.IsShootingRightRay)
            ChargeRefreshTimerRightRay -= Time.deltaTime;
    }
}
