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
        _signaliztion.ThiefCameIn += PlayNoise;
        _signaliztion.ThiefCameOut += StopNoise;
    }

    private void StopNoise()
    {
        StopNoiseCoroutine();
        _noiseRoutine = StartCoroutine(nameof(DecreaseNoiseVolume));
    }

    private void PlayNoise()
    {
        StopNoiseCoroutine();
        _noiseRoutine = StartCoroutine(nameof(IncreaseNoiseVolume));
    }

    private void StopNoiseCoroutine()
    {
        if (_noiseRoutine != null)
            StopCoroutine(_noiseRoutine);
    }

    private IEnumerator IncreaseNoiseVolume()
    {
        if(_source.isPlaying==false)
            _source.Play();

        var timer = new WaitForSecondsRealtime(_increaseFrequencyTime);

        while (_source.volume!=_maxVolume)
        {
            _source.volume = Mathf.MoveTowards(_source.volume, _maxVolume, _increaseFrequerncyDelta);
            yield return timer;
        }
    }

    private IEnumerator DecreaseNoiseVolume()
    {
        var timer = new WaitForSecondsRealtime(_increaseFrequencyTime);

        while (_source.volume != 0)
        {
            _source.volume = Mathf.MoveTowards(_source.volume, 0, _increaseFrequerncyDelta);
            yield return timer;
        }

        _source.Stop();
    }
}

