using UnityEditor.Rendering;
using UnityEngine;

public class LevelData
{
    private const float startReputation = 100f;



    public int chapter {get; private set;}
    public int dayNum {get; private set;}


    public float reputation {get; private set;}
    public float money {get; private set;}

    public LevelData(int chapter, int dayNum)
    {
        this.chapter = chapter;
        this.dayNum = dayNum;

        reputation = startReputation;
        money = 0;
    }


    public void gainMoney(float moneyGained)
    {
        if (moneyGained >= 0)
            money += moneyGained;
    }
    public void changeReputationBy(float rep)
    {
        reputation += rep;
    }
}
