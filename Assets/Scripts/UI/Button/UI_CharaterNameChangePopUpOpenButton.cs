using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CharaterNameChangePopUpOpenButton : MonoBehaviour
{
    [SerializeField] private GameObject ui_CharacterNameChange;

    public void OnCharaterNamePopUp()
    {
        ui_CharacterNameChange.gameObject.SetActive(true);
    }
}
