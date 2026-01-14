using System.Collections.Generic;
using UnityEngine;

public static class QuestionConverter
{
    [Header("Questions file")]
    [SerializeField] public static string questionsFileName = "Questions/unit_1";

    [Header("Result")]
    public static List<Question> questions = new List<Question>();
    


    public static void LoadQuestions()
    {
        TextAsset textAsset = Resources.Load<TextAsset>(questionsFileName);

        if (textAsset == null)
        {
            Debug.LogError("Could not find questions file");
            return;
        }

        string[] lines = textAsset.text.Split('\n');

        Question currentQuestion = null;

        foreach (string rawLine in lines)
        {
            string line = rawLine.Trim();

            if (string.IsNullOrEmpty(line))
                continue;

            if (line.StartsWith("#"))
            {
                currentQuestion = new Question();
                currentQuestion.questionText = line.Substring(1).Trim();
                currentQuestion.wrongAnswers = new List<string>();
                questions.Add(currentQuestion);
            }
            else if (line.StartsWith("%") && currentQuestion != null)
            {
                string imageName = line.Substring(1).Trim();
                Sprite img = Resources.Load<Sprite>("Images/" + imageName.Replace(".png", ""));
                currentQuestion.image = img;
            }
            else if (line.StartsWith("@") && currentQuestion != null)
            {
                currentQuestion.correctAnswer = line.Substring(1).Trim();
            }
            else if (line.StartsWith("-") && currentQuestion != null)
            {
                currentQuestion.wrongAnswers.Add(line.Substring(1).Trim());
            }
        }

        Debug.Log($"Preguntas cargadas: {questions.Count}");
        
    }

    public static List<Question> GetQuestions()
    {
        return questions;
    }

    public static void checkErrors()
    {
        //will check possible errors in questions
    }
    
    public static void ClearQuestions()
    {
        questions.Clear();
    }
}
