using System.Collections.Generic;
using UnityEngine;

public static class QuestionConverter
{
    [Header("Questions file")]
    [SerializeField] public static string questionsFileName = "Questions/unit_1";

    [Header("Result")]
    public static List<TextAsset> units = new List<TextAsset>(Resources.LoadAll<TextAsset>("Questions"));
    public static List<Question> questions = new List<Question>();
    
    public static int unitId = 0;
    


    public static void LoadQuestions()
    {
        //TextAsset textAsset = Resources.Load<TextAsset>(questionsFileName);
        TextAsset textAsset = Resources.Load<TextAsset>("Questions/" + units[unitId].name);

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

            if (line.StartsWith("#"))       // Question text
            {
                currentQuestion = new Question();
                currentQuestion.questionText = line.Substring(1).Trim();
                currentQuestion.wrongAnswers = new List<string>();
                questions.Add(currentQuestion);
            }
            else if (line.StartsWith("%") && currentQuestion != null)       // Image
            {
                string imageName = line.Substring(1).Trim();
                Sprite img = Resources.Load<Sprite>("Images/" + imageName.Replace(".png", ""));
                currentQuestion.image = img;
            }
            else if (line.StartsWith("&") && currentQuestion != null)       // Audio
            {
                string audioName = line.Substring(1).Trim();
                AudioClip aud = Resources.Load<AudioClip>("Audios/" + audioName.Replace(".mp3", ""));   // Todo: careful with format
                currentQuestion.audio = aud;
                //Debug.Log("Audio: " + aud.name);
            }
            else if (line.StartsWith("@") && currentQuestion != null)   // Correct answer
            {
                currentQuestion.correctAnswer = line.Substring(1).Trim();
            }
            else if (line.StartsWith("-") && currentQuestion != null)   // Wrong answers
            {
                currentQuestion.wrongAnswers.Add(line.Substring(1).Trim());
            }
        }

        //Debug.Log($"Preguntas cargadas: {questions.Count}");
        
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

    public static string GetUnitTitle(int i)
    {
        unitId += i;
        if (unitId >= units.Count)
        {
            unitId = 0;
        }else if (unitId < 0)
        {
            unitId = units.Count - 1;
        }
        return units[unitId].name;
    }

    public static int GetUnitsNumber()
    {
        return units.Count;
    }
}
