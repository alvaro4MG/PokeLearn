using UnityEngine;

public class DissappearScript : MonoBehaviour
{
    [SerializeField] GameObject _object;
    
    public void Toggle()
    {
        _object.SetActive(!_object.activeSelf);
    }
}
