using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance; //{ get; private set; }

    [Header("Settings")]
    private bool muted;
    private int volume;
    private int unit;

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

    

}
