using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private const int maxAmountOrder = 5;


    private int orderAmount;
    private List<FoodCategory> orderableFoodCategories;
    
    
    public List<FoodType> orderedFoods;

    public void initialize(int orderAmount, List<FoodCategory> orderableFoodCategories)
    {
        if (orderAmount > maxAmountOrder) this.orderAmount = maxAmountOrder;
        else if (orderAmount < 1) this.orderAmount = 1;
        else this.orderAmount = orderAmount;

        orderedFoods = new List<FoodType>();
        this.orderableFoodCategories = orderableFoodCategories;
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
    }
}
