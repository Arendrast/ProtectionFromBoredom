using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject _settingsMenu;
    
    private bool _isOpenSettings;
    public void SwitchingSettings()
    {
        _isOpenSettings = !_isOpenSettings;
        _settingsMenu.SetActive(_isOpenSettings);
    }
}
