using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _click;

    private bool _isSoundOff;

    [UsedImplicitly] // назначен на все кнопки
    public void PlaySound()
    {
        if (!_isSoundOff)
        {
            _audioSource.PlayOneShot(_click);
        }
    }

    [UsedImplicitly] // назначен на кнопку выключения звука
    public void SoundOnOff()
    {
        _isSoundOff = !_isSoundOff;

        if (_isSoundOff)
        {
            _audioSource.Pause();
        }
        else
        {
            _audioSource.UnPause();
        }
    }
}