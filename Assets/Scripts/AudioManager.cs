using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("General Parameters")]
    [SerializeField] private int _volumeMusic = 5;
    [SerializeField] private int _volumeFX = 5;
    [SerializeField] private bool _muted;
    [SerializeField] private AudioMixer _mixer;
    
    [Header("Background Music")]
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _cynthiaMusic;
    [SerializeField] private AudioSource _winMusic;
    [SerializeField] private AudioSource _loseMusic;
    
    [Header("SFX Music")]
    [SerializeField] private AudioSource _acceptUI;
    [SerializeField] private AudioSource _navigateUI;
    [SerializeField] private AudioSource _hitEnemy;
    [SerializeField] private AudioSource _hitAlly;

    private AudioSource _currentMusic;
    
    //private const string MUSIC_VOLUME_KEY = "MusicVolume";
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        //_volumeMusic = 5;        //Posiblemente usar PlayerPrefs
        //_volumeMusic = PlayerPrefs.GetInt(MUSIC_VOLUME_KEY, 5);
        //_volumeFX = 5;
        MenuManager.Instance.SetVolumesTextBox(5);
    }


    // Start is called before the first frame update
    void Start()
    {
        VolumeMusic(0);
        VolumeFX(0);
        _backgroundMusic.Play();
        //_mixer.SetFloat("MusicVolume", CalculateVolume(_volumeMusic));
        //_mixer.SetFloat("FXVolume", CalculateVolume(_volumeFX));
        //MenuManager.Instance.VolumeMusic(0);
        //MenuManager.Instance.VolumeFX(0);
    }
    
    public void ToggleMute()
    {
        _muted = !_muted;
    }

    public int GetVolumeMusic()
    {
        return _volumeMusic;
    }

    public int GetVolumeFX()
    {
        return _volumeFX;
    }

    public void PlayAcceptUI()
    {
        //_acceptUI.Play();
        _acceptUI.PlayOneShot(_acceptUI.clip);
    }

    public void PlayNavigateUI()
    {
        //_navigateUI.Play();
        _navigateUI.PlayOneShot(_navigateUI.clip);
    }

    public void PlayHitEnemy()
    {
        _hitEnemy.PlayOneShot(_hitEnemy.clip);
    }
    
    public void PlayHitAlly()
    {
        _hitAlly.PlayOneShot(_hitAlly.clip);
    }
    
    
    public void PlayMusic(AudioSource newMusic)
    {
        if (_currentMusic == newMusic) return;

        if (_currentMusic != null)
            _currentMusic.Stop();

        _currentMusic = newMusic;
        _currentMusic.Play();
    }
    

    public void PlayBackgroundMusic()
    {
        PlayMusic(_backgroundMusic);
    }
    
    
    public void PlayCynthiaMusic()
    {
        //_cynthiaMusic.Play();
        PlayMusic(_cynthiaMusic);
    }
    
    public void PlayWinMusic()
    {
        //_winMusic.Play();
        PlayMusic(_winMusic);
    }
    
    public void PlayLoseMusic()
    {
        //_loseMusic.Play();
        PlayMusic(_loseMusic);
    }
    

    public int VolumeMusic(int value)
    {
        _volumeMusic += value;
        _mixer.SetFloat("MusicVolume", CalculateVolume(_volumeMusic));
        return _volumeMusic;
    }
    
    public int VolumeFX(int value)
    {
        _volumeFX += value;
        _mixer.SetFloat("FXVolume", CalculateVolume(_volumeFX));
        return _volumeFX;
    }
    
    
    public void StopBackgroundMusic()
    {
        _backgroundMusic.Stop();
    }

    private float CalculateVolume(int value)
    {
        float v = Mathf.Clamp(value / 10f, 0.0001f, 1f);
        return Mathf.Log10(v) * 20;
    }
    
    /*
    public void StopCynthiaMusic()
    {
        _cynthiaMusic.Stop();
    }
    public void StopWinMusic(){
        _winMusic.Stop();
    }
    public void StopLoseMusic()
    {
        _loseMusic.Stop();
    }*/

}
