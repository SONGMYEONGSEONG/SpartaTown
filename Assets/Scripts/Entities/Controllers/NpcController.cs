using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : CharacterController
{
    private UI_DialogDisplayPopUp ui_dialogDisplayPopUp;

    private void Awake()
    {
        if (ui_dialogDisplayPopUp == null)
        {
            ui_dialogDisplayPopUp = FindObjectOfType<UI_DialogDisplayPopUp>();
        }
    }

    private void Start()
    {
        GameManager.Instance.PlayerInput.OnEventInterActionStart += TalkStart;
        GameManager.Instance.PlayerInput.OnEventInterActionEnd += TalkEnd;
    }

    private void TalkStart()
    {
        ui_dialogDisplayPopUp.OnDialogDisplay();
    }
    private void TalkEnd()
    {
        ui_dialogDisplayPopUp.OffDialogDisplay();
    }
    //private void OnDisable()
    //{
    //    GameManager.Instance.PlayerInput.OnEventInterActionStart -= TalkStart;
    //    GameManager.Instance.PlayerInput.OnEventInterActionEnd -= TalkEnd;
    //}


}
