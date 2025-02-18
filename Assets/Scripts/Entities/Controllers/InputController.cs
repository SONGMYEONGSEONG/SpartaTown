using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : Controller
{
    public event Action OnEventInterActionStart;
    public event Action OnEventInterActionEnd;

    private PlayerInput playerInput;
    private InputActionAsset inputActions;
    private InputActionMap playerActionMap;

    protected void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        inputActions = playerInput.actions;

        playerActionMap = inputActions.FindActionMap("Player");

        InputAction movementAction = playerActionMap.FindAction("Move");
        movementAction.performed += OnMovementPerformed;
        movementAction.canceled += OnMovementCancled;

        InputAction lookAtMouse = playerActionMap.FindAction("LookAim");
        lookAtMouse.performed += OnLookAtMousePerformed;

        InputAction MenuBarOpen = playerActionMap.FindAction("MenuBarOpen");
        MenuBarOpen.performed += OnMenuBarOpenPerformed;

        InputAction InterAction = playerActionMap.FindAction("InterAction");
        InterAction.performed += OnInterActionPerformed;

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

    private void OnLookAtMousePerformed(InputAction.CallbackContext context)
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());

        Vector2 dir = (mousePos - (Vector2)GameManager.Instance.CurPlayer.transform.position).normalized;

        CallLookAimEvent(dir);
    }

    private void OnMenuBarOpenPerformed(InputAction.CallbackContext context)
    {
        GameManager.Instance.UI_MenuBar = !GameManager.Instance.UI_MenuBar;
    }

    private void OnInterActionPerformed(InputAction.CallbackContext context)
    {
        InterAction curPlayerInterAction = GameManager.Instance.CurPlayer.GetComponent<InterAction>();

        if (curPlayerInterAction.IsInteractable && !curPlayerInterAction.IsInterActing)
        {
            Debug.Log("상호작용 키 눌림 - 대화 창 열림");

            if (curPlayerInterAction.TargetInterAction != null)
            {
                curPlayerInterAction.IsInterActing = true;
                OnEventInterActionStart?.Invoke();
            }
        }
        else if (curPlayerInterAction.IsInteractable && curPlayerInterAction.IsInterActing)
        {
            NpcCharacterSO npcCharacterSO = curPlayerInterAction.TargetInterAction.characterSO as NpcCharacterSO;

            if (GameManager.Instance.DialogIndex < npcCharacterSO.DialogList.Count - 1)
            {
                Debug.Log("상호작용 키 눌림 - 다음 대화 진행");
                GameManager.Instance.DialogIndex++;
            }
            else
            {
                Debug.Log("상호작용 키 눌림 - 대화 창 끄기");
                OnEventInterActionEnd?.Invoke();
                curPlayerInterAction.IsInterActing = false;
            }
        }

    }
}
