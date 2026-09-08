using System.Collections.Generic;
using UnityEngine;

public class GoodCustomer : MonoBehaviour
{
    private LevelManager levelManager;
    private GoodCustomerMovement goodCustomerMovement;


    private const float patienceTimerInit = 35f;
    private const float timeTakeToEatEach = 1.5f;


    public GameObject orderPrefabObject;


    private Table table;
    private GameObject foodOrderObject;
    private FoodOrder foodOrder;
    private float foodPrice;

    private gcState customerState;
    private float patienceTimer;
    private float eatingTimer;

    void Start()
    {
        levelManager = LevelManager.instance;
        goodCustomerMovement = new GoodCustomerMovement(this, levelManager);
    }
    public void initialize()
    {
        customerState = gcState.waitingForSeat;
        patienceTimer = patienceTimerInit;
        eatingTimer = 0;

        table = null;
        foodOrder = null;
        foodOrderObject = null;
        foodPrice = 0;

        goodCustomerMovement.reset();
    }

    void Update()
    {
        if (customerState == gcState.waitingForSeat)
            waitingForTableState();
        else if (customerState == gcState.waitingForFood)
            waitingForFoodState();
        else if (customerState == gcState.eating)
            eatingState();

        if (patienceTimer <= 0 && customerState != gcState.leaving)
            quitAngry();
    }

    public void doAction() // will be called when player interact with customer
    {
        if (customerState == gcState.waitingForSeat)
            getCustomerForBind();
        else if (customerState == gcState.waitingForBill)
            collectMoney();
        else
            Debug.Log("What?");
    }
    // do action methods
    public GoodCustomer getCustomerForBind()
    {
        return this;
    }
    public void kickCustomer()
    {
        quitAngry();
    }


    // loops
    private void waitingForTableState()
    {
        patienceTimer -= Time.deltaTime;
    }
    private void waitingForFoodState()
    {
        patienceTimer -= Time.deltaTime;
    }
    private void eatingState()
    {
        eatingTimer -= Time.deltaTime;
        if (eatingTimer <= 0)
            customerState = gcState.waitingForBill;
    }


    public void bindTable(Table table)
    {
        if (table.isReserved || this.table != null || table == null || customerState == gcState.leaving)
            return;

        this.table = table;

        this.table.reserve(this, transform);
        customerState = gcState.walkingToTable;

        goodCustomerMovement.moveToTable(this.table);
    }
    public void arriveAtTable() // call by good customer movement
    {
        table.sit();

        customerState = gcState.waitingForFood;
        patienceTimer = patienceTimerInit;
        createFoodOrder();
    }
    private void createFoodOrder()
    {
        if (foodOrder != null || foodOrderObject != null)
            return;

        foodOrderObject = GameObject.Instantiate(orderPrefabObject);
        foodOrder = foodOrderObject.GetComponent<FoodOrder>();

        // test with new food category list (For debug purpose only)
        List<FoodCategory> foodCategoryList = new List<FoodCategory>();
        foodCategoryList.Add(FoodCategory.Drink);


        foodOrder.initialize(this, Random.Range(0,5) , foodCategoryList );
    }
    public void foodOrderComplete(float foodPrice, int foodAmount) // will be called by FoodOrder script
    {
        if (customerState == gcState.leaving || foodOrder == null)
            return;

        customerState = gcState.eating;
        eatingTimer = foodAmount * timeTakeToEatEach;
        this.foodPrice = foodPrice;

        foodOrder = null;
        foodOrderObject = null;
    }
    public void collectMoney()
    {
        if (customerState == gcState.waitingForBill)
        {
            levelManager.gainMoney(foodPrice);
            quitHappy();
        }
    }


    private void quitHappy()
    {
        if (customerState == gcState.leaving)
            return;
        customerState = gcState.leaving;

        foodOrder = null;
        foodOrderObject = null;

        if (table != null)
            table.standUp(this);
        table = null;

        goodCustomerMovement.moveToExit();
    }
    private void quitAngry()
    {
        if (customerState == gcState.leaving)
            return;
        customerState = gcState.leaving;

        if (foodOrder != null)
        {
            foodOrder.orderCanceled();

            foodOrder = null;
            foodOrderObject = null;
        }

        goodCustomerMovement.reset();

        if (table != null)
            table.standUp(this);
        table = null;

        goodCustomerMovement.moveToExit();
    }
}
