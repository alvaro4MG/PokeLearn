using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Scriptable Objects/Pokemon")]
public class Pokemon : ScriptableObject
{
    [Header("Pokemon Info")]
    [SerializeField] private int idPokemon;
    [SerializeField] private string _pokemonName;
    [SerializeField] private ETypes _type;
    [SerializeField] private int _hp;
    
    [Header("Pokemon Sprites")]
    [SerializeField] public Sprite _spriteFront;
    [SerializeField] public Sprite _spriteBack;

    public void OnPokemonPicked()
    {
        // Hacer aqui el GameSettings en lugar de desde los botones de pokemon picker
        
    }
}
