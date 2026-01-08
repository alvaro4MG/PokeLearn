using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject _object;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Toggle()
    {
        _object.SetActive(!_object.activeSelf);
    }
}
