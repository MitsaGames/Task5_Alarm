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
    private Coroutine _turnOnJob;
    private Coroutine _turnOffJob;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minAudioVolume;
    }

    public void StartTurnOn()
    {
        _turnOnJob = StartCoroutine(TurnOn());
    }

    public void StartTurnOff()
    {
        StopCoroutine(_turnOnJob);

        _turnOffJob = StartCoroutine(TurnOff());
    }

    private IEnumerator TurnOn()
    {
        _audioSource.Play();

        for (float audioSourceVolume = _audioSource.volume; audioSourceVolume < _maxAudioVolume; audioSourceVolume += _volumeSpeed)
        {
            _audioSource.volume = audioSourceVolume;

            yield return null;
        }

        StopCoroutine(_turnOnJob);
    }

    private IEnumerator TurnOff()
    {
        for (float audioSourceVolume = _audioSource.volume; audioSourceVolume > _minAudioVolume; audioSourceVolume -= _volumeSpeed)
        {
            _audioSource.volume = audioSourceVolume;

            yield return null;
        }

        _audioSource.Stop();

        StopCoroutine(_turnOffJob);
    }
}
