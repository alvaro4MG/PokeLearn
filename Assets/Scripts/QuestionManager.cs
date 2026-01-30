using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Instance;
    private List<Question> _questionsList = new List<Question>();
    private int id = 0;
    private int correctAnswerButton = 0;

    [Header("Question Info")] 
    [SerializeField] private TMP_Text questionTextBox;
    [SerializeField] private Image questionImage;
    [SerializeField] private TMP_Text fullQuestionTextBox;
    [SerializeField] private Image resultBox;
    
    [Header("Answer TextBox")]
    [SerializeField] private GameObject group4Answer;
    [SerializeField] private List<TMP_Text> answerTextBox4;
    [SerializeField] private GameObject group2Answer;
    [SerializeField] private List<TMP_Text> answerTextBox2;
        
    
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Read .txt or json
        _questionsList = LoadQuestions();
        ShowQuestion();
    }

    private List<Question> LoadQuestions()
    {
        //List<Question> list = new List<Question>();

        //QuestionConverter
        
        QuestionConverter.LoadQuestions();
        
        // Check grammar on file on QuestionConverter then read here
        

        //return list;
        return QuestionConverter.questions;
    }

    public void ShowQuestion()
    {
        
        // Text and/or image of the questions
        if (_questionsList[id].image != null)
        {
            fullQuestionTextBox.gameObject.SetActive(false);
            questionTextBox.gameObject.SetActive(true);
            questionImage.gameObject.SetActive(true);
            questionTextBox.text = _questionsList[id].questionText;
            questionImage.sprite = _questionsList[id].image;
        }
        else
        {
            fullQuestionTextBox.gameObject.SetActive(true);
            questionTextBox.gameObject.SetActive(false);
            questionImage.gameObject.SetActive(false);
            fullQuestionTextBox.text = _questionsList[id].questionText;
            questionImage.sprite = null;
        }
        
        // Result box for debugging
        resultBox.color = Color.gray;

        // Correct and incorrect answers (see option for 2 and 4 answers)
        if (_questionsList[id].wrongAnswers.Count == 1)
        {
            group2Answer.SetActive(true);
            group4Answer.SetActive(false);
            ShowAnswers(answerTextBox2);
        }
        else
        {
            group4Answer.SetActive(true);
            group2Answer.SetActive(false);
            ShowAnswers(answerTextBox4);
        }
        

        
        // Audio
    }

    public void ShowAnswers(List<TMP_Text> answers)
    {
        List<int> numbers = new List<int>();
        for (int i = 0; i <= _questionsList[id].wrongAnswers.Count; i++) {  // for loop until <= for additional correct one
            numbers.Add(i);
        }

        int index = UnityEngine.Random.Range(0, numbers.Count);
        answers[numbers[index]].text = _questionsList[id].correctAnswer;
        correctAnswerButton = numbers[index];
        numbers.RemoveAt(index);
        
        foreach (var answer in _questionsList[id].wrongAnswers)
        {
            index = UnityEngine.Random.Range(0, numbers.Count);
            answers[numbers[index]].text = answer;
            numbers.RemoveAt(index);
        }
    }

    public void checkAnswer(int answer)
    {
        if (answer == correctAnswerButton)
        {
            resultBox.color = Color.green;
            CombatManager.Instance.DamageEnemy(1);
            id++;
            if (id < _questionsList.Count)
            {
                ShowQuestion();
            }
            else
            {
                id = 0;
                GameSettings.Instance.SetWin(true);
                SceneManager.LoadScene("EndScene");
                //AudioManager.Instance.StopCynthiaMusic();
            }
        }
        else
        {
            resultBox.color = Color.red;
            if (CombatManager.Instance.DamageAlly(1))
            {
                GameSettings.Instance.SetWin(false);
                SceneManager.LoadScene("EndScene");
                //AudioManager.Instance.StopCynthiaMusic();
            }
        }
    }

}
