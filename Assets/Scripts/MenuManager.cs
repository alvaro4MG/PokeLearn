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
    

}
