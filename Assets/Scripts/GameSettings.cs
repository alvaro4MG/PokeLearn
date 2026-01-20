using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance; //{ get; private set; }
    
    //private bool muted;
    //private int volume;
    [SerializeField] private int _unit;
    [SerializeField] private int _pokemonId;
    [SerializeField] private Pokemon _pokemonSelected;

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

}
