using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("States")]
    [SerializeField] private int _volume;
    [SerializeField] private bool _muted;
    
    [Header("Background Music")]
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _cynthiaMusic;
    [SerializeField] private AudioSource _winMusic;
    [SerializeField] private AudioSource _loseMusic;
    [SerializeField] private List<AudioSource> _tracks;
    
    [Header("SFX Music")]
    [SerializeField] private AudioSource _acceptUI;
    [SerializeField] private AudioSource _navigateUI;

    private AudioSource _currentMusic;
    
    
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }


    // Start is called before the first frame update
    void Start()
    {
        _backgroundMusic.Play();
        _tracks = new List<AudioSource>();
        _tracks.Add(_backgroundMusic);
        _tracks.Add(_cynthiaMusic);
        _tracks.Add(_winMusic);
        _tracks.Add(_loseMusic);
    }
    
    public void ToggleMute()
    {
        _muted = !_muted;
    }

    public void PlayAcceptUI()
    {
        _acceptUI.Play();
    }

    public void PlayNavigateUI()
    {
        _navigateUI.Play();
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
        /*if (_currentMusic == _backgroundMusic)
        {
            return;
        }

        if (_currentMusic != null)
        {
            _currentMusic.Stop();
        }
        _backgroundMusic.Play();
        _currentMusic = _backgroundMusic;*/
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
    

    public void VolumeMusic(int value)
    {
        _volume += value/10;
    }
    
    public void VolumeFX(int value)
    {
        _volume += value;
    }
    
    public void StopBackgroundMusic()
    {
        _backgroundMusic.Stop();
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
