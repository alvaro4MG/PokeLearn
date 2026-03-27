using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class EndManager : MonoBehaviour
{
    public static EndManager Instance;
    //private Animator _animator;
    
    [SerializeField] private TMP_Text _winTextBox;
    [SerializeField] private TMP_Text _generalStatsTextBox;
    [SerializeField] private TMP_Text _listeningStatsTextBox;
    [SerializeField] private TMP_Text _TFStatsTextBox;
    [SerializeField] private TMP_Text _MultipleChoiceStatsTextBox;

    
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
        //AudioManager.Instance.StopBackgroundMusic();

        if (GameSettings.Instance.GetWin())
        {
            AudioManager.Instance.PlayWinMusic();
            _winTextBox.text = "You Win!!!";
        }
        else
        {
            _winTextBox.text = "You Loose :( ";     // Emojis como 😔 no funcionan
            AudioManager.Instance.PlayLoseMusic();
        }
        
        ShowStats();
    }
    

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Juego cerrado"); // visible en el editor
    }

    public void BackToMenu()
    {
        QuestionConverter.ClearQuestions();
        if (GameSettings.Instance.GetWin())
        {
            //AudioManager.Instance.StopWinMusic();
        }
        else
        {
            //AudioManager.Instance.StopLoseMusic();
        }

        SceneManager.LoadScene("StartMenu");
    }

    private void ShowStats()
    {
        _generalStatsTextBox.text = "Correct answers: " + GameStatistics.Instance.GeneralStats + "/" + GameStatistics.Instance.GeneralStatsTotal;
        _listeningStatsTextBox.text = "Listening correct answers: " + GameStatistics.Instance.ListeningStats + "/" + GameStatistics.Instance.ListeningStatsTotal;
        _TFStatsTextBox.text = "T/F correct answers: " + GameStatistics.Instance.TrueFalseStats + "/" + GameStatistics.Instance.TrueFalseStatsTotal;
        _MultipleChoiceStatsTextBox.text = "Multiple choice correct answers: " + GameStatistics.Instance.MultipleChoiceStats + "/" + GameStatistics.Instance.MultipleChoiceStatsTotal;
    }
    
    

}
