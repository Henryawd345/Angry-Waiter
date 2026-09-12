using UnityEngine;

public class Player : MonoBehaviour
{
    private LevelManager levelManager;


    private CharacterController characterController;

    private GameObject foodInventory;
    private GameObject playerHand;



    private PlayerMovement movement;
    private PlayerServing serving;
    private PlayerCombat combat;

    void Awake()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        foodInventory = transform.Find("FoodInventory").transform.gameObject;
        playerHand = transform.Find("Hand").transform.gameObject;

        movement = new PlayerMovement(characterController, transform);
        serving = new PlayerServing(foodInventory, playerHand);
        combat = new PlayerCombat();
    }
    void Start()
    {
        levelManager = LevelManager.instance;
    }

    void Update()
    {
        if (levelManager.isPaused)
            return;

        movement.Update();
        serving.Update();
        combat.Update();
    }
}