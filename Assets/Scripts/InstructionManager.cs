using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InstructionManager : MonoBehaviour
{
    public static InstructionManager Instance;
    private Animator _animator;

    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _sFXClip;

    [SerializeField] private List<Sprite> _instructions;
    [SerializeField] private Image _background;

    private int id;


    //private InputActions _controls;
    
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    /*private void Awake(){
        //_animator = GetComponent<Animator>();
        //_backgroundMusic = GetComponent<AudioSource>();
        //_controls = new InputActions();
        
    }*/

    // Start is called before the first frame update
    void Start()
    {
        id = 0;
        //_animator.Play("toggle");
        //_backgroundMusic.Play();
        _background.sprite = _instructions[id];
    }
    
    
    public void NextInstruction()
    {
        id++;
        if (id >= _instructions.Count)
        {
            SceneManager.LoadScene("CombatScene");
            return;
        }
        _background.sprite = _instructions[id];
    }
    

}
