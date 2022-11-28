using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SignalingEffect : MonoBehaviour
{
    [SerializeField] private float _volumeSpeed = 0.001f;

    private AudioSource _audioSource;
    private float _minAudioVolume = 0.0f;
    private float _maxAudioVolume = 1.0f;
    private Coroutine _regulateSignalJob;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minAudioVolume;
    }

    public void TurnOn()
    {
        if (_regulateSignalJob != null)
        {
            StopCoroutine(_regulateSignalJob);
        }

        _audioSource.Play();

        _regulateSignalJob = StartCoroutine(RegulateSignal(_maxAudioVolume));
    }

    public void TurnOff()
    {
        if (_regulateSignalJob != null)
        {
            StopCoroutine(_regulateSignalJob);
        }

        _regulateSignalJob = StartCoroutine(RegulateSignal(_minAudioVolume));
    }

    private IEnumerator RegulateSignal(float targetVolume)
    {
        int changeSign = (targetVolume > _audioSource.volume) ? 1 : -1;

        while ((changeSign == 1 && _audioSource.volume < targetVolume) || (changeSign == -1 && _audioSource.volume > targetVolume))
        {
            _audioSource.volume += changeSign * _volumeSpeed;
            yield return null;
        }

        if(_audioSource.volume == 0.0f)
        {
            _audioSource.Stop();
        }
    }
}
