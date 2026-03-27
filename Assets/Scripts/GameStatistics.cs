using UnityEngine;

public class GameStatistics : MonoBehaviour
{
    public static GameStatistics Instance;

    private int generalStats;
    private int generalStatsTotal;
    
    private int listeningStats;
    private int listeningStatsTotal;
    private int trueFalseStats;
    private int trueFalseStatsTotal;
    private int multipleChoiceStats;
    private int multipleChoiceStatsTotal;

    
    public int GeneralStats { get => generalStats; set => generalStats = value; }
    public int GeneralStatsTotal { get => generalStatsTotal;  set => generalStatsTotal = value; }
    public int ListeningStats { get => listeningStats; set => listeningStats = value; }
    public int ListeningStatsTotal { get => listeningStatsTotal; set => listeningStatsTotal = value; }
    public int TrueFalseStats { get => trueFalseStats; set => trueFalseStats = value; }
    public int TrueFalseStatsTotal { get => trueFalseStatsTotal; set => trueFalseStatsTotal = value; }
    public int MultipleChoiceStats { get => multipleChoiceStats; set => multipleChoiceStats = value; }
    public int MultipleChoiceStatsTotal { get => multipleChoiceStatsTotal ; set => multipleChoiceStatsTotal = value; }
    

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
        trueFalseStats = 0;
        trueFalseStatsTotal = 0;
        multipleChoiceStats = 0;
        multipleChoiceStatsTotal = 0;
    }
}
