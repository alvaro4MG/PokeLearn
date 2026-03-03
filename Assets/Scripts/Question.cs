using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Question
{
    public string questionText;
    public Sprite image;
    public AudioSource audio;
    public string correctAnswer;
    public List<string> wrongAnswers;
}

[System.Serializable]
public class QuestionData
{
    public string text;
    public string image;
    public List<string> answers;
    public int correctIndex;
}

[System.Serializable]
public class QuestionDataList
{
    public List<QuestionData> questions;
}