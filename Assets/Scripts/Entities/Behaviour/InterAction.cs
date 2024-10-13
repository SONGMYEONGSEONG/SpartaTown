using System;
using UnityEngine;

public class InterAction : MonoBehaviour
{
    private UI_InterActionPopUp ui_InterActionPopUp;

    Controller controller; //InputController로 변경할것
    public bool IsInteractable { get; set; }
    public bool IsInterActing { get; set; }

    [SerializeField] private LayerMask targetLayerMask;

    private CharacterController targetInterAction;
    public CharacterController TargetInterAction
    {
        get { return targetInterAction; }
    }

    private void Awake()
    {
        if (ui_InterActionPopUp == null)
        {
            ui_InterActionPopUp = FindObjectOfType<UI_InterActionPopUp>();
        }

        IsInteractable = false;
        IsInterActing = false;

        controller = GameManager.Instance.GetComponent<Controller>();
    }

    private void Start()
    {
        controller.OnInterActionEvent += InterActionPopUp;
    }

    private void OnDestroy()
    {
        controller.OnInterActionEvent -= InterActionPopUp;
    }

    private void InterActionPopUp()
    {
        Debug.Log("InterActionPopUpOpen");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsLayerMatched(targetLayerMask, collision.gameObject.layer))
        {
            IsInteractable = true;
            ui_InterActionPopUp.interActionPopUp.gameObject.SetActive(true);
            targetInterAction = collision.GetComponent<CharacterController>();

            if (targetInterAction != null)
            {
                ui_InterActionPopUp.TargetText = targetInterAction.characterSO.name;
            }

            Debug.Log(collision.name + "상호작용 범위 들어옴");

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsLayerMatched(targetLayerMask, collision.gameObject.layer))
        {
            IsInteractable = false;
            IsInterActing = false;

            if (targetInterAction != null)
            {
                targetInterAction = null;
            }

            ui_InterActionPopUp.interActionPopUp.gameObject.SetActive(false);
            Debug.Log(collision.name + "상호작용 범위 벗어남");
        }

    }

    private bool IsLayerMatched(int value, int layer)
    {
        return value == (value | 1 << layer);
    }
}
