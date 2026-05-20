using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayAudioButton : MonoBehaviour
{

    [Header("Sprites")]
    [SerializeField] private Sprite _buttonOff;
    [SerializeField] private Sprite _buttonPlaying;

    [SerializeField] private AudioSource questionAudio;
    [SerializeField] private Image buttonImage;

    private void OnEnable()
    {
        buttonImage.sprite = _buttonOff;
    }

    public void SetAudio(AudioClip audioClip)
    {
        questionAudio.clip = audioClip;
    }

    public void PlayAudio()
    {
        StartCoroutine(PlayAudioRoutine());
    }

    private IEnumerator PlayAudioRoutine()
    {
        int volume = AudioManager.Instance.GetVolumeMusic();
        
        AudioManager.Instance.SetVolumeMusic(Math.Max((volume - AudioManager.Instance.VolumeDecrease), 0));
        buttonImage.sprite = _buttonPlaying;

        questionAudio.Play();

        yield return new WaitWhile(() => questionAudio.isPlaying);

        AudioManager.Instance.SetVolumeMusic(volume);
        buttonImage.sprite = _buttonOff;
    }
}
