using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Instance;
    private List<Question> _questionsList = new List<Question>();
    private int id = 0;
    private int correctAnswerButton = 0;

    [Header("References")] 
    [SerializeField] private TMP_Text questionTextBox;
    [SerializeField] private TMP_Text correctAnswerTextBox;
    [SerializeField] private List<TMP_Text> wrongAnswerTextBox;
    [SerializeField] private Image resultBox;
    [SerializeField] private Image questionImage;
        
    
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
        ShowQuestions();
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

    public void ShowQuestions()
    {
        questionTextBox.text = _questionsList[0].questionText;

        correctAnswerTextBox.text = _questionsList[0].correctAnswer;


        int i = 0;
        foreach (var box in wrongAnswerTextBox)
        {
            box.text = _questionsList[0].wrongAnswers[i];
            i++;
        }

        questionImage.sprite = _questionsList[0].image;
    }

    public void checkAnswer(int id)
    {
        if (id == correctAnswerButton)
        {
            resultBox.color = Color.green;
        }
        else
        {
            resultBox.color = Color.red;
        }
    }
}
