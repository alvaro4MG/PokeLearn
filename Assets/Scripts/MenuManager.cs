using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    //private Animator _animator;

    [SerializeField] private TMP_Text _unitDisplay;
    [SerializeField] private TMP_Text _volumeMusicDisplay;
    [SerializeField] private TMP_Text _volumeFXDisplay;
    
    
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    /*private void Awake(){
        //_animator = GetComponent<Animator>();
        //_backgroundMusic = GetComponent<AudioSource>();
        //_controls = new InputActions();
        
        
    }*/

    // Start is called before the first frame update
    void Start()
    {
        //_animator.Play("toggle");
        GameSettings.Instance.SetWin(false);
        _unitDisplay.text = QuestionConverter.GetUnitTitle(0);
        //_volumeMusicDisplay.text = AudioManager.Instance.GetVolumeMusic().ToString();
        //_volumeFXDisplay.text = AudioManager.Instance.GetVolumeFX().ToString();
        AudioManager.Instance.PlayBackgroundMusic();
    }
    

    public void PlayGame()
    {
        //_animator.Play("fundido");
        GameSettings.Instance.SetUnit(QuestionConverter.unitId);
        SceneManager.LoadScene("InstructionScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Juego cerrado"); // visible en el editor
    }

    
    
    public void NextUnit(int i)
    {
        AudioManager.Instance.PlayNavigateUI();
        _unitDisplay.text = QuestionConverter.GetUnitTitle(i);
    }

    public void VolumeMusic(int i)
    {
        if((AudioManager.Instance.GetVolumeMusic() >= 10 && i > 0) || (AudioManager.Instance.GetVolumeMusic() <= 0 && i < 0) )
        {
            return;
        }
        AudioManager.Instance.PlayNavigateUI();
        _volumeMusicDisplay.text = AudioManager.Instance.VolumeMusic(i).ToString();
    }
    
    public void VolumeFX(int i)
    {
        if((AudioManager.Instance.GetVolumeFX() >= 10 && i > 0) || (AudioManager.Instance.GetVolumeFX() <= 0 && i < 0) )
        {
            return;
        }
        AudioManager.Instance.PlayNavigateUI();
        _volumeFXDisplay.text = AudioManager.Instance.VolumeFX(i).ToString();
    }

    public void SetVolumesTextBox(int value)
    {
        _volumeMusicDisplay.text = value.ToString();
        _volumeFXDisplay.text = value.ToString();
    }

}
