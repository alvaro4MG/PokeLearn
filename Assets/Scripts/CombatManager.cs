using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;
    
    [Header("HP data")]
    [SerializeField] private int _allyHP;
    [SerializeField] private int _enemyHP;
    
    [Header("Sprites")]
    [SerializeField] private Image _allySprite;
    
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
        AudioManager.Instance.StopBackgroundMusic();
        AudioManager.Instance.PlayCynthiaMusic();
        _allySprite.sprite = GameSettings.Instance.GetPokemonSprite();
    }

    
}
