using System.Collections.Generic;
using UnityEngine;

public class GoodCustomer : MonoBehaviour
{
    private const float patienceTimerInit = 35f;
    public GameObject orderPrefabObject;


    private float patienceTimer;
    private GameObject foodOrderObject;
    private FoodOrder foodOrder;

    public void initialize()
    {
        patienceTimer = patienceTimerInit;

        foodOrderObject = GameObject.Instantiate(orderPrefabObject);
        foodOrder = foodOrderObject.GetComponent<FoodOrder>();

        // test with new food category list (For debug purpose only)
        List<FoodCategory> foodCategoryList = new List<FoodCategory>();
        foodCategoryList.Add(FoodCategory.Drink);
        foodOrder.initialize( Random.Range(0,5) , foodCategoryList );
    }

    void Update()
    {
        
    }
}
