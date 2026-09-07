using NUnit.Framework;
using UnityEngine;

public class PlayerMovement
{
    private const float walkSpeedBase = 5;
    private const float gravity = 10;
    private const float mouseSensitivity = 10;


    private CharacterController playerController;
    private Transform playerTransform;
    private bool isRunning = false;

    // Constructor
    public PlayerMovement(CharacterController playerController, Transform playerTransform)
    {
        this.playerController = playerController;
        this.playerTransform = playerTransform;
    }

    public void Update()
    {
        // gravity
        playerController.Move(Vector3.down * gravity * Time.deltaTime);

        // handle walk
        if (InputHandler.pressing(act.walkForward))
            playerController.Move(playerTransform.forward * walkSpeedBase * (isRunning ? 1.75f : 1) * Time.deltaTime);
        if (InputHandler.pressing(act.walkBackward))
            playerController.Move(-1 * playerTransform.forward * walkSpeedBase * (isRunning ? 1.75f : 1) * Time.deltaTime);
        if (InputHandler.pressing(act.walkRight))
            playerController.Move(playerTransform.right * walkSpeedBase * (isRunning ? 1.75f : 1) * Time.deltaTime);
        if (InputHandler.pressing(act.walkLeft))
            playerController.Move(-1 * playerTransform.right * walkSpeedBase * (isRunning ? 1.75f : 1) * Time.deltaTime);

        // check run
        if (InputHandler.pressing(act.run))
            isRunning = true;
        else
            isRunning = false;

        // turning head with mouse
        playerTransform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * mouseSensitivity);
    }
}
