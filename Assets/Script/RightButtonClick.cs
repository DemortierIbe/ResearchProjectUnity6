using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RightButtonClick : MonoBehaviour
{
    public InputActionReference moveRightAction; // Reference to the input action for moving right
    public Transform player; // Reference to the player's Transform
    public float moveSpeed = 2.0f; // Speed of movement
    private Vector3 targetPosition; // The target position for the player
    private bool isMoving = false; // To track if the player is currently moving

    // Limits for movement
    private float minX = -1.8f;
    private float maxX = 1.8f;

    private void Awake()
    {
        moveRightAction.action.Enable();
        moveRightAction.action.performed += MoveRight;
        InputSystem.onDeviceChange += OnDeviceChange;

        // Initialize the target position to the player's current position
        if (player != null)
        {
            targetPosition = player.position;
        }
    }

    private void OnDestroy()
    {
        moveRightAction.action.Disable();
        moveRightAction.action.performed -= MoveRight;
        InputSystem.onDeviceChange -= OnDeviceChange;
    }

    private void Update()
    {
        // If the player is moving, interpolate their position towards the target
        if (isMoving && player != null)
        {
            player.position = Vector3.MoveTowards(player.position, targetPosition, moveSpeed * Time.deltaTime);

            // Check if the player has reached the target position
            if (Vector3.Distance(player.position, targetPosition) < 0.01f)
            {
                isMoving = false; // Stop moving
            }
        }
    }

    private void MoveRight(InputAction.CallbackContext context)
    {
        Debug.Log("MoveRight Button Pressed");

        if (player != null)
        {
            // Calculate the new position
            float newX = Mathf.Clamp(player.position.x + 1.8f, minX, maxX);

            // Set the target position to the new clamped position
            targetPosition = new Vector3(newX, player.position.y, player.position.z);

            // Start moving
            isMoving = true;
        }
    }

    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        switch (change)
        {
            case InputDeviceChange.Disconnected:
                moveRightAction.action.Disable();
                moveRightAction.action.performed -= MoveRight;
                break;
            case InputDeviceChange.Reconnected:
                moveRightAction.action.Enable();
                moveRightAction.action.performed += MoveRight;
                break;
        }
    }
}
