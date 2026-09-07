using UnityEngine;

public class Food : MonoBehaviour
{
    public FoodType foodType {get; private set;}
    private bool isHighLight;
    private bool isGrabbed;

    int foodHeat;

    public void initialize(FoodType foodType)
    {
        this.foodType = foodType;
        foodHeat = 15; // food will not spoil until 15 seconds
        // call food renderer
    }


    public void grab(Transform playerTransform, bool grabOrRelease)
    {
        if (grabOrRelease) // grab
            transform.parent = playerTransform;
        else if (!grabOrRelease) // release
            transform.parent = null;
    }
    public void highLightFood()
    {
        // will debug later
        if (true) isHighLight = true;
        else isHighLight = false;
    }
}
