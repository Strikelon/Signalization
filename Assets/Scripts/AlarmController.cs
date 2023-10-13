using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AlarmController : MonoBehaviour
{
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _speedVolumeChange;

    private AudioSource _audioSource;
    private float _currentVolume = 0;
    private float _minVolume = 0;
    private Coroutine _changeVolumeJob;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _currentVolume;
    }

    public void Activate()
    {
        if (_changeVolumeJob != null)
        {
            StopCoroutine(_changeVolumeJob);
        }

        _changeVolumeJob = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void Deactivate()
    {
        if (_changeVolumeJob != null)
        {
            StopCoroutine(_changeVolumeJob);
        }

        _changeVolumeJob = StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_currentVolume != targetVolume)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume,
                targetVolume, _speedVolumeChange * Time.deltaTime);
            _audioSource.volume = _currentVolume;

            yield return null;
        }
    }
}
