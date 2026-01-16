using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    private Animator _animator;

    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _sFXClip;

    [SerializeField] private TMP_Text _unitDisplay;


    //private InputActions _controls;
    
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
        //_backgroundMusic.Play();
        if (_unitDisplay != null)
        {
            _unitDisplay.text = QuestionConverter.GetUnitTitle(0);
        }
    }

    private void OnEnable() {
        /*_controls.UI.Enable();

        _controls.UI.AcceptUI.performed += OnAcceptUIPerformed;
        _controls.UI.CancelUI.performed += OnCancelUIPerformed;*/
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){

            StartCoroutine(PlayGame());
            //_animator.Play("fundido");

        }else if (Input.GetKeyDown(KeyCode.Q)){
            QuitGame();
        }
    }*/

    /*private void OnAcceptUIPerformed(InputAction.CallbackContext ctx) {
        StartCoroutine(PlayGame());
        //_controls.UI.Disable();
    }

    private void OnCancelUIPerformed(InputAction.CallbackContext ctx) {
        QuitGame();
    }*/



    public void PlayGame()
    {
        //_animator.Play("fundido");
        //_sFXClip.Play();
        GameSettings.Instance.SetUnit(QuestionConverter.unitId);
        SceneManager.LoadScene("CombatScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Juego cerrado"); // visible en el editor
    }

    public void BackToMenu()
    {
        QuestionConverter.ClearQuestions();
        SceneManager.LoadScene("StartMenu");
    }
    
    
    public void NextUnit(int i)
    {
        _unitDisplay.text = QuestionConverter.GetUnitTitle(i);
    }
    

}
