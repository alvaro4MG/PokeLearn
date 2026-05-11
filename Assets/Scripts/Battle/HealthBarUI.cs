using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float _width;
    [SerializeField] private float _height;
    
    [Header("UI Reference")]
    [SerializeField] private RectTransform _healthBar;
    [SerializeField] private RectTransform _parent;

    private float _maxHealth;
    
    private void Start()
    {
        _height = _parent.sizeDelta.y;
        _width = _parent.sizeDelta.x;
    }

    public void SetMaxHealth(float maxHealth)
    {
        _maxHealth = maxHealth;
        SetHealth(_maxHealth);
    }

    public void SetHealth(float value)
    {
        value = Mathf.Clamp(value, 0, _maxHealth);
        float newWidth = (value / _maxHealth) * _width;
        
        _healthBar.sizeDelta = new Vector2(newWidth, _height);
    }
    
}
