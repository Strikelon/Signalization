using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmController : MonoBehaviour
{
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _speedVolumeChange;

    private bool _isActivated = false;
    private AudioSource _audioSource;
    private float _currentVolume = 0;
    private float _minVolume = 0;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isActivated)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _maxVolume, _speedVolumeChange * Time.deltaTime);
            _audioSource.volume = _currentVolume;
        }
        else
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _minVolume, _speedVolumeChange * Time.deltaTime);
            _audioSource.volume = _currentVolume;
        }
    }

    public void Activate()
    {
        _isActivated = true;
    }

    public void Deactivate()
    {
        _isActivated = false;
    }
}
