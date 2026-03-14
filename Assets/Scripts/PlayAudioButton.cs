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
        buttonImage.sprite = _buttonPlaying;

        questionAudio.Play();

        yield return new WaitWhile(() => questionAudio.isPlaying);

        buttonImage.sprite = _buttonOff;
    }
}
