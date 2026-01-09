using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject _object;
    
    public void Toggle()
    {
        _object.SetActive(!_object.activeSelf);
    }
}
