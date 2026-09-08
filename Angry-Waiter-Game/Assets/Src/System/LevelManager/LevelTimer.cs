using UnityEngine;

public class LevelTimer
{
    private LevelManager levelManager;



    private bool isTimerRunning;
    public float timeLeft {get; private set;}

    public LevelTimer(LevelManager levelManager)
    {
        this.levelManager = levelManager;
        timeLeft = 300;
        isTimerRunning = false;
    }



    public void startTimer()
    {isTimerRunning = true;}
    public void stopTimer()
    {isTimerRunning = false;}

    public void Tick(float deltaTime) // be called on Monobeheavour Update()
    {
        if (!isTimerRunning)
            return;

        timeLeft -= deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;

            stopTimer();
            levelManager.timesUp();
        }
    }
}
