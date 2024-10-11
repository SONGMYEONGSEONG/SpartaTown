using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_CharaterNameChangeButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputChangeName;
    [SerializeField] private UI_CharaterNameDisplay charaterNameDisPlay;
    [SerializeField] private GameObject UI_CharaterNameChangePopUp;
    public void OnChangeName()
    {
        DataManager.Instance.UserName = inputChangeName.text;
        charaterNameDisPlay.SetUsername(inputChangeName.text);
        UI_CharaterNameChangePopUp.SetActive(false);
    }
}
