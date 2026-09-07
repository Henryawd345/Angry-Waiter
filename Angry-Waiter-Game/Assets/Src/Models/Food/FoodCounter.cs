using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCounter : MonoBehaviour
{
    private FoodCategory servingFoodCategory;
    private List<FoodType> servingFoods;

    public void Initialize(FoodCategory servingFoodCategory)
    {
        this.servingFoodCategory = servingFoodCategory;
        servingFoods = new List<FoodType>();

        int foodsPerCategory = 5;
        int startIndex = (int)servingFoodCategory * foodsPerCategory;

        for (int i = 0; i < foodsPerCategory; i++)
        {
            FoodType foodType = (FoodType)(startIndex + i);
            servingFoods.Add(foodType);
        }
    }
}
