using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController characterController;



    PlayerMovement movement;
    PlayerServing serving;
    PlayerCombat combat;

    void Awake()
    {
        characterController = gameObject.GetComponent<CharacterController>();

        movement = new PlayerMovement(characterController, transform);
        serving = new PlayerServing();
        combat = new PlayerCombat();
    }

    void Update()
    {
        movement.Update();
        serving.Update();
        combat.Update();
    }
}