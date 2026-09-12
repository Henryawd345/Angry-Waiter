using UnityEngine;

public class Food : MonoBehaviour
{
    private const float foodHeatDuration = 15f;


    private Rigidbody foodRigid;
    private GameObject foodInventoryObject;
    private GameObject playerHandObject;
    private PlayerServing playerServing;


    public FoodType foodType {get; private set;}
    private bool isHighLight;
    private bool isGrabbed;

    private float foodHeat;

    void Awake()
    {
        foodRigid = gameObject.GetComponent<Rigidbody>();
    }
    public void initialize(FoodType foodType)
    {
        this.foodType = foodType;
        foodHeat = foodHeatDuration; // food will not spoil until 15 seconds
        // call food renderer
    }


    public void grab(PlayerServing playerServing, GameObject foodInventoryObject, GameObject playerHandObject)
    {
        this.playerServing = playerServing;
        this.foodInventoryObject = foodInventoryObject;
        this.playerHandObject = playerHandObject;

        transform.parent = foodInventoryObject.transform;
        transform.position = foodInventoryObject.transform.position;
        gameObject.SetActive(false);
    }
    public void release()
    {
        if (!gameObject.activeInHierarchy)
            gameObject.SetActive(true);

        transform.parent = null;
        foodInventoryObject = null;
    }
    public void inHand()
    {
        gameObject.SetActive(true);

        transform.parent = playerHandObject.transform;
        transform.position = playerHandObject.transform.position;
    }
    public void offHand()
    {
        gameObject.SetActive(false);

        transform.parent = foodInventoryObject.transform;
        transform.position = foodInventoryObject.transform.position;
    }
    public void highLightFood()
    {
        // will debug later
        if (true) isHighLight = true;
        // else isHighLight = false;
    }
}
