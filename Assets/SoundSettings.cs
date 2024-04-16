using UnityEngine;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    private const string s_MasterVolume = "MasterVolume";
    private const string s_ButtonsVolume = "ButtonsVolume";
    private const string s_BackgroundVolume = "BackgroundVolume";
    private const int s_volumeModifier = 20;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioSource[] _audioSources;

    private bool isMuted=false;

    public void Mute()
    {
        isMuted = !isMuted;

        foreach (AudioSource item in _audioSources)
            item.mute= isMuted;
    }

    public void SetMasterVolume(float value)
    {
        float volume = ValueToVolume(value);
        _audioMixer.SetFloat(s_MasterVolume, volume);
    }

    public void SetButtonsVolume(float value)
    {
        float volume = ValueToVolume(value);
        _audioMixer.SetFloat(s_ButtonsVolume, volume);
    }

    public void SetBackgroundVolume(float value)
    {
        float volume = ValueToVolume(value);
        _audioMixer.SetFloat(s_BackgroundVolume, volume);
    }

    private static float ValueToVolume(float value)
    {
        return Mathf.Log(value) * s_volumeModifier;
    }
}
