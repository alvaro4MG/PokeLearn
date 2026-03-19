using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public static class QuestionConverter
{
    [Header("Questions file")]
    [SerializeField] public static string questionsFileName = "Questions/unit_1";
    
    public static int unitId = 0;

    [Header("Result")] 
    public static List<MyTextAsset> units = GetUnits();
    public static List<Question> questions = new List<Question>();
    

    public static List<MyTextAsset> GetUnits()
    {
        List<MyTextAsset> newList = new List<MyTextAsset>();
        
    #if UNITY_WEBGL
        units = new List<MyTextAsset>();
        var unitResources = Resources.LoadAll<TextAsset>("Questions");
        foreach (var unit in unitResources){
            newList.Add(new MyTextAsset(unit));
        }
    #else
        string folder = Path.Combine(Application.streamingAssetsPath, "Questions");

        string[] files = Directory.GetFiles(folder, "*.txt");

        foreach (var file in files)
        {
            string content = File.ReadAllText(file);
            string fileName = Path.GetFileNameWithoutExtension(file);
            MyTextAsset newUnit = new MyTextAsset(fileName, content);
            //units.Add(content);
            newList.Add(newUnit);
        }
    #endif
        return newList;
        
    }

    public static string GetQuestionFileText()
    {
    #if UNITY_WEBGL
        // Leer desde Resources (WebGL / HTML)
        TextAsset textAsset = Resources.Load<TextAsset>("Questions/" + units[unitId].name);

        if (textAsset == null)
        {
            Debug.LogError("Could not find questions file");
            return null;
        }

        return textAsset.text;

    #else
        // Leer desde StreamingAssets (Windows build)
        string path = Path.Combine(Application.streamingAssetsPath, "Questions/" + units[unitId].name + ".txt");

        if (!File.Exists(path))
        {
            Debug.LogError("Could not find questions file: " + path);
            return null;
        }

        return File.ReadAllText(path);
    #endif
        
    }

    public static void LoadQuestions()
    {
        //string text = GetQuestionFileText();
        
        string[] lines = GetQuestionFileText().Split('\n');

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
                /*string imageName = line.Substring(1).Trim();
                Sprite img = Resources.Load<Sprite>("Images/" + imageName.Replace(".png", ""));
                currentQuestion.image = img;*/
                string imageName = line.Substring(1).Trim();
                currentQuestion.image = LoadImage(imageName);
            }
            else if (line.StartsWith("&") && currentQuestion != null)
            {
                string audioName = line.Substring(1).Trim();
                Question q = currentQuestion;

                //("Attempting to load audio: " + audioName);

                LoadAudio(audioName, clip =>
                {
                    if (clip == null)
                    {
                        //Debug.LogError("Audio load FAILED: " + audioName);
                    }
                    else
                    {
                        //Debug.Log("Audio loaded successfully: " + audioName);
                        q.audio = clip;
                    }
                });
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

    private static Sprite LoadImage(string imageName)
    {
    #if UNITY_WEBGL
        //Sprite img = Resources.Load<Sprite>("Images/" + imageName.Replace(".png", ""));
        string path = "Images/" + units[unitId].name + "/" + imageName.Replace(".png", "");
        Debug.Log("Loading sprite from: " + path);
        
        //Sprite img = Resources.Load<Sprite>("Images/" + units[unitId].name + "/" + imageName.Replace(".png", ""));
        Sprite img = Resources.Load<Sprite>(path);
        return img;
    #else
        string path = Path.Combine(Application.streamingAssetsPath, "Images/" + imageName);

        if (!File.Exists(path))
        {
            Debug.LogError("Image not found: " + path);
            return null;
        }

        byte[] fileData = File.ReadAllBytes(path);

        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(fileData);

        Sprite img = Sprite.Create(
            tex,
            new Rect(0, 0, tex.width, tex.height),
            new Vector2(0.5f, 0.5f)
        );
        
        return img;
    #endif
    }
    
    public static void LoadAudio(string audioName, System.Action<AudioClip> onLoaded)
    {
    #if UNITY_WEBGL
        AudioClip clip = Resources.Load<AudioClip>("Audios/" + audioName.Replace(".mp3", ""));
        onLoaded?.Invoke(clip);
    #else
        QuestionManager.Instance.ConvertAudioClip(audioName, onLoaded);
    #endif
    }
    
}


public class MyTextAsset
{
    public string name;
    public string text;

    public MyTextAsset(string name, string text)
    {
        this.name = name;
        this.text = text;
    }
    
    public MyTextAsset(TextAsset textAsset)
    {
        name = textAsset.name;
        text = textAsset.text;
    }
}