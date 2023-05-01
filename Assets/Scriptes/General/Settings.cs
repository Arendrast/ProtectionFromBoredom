using System;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject SettingsMenu;
    private bool IsOpenSettings;
    public void SwitchingSettings()
    {
        IsOpenSettings = !IsOpenSettings;
        SettingsMenu.SetActive(IsOpenSettings);
    }
}
