using System;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorNumberBlasters : MonoBehaviour
{ 
    [Header("Strips")]
    [SerializeReference] private Image ImageComponentLeftBlasterChargeStrips;
    [SerializeReference] private Image ImageComponentRightBlasterChargeStrips;
    [SerializeField] private Sprite FiveChargeStrips;
    [SerializeField] private Sprite FourChargeStrips;
    [SerializeField] private Sprite ThreeChargeStrips;
    [SerializeField] private Sprite TwoChargeStrips;
    [SerializeField] private Sprite OneChargeStrips;
    [SerializeField] private Sprite ZeroChargeStrips;
    private int NumberLeftBlasterCharge = 5;
    private int NumberRightBlasterCharge = 5;
    private const float TimeChargeRefresh = 2.5f;
    private float ChargeRefreshTimerLeftBlaster = 2.5f;
    private float ChargeRefreshTimerRightBlaster = 2.5f;
    
    private ShootingSystemLibrary ShootingSystemLibraryScript;

    private void Start() => ShootingSystemLibraryScript = GetComponent<ShootingSystemLibrary>();
    

    private void Update()
    {
        AdjustingShootingPermission();
        CheckingShootingBlaster();
        DisplayingChargesLeftBlaster();
        DisplayingChargesRightBlaster();
        UpdateTimerRightBlaster();
        UpdateTimerLeftBlaster();
    }
    private void CheckingShootingBlaster()
    {
        if (ShootingSystemLibraryScript.IsShootingLeftBlaster)
            NumberLeftBlasterCharge--;

        if (ShootingSystemLibraryScript.IsShootingRightBlaster)
            NumberRightBlasterCharge--;
    }
    private void DisplayingChargesLeftBlaster()
    {
        ImageComponentLeftBlasterChargeStrips.sprite = NumberLeftBlasterCharge switch
        {
            5 => FiveChargeStrips,
            4 => FourChargeStrips,
            3 => ThreeChargeStrips,
            2 => TwoChargeStrips,
            1 => OneChargeStrips,
            _ => ZeroChargeStrips
        };
    }
    private void DisplayingChargesRightBlaster()
    {
        ImageComponentRightBlasterChargeStrips.sprite = NumberRightBlasterCharge switch
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
        ShootingSystemLibraryScript.IsCanRightBlasterShoot = NumberRightBlasterCharge > 0;
        ShootingSystemLibraryScript.IsCanLeftBlasterShoot = NumberLeftBlasterCharge > 0;
    }
    private void UpdateTimerLeftBlaster()
    {
            if (ChargeRefreshTimerLeftBlaster < 0)
            {
                NumberLeftBlasterCharge++;
                ChargeRefreshTimerLeftBlaster = TimeChargeRefresh;
            }
            if (NumberLeftBlasterCharge < 5)
             ChargeRefreshTimerLeftBlaster -= Time.deltaTime;
    }
    private void UpdateTimerRightBlaster()
    {
            if (ChargeRefreshTimerRightBlaster < 0)
            {
                NumberRightBlasterCharge++;
                ChargeRefreshTimerRightBlaster = TimeChargeRefresh;
            }
            if (NumberRightBlasterCharge < 5)
                ChargeRefreshTimerRightBlaster -= Time.deltaTime;
    }
}
