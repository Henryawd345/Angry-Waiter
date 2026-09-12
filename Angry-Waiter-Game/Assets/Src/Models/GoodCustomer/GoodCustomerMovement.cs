using UnityEngine;

public class GoodCustomerMovement
{
    private GoodCustomer goodCustomer;
    private LevelManager levelManager;

    public GoodCustomerMovement(GoodCustomer goodCustomer, LevelManager levelManager)
    {
        this.goodCustomer = goodCustomer;
        this.levelManager = levelManager;
    }


    public void moveToTable(Table table)
    {
        goodCustomer.arriveAtTable();
    }

    public void moveToExit()
    {
        
    }

    public void reset()
    {
        
    }
}
