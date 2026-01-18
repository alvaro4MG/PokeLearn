using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance; //{ get; private set; }
    
    //private bool muted;
    //private int volume;
    [SerializeField] private int unit;

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
        this.unit = unit;
    }

}
