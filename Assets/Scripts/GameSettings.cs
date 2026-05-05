using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;
    
    //private bool muted;
    //private int volume;
    [SerializeField] private int _unit;
    [SerializeField] private int _pokemonId;
    [SerializeField] private Pokemon _pokemonSelected;
    [SerializeField] private bool win = false;
    
    [Header("Delay")]
    [SerializeField] private float _delay;

    private Sprite _currentBadge;
    private Sprite _currentLeader;
    private string _currentLeaderName;
    private int _questionsNumber;
    
    public Sprite CurrentBadge { get { return _currentBadge; } set { _currentBadge = value; } }
    public Sprite CurrentLeader { get { return _currentLeader; } set { _currentLeader = value; } }
    public string CurrentLeaderName { get { return _currentLeaderName; } set { _currentLeaderName = value; } }
    public int QuestionsNumber { get { return _questionsNumber; } set { _questionsNumber = value; } }

    public float Delay
    {
        get => _delay;
        set => _delay = value;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    

    public void SetUnit(int unit)
    {
        _unit = unit;
    }
    
    public void SetPokemonId(int pokemonId)
    {
        _pokemonId = pokemonId;
    }

    public void SetPokemonSelected(Pokemon pokemonSelected)
    {
        _pokemonSelected = pokemonSelected;
    }

    public Sprite GetPokemonSprite()
    {
        return _pokemonSelected._spriteBack;
    }

    public bool GetWin()
    {
        return win;
    }

    public void SetWin(bool win)
    {
        this.win = win;
    }

}
