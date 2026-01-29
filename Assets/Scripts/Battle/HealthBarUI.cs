using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [Header("Parameters")]
    //[SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _width;
    [SerializeField] private float _height;
    
    [Header("UI Reference")]
    [SerializeField] private RectTransform _healthBar;
    [SerializeField] private RectTransform _parent;

    private void Start()
    {
        _maxHealth = CombatManager._maxHP;
        SetHealth(_maxHealth);
        _height = _parent.sizeDelta.y;
        _width = _parent.sizeDelta.x;
    }

    public void SetHealth(float value)
    {
        value = Mathf.Clamp(value, 0, _maxHealth);
        float newWidth = (value / _maxHealth) * _width;
        
        //_healthBar.sizeDelta = new Vector2(_width, _height);
        _healthBar.sizeDelta = new Vector2(newWidth, _height);
        
    }
    
}
