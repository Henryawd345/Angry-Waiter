using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelData levelData;
    public LevelTimer levelTimer;


    private bool dayStarted;
    private bool dayEnded;


    public static LevelManager instance;
    void Awake()
    {
        if (instance != null || instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        levelData = new LevelData(0, 0); // provide chapter number and day number
        levelTimer = new LevelTimer(this);

        dayStarted = false;
        dayEnded = false;
    }
    void Update()
    {
        levelTimer.Tick(Time.deltaTime);
    }




    public void startDay()
    {
        dayStarted = true;
    }
    public void timesUp()
    {
        dayEnded = true;
    }

    public void gainMoney(float moneyGained)
    {
        levelData.gainMoney(moneyGained);
    }
    public void changeReputationBy(float rep)
    {
        levelData.changeReputationBy(rep);
    }

}
