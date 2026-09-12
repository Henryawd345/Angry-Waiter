using System.Collections.Generic;
using UnityEngine;

public class PlayerServing
{
    private const int maxHoldableFoodAmount = 3;

    private GameObject foodInventoryObject;
    private GameObject playerHandObject;

    private List<Food> foodList;
    private Food foodInHand;
    private int foodInHandIndex;

    public PlayerServing(GameObject foodInventoryObject, GameObject playerHandObject)
    {
        this.foodInventoryObject = foodInventoryObject;
        this.playerHandObject = playerHandObject;

        foodList = new List<Food>();
    }
    public void Update()
    {
        if (InputHandler.pressed(act.throws))
            throwFood();
        
        if (Input.mouseScrollDelta.y > 0f)
            nextItem();
        if (Input.mouseScrollDelta.y < 0f)
            prevItem();
    }

    private void nextItem()
    {
        if (foodList.Count == 0)
            return;

        for (int i = 0; i < foodList.Count; i++)
        {
            foodInHandIndex++;

            if (foodInHandIndex >= foodList.Count)
                foodInHandIndex = 0;

            if (foodList[foodInHandIndex] != null)
            {
                foodInHand = foodList[foodInHandIndex];
                return;
            }
        }
        foodInHand = null;
    }
    private void prevItem()
    {
        if (foodList.Count == 0)
            return;

        for (int i = 0; i < foodList.Count; i++)
        {
            foodInHandIndex--;

            if (foodInHandIndex < 0)
                foodInHandIndex = foodList.Count - 1;

            if (foodList[foodInHandIndex] != null)
            {
                foodInHand = foodList[foodInHandIndex];
                return;
            }
        }
        foodInHand = null;
    }



    private void grabFood(Food food)
    {
        if (foodList.Count > maxHoldableFoodAmount)
            return;
        
        food.grab(this, foodInventoryObject, playerHandObject);
        foodList.Add(food);
    }

    private void throwFood()
    {
        if (foodInHand == null)
            return;

        Food foodToThrow = foodInHand;

        if (foodList.Contains(foodInHand))
            foodList.Remove(foodInHand);

        foodToThrow.release();
        nextItem();
    }
}
