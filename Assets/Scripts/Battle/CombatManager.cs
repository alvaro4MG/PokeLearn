using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;
    
    [Header("HP data")]
    [SerializeField] private int _allyHP;
    [SerializeField] private int _enemyHP;
    [SerializeField] public int _maxHP = 10;
    
    [Header("Custom sprites for battle")]
    [SerializeField] private Image _allySprite;
    [SerializeField] private Image _leaderSprite;
    [SerializeField] private Image _pokemonEnemySprite;

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
        _leaderSprite.sprite = GameSettings.Instance.CurrentLeader;
        _pokemonEnemySprite.sprite = GameSettings.Instance.CurrentPokemonEnemy;
    }

    public void SetUpMaxHealth(int value)
    {
        _maxHP = value;
        _allyHP = _maxHP;
        _enemyHP = _maxHP;
        _allyHPBar.SetMaxHealth(_maxHP);
        _enemyHPBar.SetMaxHealth(_maxHP);
        UpdateHP(_allyHPTextBox, _maxHP);
        UpdateHP(_enemyHPTextBox, _maxHP);
    }

    public bool DamageAlly(int damage)
    {
        //AudioManager.Instance.PlayHitAlly();
        _allyHP -= damage;
        if (_allyHP <= 0)
        {
            return true;
        }
        UpdateHP(_allyHPTextBox, _allyHP);
        _allyHPBar.SetHealth(_allyHP);
        return false;
    }

    public bool DamageEnemy(int damage)
    {
        //AudioManager.Instance.PlayHitEnemy();
        _enemyHP  -= damage;
        if (_enemyHP <= 0)
        {
            return true;
        }
        UpdateHP(_enemyHPTextBox, _enemyHP);
        _enemyHPBar.SetHealth(_enemyHP);
        return false;
    }

    private void UpdateHP(TMP_Text textBox, int hp)
    {
        textBox.text = hp.ToString() + "/" + _maxHP.ToString();
    }

    public bool IsWin()
    {
        return _allyHP >= _enemyHP;
    }

    public void delayButtons(List<Button> buttons)
    {
        StartCoroutine(Delay(buttons));
    }

    private IEnumerator Delay(List<Button> buttons)
    {
        // deactivate buttons
        foreach (var button in buttons)
        {
            button.interactable = false;
        }
        
        yield return new WaitForSeconds(GameSettings.Instance.Delay);
        
        // reactivate buttons
        foreach (var button in buttons)
        {
            button.interactable = true;
        }
    }

}
