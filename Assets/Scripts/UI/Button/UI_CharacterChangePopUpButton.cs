using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CharacterChangePopUpButton : MonoBehaviour
{
    [SerializeField] private GameObject UI_CharacterChangePopUp;

    public void OnCharacterChangePopUp()
    {
        UI_CharacterChangePopUp.SetActive(true);
    }
}
