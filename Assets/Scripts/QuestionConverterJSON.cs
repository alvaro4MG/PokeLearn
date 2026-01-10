using System.Collections.Generic;
using UnityEngine;

public class QuestionConverterJSON : MonoBehaviour
{
    [SerializeField] private string jsonFileName = "Questions/unit_1";

    public List<Question> questions = new();

    private void Awake()
    {
        LoadQuestions();
    }

    private void LoadQuestions()
    {
        TextAsset json = Resources.Load<TextAsset>(jsonFileName);

        if (json == null)
        {
            Debug.LogError("Could not find JSON file");
            return;
        }

        QuestionDataList dataList =
            JsonUtility.FromJson<QuestionDataList>(json.text);

        foreach (QuestionData data in dataList.questions)
        {
            Question q = new Question();
            q.questionText = data.text;
            q.wrongAnswers = new List<string>();

            for (int i = 0; i < data.answers.Count; i++)
            {
                if (i == data.correctIndex)
                    q.correctAnswer = data.answers[i];
                else
                    q.wrongAnswers.Add(data.answers[i]);
            }

            if (!string.IsNullOrEmpty(data.image))
            {
                q.image = Resources.Load<Sprite>("Images/" + data.image);
            }

            questions.Add(q);
        }

        Debug.Log($"Loaded questions: {questions.Count}");
    }
}
