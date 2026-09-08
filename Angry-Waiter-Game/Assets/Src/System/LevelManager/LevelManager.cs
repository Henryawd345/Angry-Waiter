using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelData levelData;
    public LevelTimer levelTimer;


    private bool dayStarted;
    private bool dayEnded;


    public bool isPaused {get; private set;}


    public static LevelManager instance;
    void Awake()
    {
        initSingleton();

        levelData = new LevelData(0, 0); // provide chapter number and day number
        levelTimer = new LevelTimer(this);

        dayStarted = false;
        dayEnded = false;

        isPaused = false;
    }
    private void initSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
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


    public void togglePause()
    {
        if (isPaused)
            resume();
        else
            pause();
    }
    private void resume()
    {
        Time.timeScale = 1f;          // Reset time to normal speed
        isPaused = false;
    }
    private void pause()
    {
        Time.timeScale = 0f;           // Freeze the game world
        isPaused = true;
    }

}
