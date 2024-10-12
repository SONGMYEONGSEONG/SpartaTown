using System;
using UnityEngine;

public class InterAction : MonoBehaviour
{

    Controller controller;

    private void Awake()
    {
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

}
