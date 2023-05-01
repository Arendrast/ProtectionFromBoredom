using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSetter : MonoBehaviour
{

    [SerializeField] private Slider Slider;
    [SerializeField] private AudioMixer Mixer;

    private void Start()
    {
        Slider.value = StaticVolume.Volume;
        Mixer.SetFloat("Volume", StaticVolume.Volume * 50 - 50);
    }

    public void OnChangeVolume()
    {
        StaticVolume.Volume = Slider.value;
        Mixer.SetFloat("Volume", StaticVolume.Volume * 50 - 50);
    }
}