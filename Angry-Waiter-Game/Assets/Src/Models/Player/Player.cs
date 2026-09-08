using UnityEngine;

public class Player : MonoBehaviour
{
    private LevelManager levelManager;


    private CharacterController characterController;



    private PlayerMovement movement;
    private PlayerServing serving;
    private PlayerCombat combat;

    void Awake()
    {
        characterController = gameObject.GetComponent<CharacterController>();

        movement = new PlayerMovement(characterController, transform);
        serving = new PlayerServing();
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