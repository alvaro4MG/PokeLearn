using UnityEngine;

public class PlayAudioButton : MonoBehaviour
{

    [Header("Sprites")]
    [SerializeField] private Sprite _buttonOff;
    [SerializeField] private Sprite _buttonPlaying;
    
    private AudioSource questionAudio;  // obtain from QuestionManager
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void playAudio()
    {
        questionAudio.Play();
        
        //wait for end
        
        //change sprite
    }
}
