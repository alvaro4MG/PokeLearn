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
    
    [Header("SFX Music")]
    [SerializeField] private AudioSource _acceptUI;
    [SerializeField] private AudioSource _navigateUI;
    
    
    
    private void Awake()
    {
        /*if(Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
        */
        
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
    

    public void PlayBackgroundMusic()
    {
        if (!_backgroundMusic.isPlaying)
        {
            _backgroundMusic.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        _backgroundMusic.Stop();
    }
    
    
    public void PlayCynthiaMusic()
    {
        _cynthiaMusic.Play();
    }
    
    public void StopCynthiaMusic()
    {
        _cynthiaMusic.Stop();
    }
    
    
    public void PlayWinMusic()
    {
        _winMusic.Play();
    }
    
    public void StopWinMusic(){
        _winMusic.Stop();
    }

    
    
    public void PlayLoseMusic()
    {
        _loseMusic.Play();
    }

    public void StopLoseMusic()
    {
        _loseMusic.Stop();
    }

}
