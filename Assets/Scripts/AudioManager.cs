using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("States")]
    [SerializeField] private int _volume;
    [SerializeField] private bool _muted;
    
    [Header("Music/AudioSource")]
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _acceptUI;
    [SerializeField] private AudioSource _navigateUI;
    [SerializeField] private AudioSource _cynthiaMusic;
    
    
    
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

}
