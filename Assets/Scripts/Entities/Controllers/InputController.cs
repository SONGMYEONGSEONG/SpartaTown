using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : Controller
{
    private PlayerInput playerInput;
    private InputActionAsset inputActions;
    private InputActionMap playerActionMap;

    [SerializeField] private RectTransform UI_MenuBarOpen;

    protected  void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        inputActions = playerInput.actions;

        playerActionMap = inputActions.FindActionMap("Player");

        InputAction movementAction = playerActionMap.FindAction("Move");
        movementAction.performed += OnMovementPerformed;
        movementAction.canceled += OnMovementCancled;

        InputAction MenuBarOpen = playerActionMap.FindAction("MenuBarOpen");
        MenuBarOpen.performed += OnMenuBarOpenPerformed;

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

    private void OnMenuBarOpenPerformed(InputAction.CallbackContext context)
    {
        GameManager.Instance.UI_MenuBar = !GameManager.Instance.UI_MenuBar;
    }
}
