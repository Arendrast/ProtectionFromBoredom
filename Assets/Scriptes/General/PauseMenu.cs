using JetBrains.Annotations;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _buttonManagement;
    [SerializeField] private GameObject _settings;
    
    [SerializeField] private PlayerRunner _playerScriptRunner;
    
    [SerializeField] private PlayerCosmos _playerScriptCosmos;
    
    [SerializeField] private AudioSource _backgroundSound;
    
    private bool _isPause;
    private bool _isManagementOnAndroidOn;
    private void Update() => PauseButton();

    private void Start()
    {
        if (_buttonManagement.activeInHierarchy)
            _isManagementOnAndroidOn = true;
    }

    private void PauseButton()
    {
        if (_settings != null && !_settings.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Pause();
        }
    }
    public void Pause()
    {
        _isPause = !_isPause;
        _canvas.SetActive(_isPause);
        
        if (_isManagementOnAndroidOn)
                _buttonManagement.SetActive(!_isPause);
        if (_isPause)
            SetStateBackGroundSoundAndTimeScale(0, true);
        
        else if (_playerScriptRunner != null && !_playerScriptRunner._isLose)
            SetStateBackGroundSoundAndTimeScale(1, false);
        
        else if (_playerScriptCosmos != null && !_playerScriptCosmos.IsLose)
            SetStateBackGroundSoundAndTimeScale(1, false);
        
        else Time.timeScale = 1;
    }
    private void SetStateBackGroundSoundAndTimeScale(int valueTimeScale, bool valueBackgroundSound)
    {
        Time.timeScale = valueTimeScale;
        if (_backgroundSound != null)
            _backgroundSound.mute = valueBackgroundSound;
    }
}
