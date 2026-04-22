using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
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

    [Header("Fade In")]
    [SerializeField] private FadeIO _fadeIn;
    
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
        //_animator.Play("toggle");
        _background.sprite = _instructions[idInstruction];
        _nextButton.SetActive(true);
        _pokemonPicker.SetActive(false);
        _fadeIn.SetActive(false, 1f);
    }
    
    
    public void NextInstruction()
    {
        idInstruction++;
        if (idInstruction >= _instructions.Count)
        {
            StartCoroutine(FadeIn());
            return;
        }
        _background.sprite = _instructions[idInstruction];
        if (idInstruction == _instructions.Count - 1)
        {
            _nextButton.SetActive(false);
            _pokemonPicker.SetActive(true);
        }
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

}
