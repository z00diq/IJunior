using UnityEngine;

public class ButtonConfigurtor : MonoBehaviour
{
    [SerializeField] private AudioClip _audio;
    [SerializeField] private AudioSource _audioSource;

    public void PlaySound()
    {
        _audioSource.clip = _audio;
        _audioSource.Play();
    }
}
