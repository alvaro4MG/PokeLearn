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

    [Header("References")] 
    [SerializeField] private TMP_Text questionTextBox;
    [SerializeField] private TMP_Text correctAnswerTextBox;
    [SerializeField] private List<TMP_Text> wrongAnswerTextBox;
    [SerializeField] private List<TMP_Text> answerTextBox;
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
        Debug.Log("Show question " + id);
        
        // Text of the question 
        questionTextBox.text = _questionsList[id].questionText;
        resultBox.color = Color.gray;

        // Correct and incorrect answers (see option for 2 and 4 answers)
        List<int> numbers = new List<int>();
        for (int i = 0; i <= _questionsList[id].wrongAnswers.Count; i++) {  // for until <= for additional correct one
            numbers.Add(i);
        }

        int index = UnityEngine.Random.Range(0, numbers.Count);
        answerTextBox[numbers[index]].text = _questionsList[id].correctAnswer;
        correctAnswerButton = numbers[index];
        numbers.RemoveAt(index);
        
        foreach (var answer in _questionsList[id].wrongAnswers)
        {
            index = UnityEngine.Random.Range(0, numbers.Count);
            answerTextBox[numbers[index]].text = answer;
            numbers.RemoveAt(index);
        }
        

        // Image
        if (_questionsList[id].image != null)
        {
            questionImage.sprite = _questionsList[id].image;
        }
        else
        {
            questionImage.sprite = null;
        }
        
        // Audio
    }

    public void checkAnswer(int answer)
    {
        if (answer == correctAnswerButton)
        {
            resultBox.color = Color.green;
            id++;
            if (id < _questionsList.Count)
            {
                ShowQuestion();
            }
            else
            {
                id = 0;
                SceneManager.LoadScene("EndScene");
            }
        }
        else
        {
            resultBox.color = Color.red;
        }
    }

}
