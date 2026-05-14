using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
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
    [SerializeField] private AudioSource questionAudio;
    //[SerializeField] private GameObject audioButton;
    [SerializeField] private TMP_Text fullQuestionTextBox;
    [SerializeField] private TMP_Text questionNumber;
    //[SerializeField] private Image resultBox;
    
    [Header("Answer TextBox")]
    [SerializeField] private GameObject group4Answer;
    [SerializeField] private List<TMP_Text> answerTextBox4;
    [SerializeField] private GameObject group2Answer;
    [SerializeField] private List<TMP_Text> answerTextBox2;
    
    [Header("Audio Settings TextBox")]
    [SerializeField] private TMP_Text _volumeMusicDisplay;
    [SerializeField] private TMP_Text _volumeFXDisplay;
    
    [Header("Play Audio Button")]
    [SerializeField] private PlayAudioButton _playAudioButton;
    
    [Header("Loading screen")]
    [SerializeField] private float _loadingTime = 0.5f;

    [Header("Answer Buttons")]
    [SerializeField] private List<Button> _answerButtons4;
    [SerializeField] private List<Button> _answerButtons2;
    
    [Header("Delay")]
    [SerializeField] private float _delay;
    [SerializeField] private FadeIO _fadeOut;
    
    
    
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
        _fadeOut.SetActive(true, 1f);
        GameStatistics.Instance.RestartStats();
        
        //Read .txt or json
        _questionsList = LoadQuestions();
        CombatManager.Instance.SetUpMaxHealth(_questionsList.Count);
        //StartCoroutine(WaitForLoadedQuestions());
        _fadeOut.FadeOut();
        //_fadeOut.SetActive(false, 0f);
        
        //Debug.Log("sigue");
        ShowQuestion();
        SetVolumesTextBox(-1);
    }

    private IEnumerator WaitForLoadedQuestions()
    {
        //Debug.Log("Empieza cuenta");
        yield return new WaitForSeconds(_loadingTime);
        //Debug.Log("TERMINA cuenta");
        ShowQuestion();
        //Debug.Log("Enseñando preguntas");
    }

    public int GetNumbersOfQuestions()
    {
        return _questionsList.Count;
    }

    private List<Question> LoadQuestions()
    {
        //List<Question> list = new List<Question>();

        //QuestionConverter
        
        //QuestionConverter.LoadQuestions();
        return QuestionConverter.GetQuestions();
        
        // Check grammar on file on QuestionConverter then read here
        
        
        
        //return list;
        return QuestionConverter.questions;
    }

    public void ShowQuestion()
    {
        // Update number on UI
        UpdateQuestionNumber(id);
        
        // Text and/or image of the questions
        /*if (_questionsList[id].image != null)
        {
            fullQuestionTextBox.gameObject.SetActive(false);
            questionTextBox.gameObject.SetActive(true);
            questionImage.gameObject.SetActive(true);
            questionTextBox.text = _questionsList[id].questionText;
            questionImage.sprite = _questionsList[id].image;
            //questionAudio.audio = null; 
            questionAudio.clip = null;
        }
        else
        {
            fullQuestionTextBox.gameObject.SetActive(true);
            questionTextBox.gameObject.SetActive(false);
            questionImage.gameObject.SetActive(false);
            fullQuestionTextBox.text = _questionsList[id].questionText;
            questionImage.sprite = null;
        }*/
        
        // Image or Audio of the question
        if (_questionsList[id].image != null)
        {
            fullQuestionTextBox.gameObject.SetActive(false);
            questionTextBox.gameObject.SetActive(true);
            questionImage.gameObject.SetActive(true);
            questionAudio.gameObject.SetActive(false);
            questionTextBox.text = _questionsList[id].questionText;
            questionImage.sprite = _questionsList[id].image;
            questionAudio.clip = null;
        }
        else if (_questionsList[id].audio != null)
        {
            fullQuestionTextBox.gameObject.SetActive(false);
            questionTextBox.gameObject.SetActive(true);
            questionImage.gameObject.SetActive(false);
            questionAudio.gameObject.SetActive(true);
            questionTextBox.text = _questionsList[id].questionText;
            questionImage.sprite = null; 
            questionAudio.clip = _questionsList[id].audio;
            _playAudioButton.SetAudio(questionAudio.clip);
        }
        else
        {
            fullQuestionTextBox.gameObject.SetActive(true);
            questionTextBox.gameObject.SetActive(false);
            questionImage.gameObject.SetActive(false);
            questionAudio.gameObject.SetActive(false);
            fullQuestionTextBox.text = _questionsList[id].questionText;
            questionImage.sprite = null;
            questionAudio.clip = null;
        }
        
        // Result box for debugging
        //resultBox.color = Color.gray;

        // Correct and incorrect answers (see option for 2 and 4 answers)
        if (_questionsList[id].wrongAnswers.Count == 1)
        {
            group2Answer.SetActive(true);
            group4Answer.SetActive(false);
            ShowAnswers(answerTextBox2);
            CombatManager.Instance.delayButtons(_answerButtons2);
        }
        else
        {
            group4Answer.SetActive(true);
            group2Answer.SetActive(false);
            ShowAnswers(answerTextBox4);
            CombatManager.Instance.delayButtons(_answerButtons4);
        }
        

        
        // Delay de botones (más arriba)
        //CombatManager.Instance.delayButtons();
    }

    public void ShowAnswers(List<TMP_Text> answers)
    {

        if (_questionsList[id].wrongAnswers.Count == 1)   // for T/F, False is left (red button) and True is right
        {
            if (String.Equals(_questionsList[id].correctAnswer, "False"))
            {
                answers[0].text = _questionsList[id].correctAnswer;
                correctAnswerButton = 0;
                answers[1].text = _questionsList[id].wrongAnswers[0];
            }
            else
            {
                answers[0].text = _questionsList[id].wrongAnswers[0];
                answers[1].text = _questionsList[id].correctAnswer;
                correctAnswerButton = 1;
            }
            return;
        }
        
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
            if (!CombatManager.Instance.DamageEnemy(1))
            {
                AudioManager.Instance.PlayHitEnemy();
            }
            
            GameStatistics.Instance.GeneralStats++;
            if (questionAudio.clip != null)
            {
                GameStatistics.Instance.ListeningStats++;
                GameStatistics.Instance.ListeningStatsTotal++;
            } 
            else if (_questionsList[id].wrongAnswers.Count == 1)
            {
                GameStatistics.Instance.TrueFalseStats++;
                GameStatistics.Instance.TrueFalseStatsTotal++;
            }
            else
            {
                GameStatistics.Instance.MultipleChoiceStats++;
                GameStatistics.Instance.MultipleChoiceStatsTotal++;
            }
        }
        else
        {
            if (!CombatManager.Instance.DamageAlly(1))
            {
                AudioManager.Instance.PlayHitAlly();
            }
            
            if (questionAudio.clip != null)
            {
                GameStatistics.Instance.ListeningStatsTotal++;
            }
            else if (_questionsList[id].wrongAnswers.Count == 1)
            {
                GameStatistics.Instance.TrueFalseStatsTotal++;
            }
            else
            {
                GameStatistics.Instance.MultipleChoiceStatsTotal++;
            }
        }
        
        id++;
        if (id < _questionsList.Count)
        {
            ShowQuestion();
        }
        else
        {
            id = 0;
            GameStatistics.Instance.GeneralStatsTotal = _questionsList.Count;
            GameSettings.Instance.SetWin(CombatManager.Instance.IsWin());
            SceneManager.LoadScene("EndScene");
        }
    }

    public void UpdateQuestionNumber(int number)
    {
        questionNumber.text = "Q: " + (number+1) + "/" + _questionsList.Count;
    }
    
    
    public void VolumeMusic(int i)
    {
        if((AudioManager.Instance.GetVolumeMusic() >= 10 && i > 0) || (AudioManager.Instance.GetVolumeMusic() <= 0 && i < 0) )
        {
            return;
        }
        AudioManager.Instance.PlayNavigateUI();
        _volumeMusicDisplay.text = AudioManager.Instance.VolumeMusic(i).ToString();
    }
    
    public void VolumeFX(int i)
    {
        if((AudioManager.Instance.GetVolumeFX() >= 10 && i > 0) || (AudioManager.Instance.GetVolumeFX() <= 0 && i < 0) )
        {
            return;
        }
        AudioManager.Instance.PlayNavigateUI();
        _volumeFXDisplay.text = AudioManager.Instance.VolumeFX(i).ToString();
    }

    public void SetVolumesTextBox(int value)
    {
        if (value < 0)
        {
            _volumeMusicDisplay.text = AudioManager.Instance.GetVolumeMusic().ToString();
            _volumeFXDisplay.text = AudioManager.Instance.GetVolumeFX().ToString();
            return;
        }
        _volumeMusicDisplay.text = value.ToString();
        _volumeFXDisplay.text = value.ToString();
    }

    public void PlayAudio()
    {
        //questionAudio.Play();
        _playAudioButton.PlayAudio();
    }

    public void ConvertAudioClip(string audioName, System.Action<AudioClip> onLoaded)
    {
        StartCoroutine(LoadAudioCoroutine(audioName, onLoaded));
    }

    private IEnumerator LoadAudioCoroutine(string audioPath, System.Action<AudioClip> onLoaded)
    {
        string path = Path.Combine(Application.streamingAssetsPath, audioPath);

        UnityWebRequest req = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.MPEG);

        yield return req.SendWebRequest();

        if (req.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Audio load error: " + req.error);
            onLoaded?.Invoke(null);
            yield break;
        }

        AudioClip clip = DownloadHandlerAudioClip.GetContent(req);
        onLoaded?.Invoke(clip);
    }

}
