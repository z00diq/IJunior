using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NoiseAwaker:MonoBehaviour
{
    [SerializeField,Range(0,1)] private float _maxVolume;
    [SerializeField,Range(0, 0.5f)] private float _increaseFrequerncyDelta;
    
    [SerializeField] private Signalization _signaliztion;
    [SerializeField] private AudioClip _noise;
    [SerializeField] private float _increaseFrequencyTime;

    private AudioSource _source;
    private Coroutine _noiseRoutine;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _source.clip = _noise;
        _source.playOnAwake = false;
        _source.loop= true;
        _source.volume = 0;
        _signaliztion.ThiefCameIn += FadeIn;
        _signaliztion.ThiefCameOut += FadeOut;
    }

    private void StopNoiseCoroutine()
    {
        if (_noiseRoutine != null)
            StopCoroutine(_noiseRoutine);
    }

    private void FadeIn()
    {
        StopNoiseCoroutine();
        _noiseRoutine = StartCoroutine(nameof(PlayOrStopNoise),_maxVolume);
    }

    private void FadeOut()
    {
        StopNoiseCoroutine();
        _noiseRoutine = StartCoroutine(nameof(PlayOrStopNoise), 0);
    }

    private IEnumerator PlayOrStopNoise(float targetVolume)
    {
        var timer = new WaitForSecondsRealtime(_increaseFrequencyTime);
        
        if (_source.isPlaying == false)
            _source.Play();

        while (_source.volume != targetVolume)
        {
            _source.volume = Mathf.MoveTowards(_source.volume, targetVolume, _increaseFrequerncyDelta);
            yield return timer;
        }

        if (_source.volume == 0)
            _source.Stop();
    }
}

