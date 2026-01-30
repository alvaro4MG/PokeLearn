using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;
    
    [Header("HP data")]
    [SerializeField] private int _allyHP;
    [SerializeField] private int _enemyHP;
    [SerializeField] public const int _maxHP = 10;
    
    [Header("Sprites")]
    [SerializeField] private Image _allySprite;

    [Header("References HP Bar")] 
    [SerializeField] private TMP_Text _allyHPTextBox;
    [SerializeField] private HealthBarUI _allyHPBar;
    [SerializeField] private TMP_Text _enemyHPTextBox;
    [SerializeField] private HealthBarUI _enemyHPBar;
    
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
        //AudioManager.Instance.StopBackgroundMusic();
        AudioManager.Instance.PlayCynthiaMusic();
        _allySprite.sprite = GameSettings.Instance.GetPokemonSprite();
        _allyHP = _maxHP;
        _enemyHP = _maxHP;
        UpdateHP(_allyHPTextBox, _maxHP);
        UpdateHP(_enemyHPTextBox, _maxHP);
    }

    public bool DamageAlly(int damage)
    {
        _allyHP -= damage;
        if (_allyHP <= 0)
        {
            return true;
        }
        UpdateHP(_allyHPTextBox, _allyHP);
        _allyHPBar.SetHealth(_allyHP);
        return false;
    }

    public void DamageEnemy(int damage)
    {
        _enemyHP  -= damage;
        UpdateHP(_enemyHPTextBox, _enemyHP);
        _enemyHPBar.SetHealth(_enemyHP);
    }

    private void UpdateHP(TMP_Text textBox, int hp)
    {
        textBox.text = "HP: " + hp.ToString() + "/" + _maxHP.ToString();
    }

}
