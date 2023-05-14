using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSetter : MonoBehaviour
{

    [SerializeField] private Slider _slider;
    
    [SerializeField] private AudioMixer _mixer;

    private float _volume = 1;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Volume"))
            PlayerPrefs.SetFloat("Volume", _volume);
    }

    private void Start()
    {
        _slider.value = PlayerPrefs.GetFloat("Volume");
        _mixer.SetFloat("Volume", _volume * 50 - 50);
    }

    public void OnChangeVolume()
    {
        _volume = _slider.value;
        PlayerPrefs.SetFloat("Volume", _volume);
        _mixer.SetFloat("Volume", _volume * 50 - 50);
    }
}