using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ParticipantsListPopUpCloseButton : MonoBehaviour
{
    [SerializeField] private GameObject UI_ParticipantsListPopUp;
    public void OnParticipantsListPopUp()
    {
        UI_ParticipantsListPopUp.SetActive(false);
    }
}

