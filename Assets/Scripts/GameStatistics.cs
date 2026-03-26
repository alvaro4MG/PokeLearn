using UnityEngine;

public class GameStatistics : MonoBehaviour
{
    public static GameStatistics Instance;

    private int generalStats = 0;
    private int generalStatsTotal = 0;
    
    private int listeningStats = 0;
    private int listeningStatsTotal = 0;
    private int truefalseStats = 0;
    private int truefalseStatsTotal = 0;
    private int multipleChoiceStats = 0;
    private int multipleChoiceStatsTotal = 0;

    /*public int GeneralStats
    {
        get => generalStats;
        set => generalStats = value;
    }
    
    public int GeneralStatsTotal
    {
        get => generalStatsTotal;
        set => generalStatsTotal = value;
    }*/
    
    public int GeneralStats { get;  set; }
    public int GeneralStatsTotal { get;  set; }
    public int ListeningStats { get;  set; }
    public int ListeningStatsTotal { get;  set; }
    public int TruefalseStats { get;  set; }
    public int TruefalseStatsTotal { get;  set; }
    public int MultipleChoiceStats { get;  set; }
    public int MultipleChoiceStatsTotal { get;  set; }
    
    

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
        
        listeningStats = 0;
        listeningStatsTotal = 0;
        truefalseStats = 0;
        truefalseStatsTotal = 0;
        multipleChoiceStats = 0;
        multipleChoiceStatsTotal = 0;
    }
}
