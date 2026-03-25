using UnityEngine;

public class GameStatistics : MonoBehaviour
{
    public static GameStatistics Instance;

    private int generalStats = 0;
    private int generalStatsTotal = 0;

    public int GeneralStats
    {
        get => generalStats;
        set => generalStats = value;
    }
    
    public int GeneralStatsTotal
    {
        get => generalStatsTotal;
        set => generalStatsTotal = value;
    }

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


    public void RestartStats()
    {
        generalStats = 0;
        generalStatsTotal = 0;
    }
}
