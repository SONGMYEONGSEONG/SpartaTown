using System;
using UnityEngine;

public class InterAction : MonoBehaviour
{
    Controller controller;

    public bool IsInteractable { get; set; }
    public bool IsInterActing { get; set; }
    

    private void Awake()
    {
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
        IsInteractable = true;
        Debug.Log(collision.name + "상호작용 범위 들어옴");    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsInteractable = false;
        Debug.Log(collision.name + "상호작용 범위 벗어남");
    }
}
