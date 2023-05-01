using System;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;
    [SerializeField] private GameObject ButtonManagement;
    [SerializeField] private PlayerRunner PlayerScriptRunner;
    [SerializeField] private PlayerCosmos PlayerScriptCosmos;
    [SerializeField] private GameObject Settings;
    [SerializeField] private AudioSource BackGroundSound;
    private bool IsPause;
    private bool IsManagementOnAndroidOn;
    private void Update() => PauseButton();

    private void Start()
    {
        if (ButtonManagement.activeInHierarchy)
            IsManagementOnAndroidOn = true;
    }

    private void PauseButton()
    {
        if (Settings != null && !Settings.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Pause();
        }
    }
    public void Pause()
    {
        IsPause = !IsPause;
        Canvas.SetActive(IsPause);
        if (IsManagementOnAndroidOn)
                ButtonManagement.SetActive(!IsPause);
        if (IsPause)
        {
            Time.timeScale = 0;
            BackGroundSound.mute = true;
        }
        else if (PlayerScriptRunner != null && !PlayerScriptRunner.IsLose)
        {
            Time.timeScale = 1;
            BackGroundSound.mute = false;
        }
        else if (PlayerScriptCosmos != null && !PlayerScriptCosmos.IsLose)
        {
            Time.timeScale = 1;
            BackGroundSound.mute = false;
        }
        else Time.timeScale = 1;
    }
}
