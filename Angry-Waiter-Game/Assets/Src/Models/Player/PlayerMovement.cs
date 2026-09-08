using NUnit.Framework;
using UnityEngine;

public class PlayerMovement
{
    private const float walkSpeedBase = 8;
    private const float strafeSpeedBase = 6.5f;
    private const float backwardSpeedBase = 3;
    private const float runMiltiplier = 1.3f;
    private const float gravity = 10;
    private const float mouseSensitivity = 7;
    private const float maxLookAngleUp = 60f;
    private const float maxLookAngleDown = 45f;
    private Vector3 cameraOriginalLocalPosition;


    private CharacterController playerController;
    private Transform playerTransform;
    private Transform cameraHolderTransform;


    private bool isRunning;
    private float speed;
    private float cameraPitch;
    private float bobTimer;

    // Constructor
    public PlayerMovement(CharacterController playerController, Transform playerTransform)
    {
        this.playerController = playerController;
        this.playerTransform = playerTransform;
        cameraHolderTransform = playerTransform.Find("CameraHolder").gameObject.transform;

        isRunning = false;
        cameraPitch = 0;
        bobTimer = 0;
        speed = 0;

        cameraOriginalLocalPosition = cameraHolderTransform.localPosition;
    }

    public void Update()
    {
        playerController.Move(Vector3.down * gravity * Time.deltaTime);

        handleMovement();
        handleCamera();

        if (InputHandler.pressing(act.run))
            isRunning = true;
        else
            isRunning = false;

        // turning head with mouse
        playerTransform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * mouseSensitivity);
    }
    private void handleMovement()
    {
        Vector3 movement = Vector3.zero;

        if (InputHandler.pressing(act.walkForward))
            movement += playerTransform.forward;
        if (InputHandler.pressing(act.walkBackward))
            movement -= playerTransform.forward;
        if (InputHandler.pressing(act.walkRight))
            movement += playerTransform.right;
        if (InputHandler.pressing(act.walkLeft))
            movement -= playerTransform.right;

        bool movingForward =
            InputHandler.pressing(act.walkForward) &&
            !InputHandler.pressing(act.walkBackward) &&
            !InputHandler.pressing(act.walkLeft) &&
            !InputHandler.pressing(act.walkRight);

        isRunning = InputHandler.pressing(act.run) && movingForward;

        if (movement != Vector3.zero)
        {
            movement.Normalize();

            if (movingForward)
                speed = walkSpeedBase;
            else if ( !InputHandler.pressing(act.walkBackward) && (InputHandler.pressing(act.walkLeft) || InputHandler.pressing(act.walkRight)))
                speed = strafeSpeedBase;
            else if (InputHandler.pressing(act.walkBackward))
                speed = backwardSpeedBase;

            if (isRunning)
                speed *= runMiltiplier;

            playerController.Move(movement * speed * Time.deltaTime);
        }
        else
        {
            speed = 0;
        }
    }
    private void handleCamera()
    {
        // pitch look
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 0.6f;

        cameraPitch -= mouseY;

        cameraPitch = Mathf.Clamp(
            cameraPitch,
            -maxLookAngleDown,
            maxLookAngleUp
        );

        cameraHolderTransform.localRotation =
            Quaternion.Euler(cameraPitch, 0f, 0f);

        // bobbing
        if (speed >= 1f)
        {
            // Bob faster depending on movement speed
            float bobFrequency = speed * 1.5f;

            bobTimer += Time.deltaTime * bobFrequency;

            float bobOffset = Mathf.Sin(bobTimer) * 0.075f;

            cameraHolderTransform.localPosition =
                cameraOriginalLocalPosition +
                new Vector3(0f, bobOffset, 0f);
        }
        else
        {
            // Smoothly return camera to original position
            cameraHolderTransform.localPosition = Vector3.Lerp(
                cameraHolderTransform.localPosition,
                cameraOriginalLocalPosition,
                Time.deltaTime * 10f
            );
        }
    }
}
