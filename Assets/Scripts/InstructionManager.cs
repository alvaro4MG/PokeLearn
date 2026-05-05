using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class InstructionManager : MonoBehaviour
{
    public static InstructionManager Instance;
    private Animator _animator;

    [Header("Instructions")]
    [SerializeField] private List<Sprite> _instructions;
    [SerializeField] private Image _background;

    [Header("Pokemon Picker")]
    [SerializeField] private GameObject _pokemonPicker;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private List<Pokemon> _pokemons;

    [Header("Unit Sprites")]
    [SerializeField] private Image _badgeSprite;
    [SerializeField] private Image _leaderSprite;

    [Header("Fade In")]
    [SerializeField] private FadeIO _fadeIn;

    [Header("Dialogue")]
    [SerializeField] private GameObject _dialogue1GO;
    [SerializeField] private TMP_Text _dialogue1Text;
    [SerializeField] private GameObject _dialogue2GO;
    [SerializeField] private GameObject _dialogue3GO;
    
    private int idInstruction;
    
    
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        idInstruction = 0;
        QuestionConverter.LoadQuestions();
        _badgeSprite.gameObject.SetActive(true);
        _badgeSprite.sprite = GameSettings.Instance.CurrentBadge;
        _leaderSprite.gameObject.SetActive(true);
        _leaderSprite.sprite = GameSettings.Instance.CurrentLeader;
        
        _background.sprite = _instructions[idInstruction];
        _nextButton.SetActive(true);
        _pokemonPicker.SetActive(false);
        _fadeIn.SetActive(false, 1f);
        
        _dialogue1GO.SetActive(true);
        _dialogue1Text.text = LoadDialogue();
    }
    
    
    public void NextInstruction()
    {
        idInstruction++;

        switch (idInstruction)
        {
            case 1:     // Instructions/RULES
                _dialogue1GO.SetActive(false);
                _dialogue2GO.SetActive(true);
                break;
            case 2:     // Choose your team
                _dialogue2GO.SetActive(false);
                _dialogue3GO.SetActive(true);
                break;
            case 3:     // Pokemon Picker
                _dialogue3GO.SetActive(false);
                _leaderSprite.gameObject.SetActive(false);
                _nextButton.SetActive(false);
                _pokemonPicker.SetActive(true);
                break;
            case 4:     // No more instructions
                StartCoroutine(FadeIn());
                return;
        }
        _background.sprite = _instructions[idInstruction];
        
    }

    public void PickPokemon(int idPokemon)
    {
        GameSettings.Instance.SetPokemonId(idPokemon);
        GameSettings.Instance.SetPokemonSelected(_pokemons[idPokemon]);
        //Debug.Log("ID del pokemon: " + idPokemon);
        
        //SceneManager.LoadScene("CombatScene");
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        _fadeIn.SetActive(true, 0f);
        _fadeIn.FadeIn();
        yield return new WaitForSeconds(_fadeIn.Duration);
        SceneManager.LoadScene("CombatScene");
    }

    private String LoadDialogue()
    {
        return
            "Hello I'm <color=red>" + GameSettings.Instance.CurrentLeaderName + "</color>, the <color=red>Pokemon gym leader</color>\n" +
            "I will ask you <color=blue>" + GameSettings.Instance.QuestionsNumber + " questions</color> about the unit.\n \n-TAP the correct answer\n" +
            "-At the end, <color=green>YOU WIN</color> or <color=yellow>YOU LOOSE</color> will appear\nWhen <color=green>YOU WIN</color>, you get this badge";
    }

}
