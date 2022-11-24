using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SignalingEffect : MonoBehaviour
{
    [SerializeField] private float _volumeSpeed = 0.1f;

    private AudioSource _audioSource;
    private bool _turnOn = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0.0f;
    }

    private void Update()
    {
        if(_turnOn == true && _audioSource.volume < 1.0f)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1.0f, _volumeSpeed * Time.deltaTime);
        }
        else if(_turnOn == false && _audioSource.volume > 0.0f)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0.0f, _volumeSpeed * Time.deltaTime);
        }
        else if(_audioSource.volume <= 0.0f && _audioSource.isPlaying == true)
        {
            _audioSource.Stop();
        }
    }

    public void TurnOn()
    {
        _turnOn = true;
        _audioSource.Play();
    }

    public void TurnOff()
    {
        _turnOn = false;
    }
}
