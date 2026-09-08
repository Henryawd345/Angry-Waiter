using System.Collections.Generic;
using UnityEngine;

public class FoodOrder : MonoBehaviour
{
    private const int maxAmountOrder = 5;


    private GoodCustomer goodCustomer;

    public int orderAmount {get; private set;}
    public float foodTotalPrice {get; private set;}
    private List<FoodCategory> orderableFoodCategories;
    
    
    public List<FoodType> orderedFoods;

    public void initialize(GoodCustomer goodCustomer, int orderAmount, List<FoodCategory> orderableFoodCategories)
    {
        this.goodCustomer = goodCustomer;

        if (orderAmount > maxAmountOrder) this.orderAmount = maxAmountOrder;
        else if (orderAmount < 1) this.orderAmount = 1;
        else this.orderAmount = orderAmount;

        orderedFoods = new List<FoodType>();
        this.orderableFoodCategories = orderableFoodCategories;

        generateOrder();
    }

    private void generateOrder()
    {
        for (int i = 0; i < orderAmount; i++)
        {
            int orderFoodCategory = Random.Range(0, orderableFoodCategories.Count);
            int orderFoodIndex = Random.Range(0,5);

            int orderedFoodIndex = (1 * orderFoodCategory) + orderFoodIndex;
            FoodType orderedFood = (FoodType)orderedFoodIndex;

            orderedFoods.Add(orderedFood);
        }

        foodTotalPrice = 10f; // this will be calculated according to later
    }

    public void recieveFood(GameObject foodGameObject) // called when food enter order area
    {
        // check stuff until complete
        // orderComplete();
    }

    public void orderCanceled()
    {
        Destroy(gameObject);
    }

    private void orderComplete()
    {
        goodCustomer.foodOrderComplete(foodTotalPrice, orderAmount);
        Destroy(gameObject);
    }
}
