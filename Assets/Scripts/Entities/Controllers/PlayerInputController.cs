using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : Controller
{
    private PlayerInput playerInput;
    private InputActionAsset inputActions;

    private InputActionMap playerActionMap;

    protected  void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        inputActions = playerInput.actions;

        playerActionMap = inputActions.FindActionMap("Player");

        InputAction movementAction = playerActionMap.FindAction("Move");
        movementAction.performed += OnMovementPerformed;
        movementAction.canceled += OnMovementCancled;
    }

    public void OnPlayerInputActionMap()
    {
        playerActionMap.Enable();
    }
    public void OffPlayerInputActionMap()
    {
        playerActionMap.Disable();
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        CallMoveEvent(direction);
    }

    private void OnMovementCancled(InputAction.CallbackContext context)
    {
        Vector2 direction = Vector2.zero;
        CallMoveEvent(direction);
    }
}
