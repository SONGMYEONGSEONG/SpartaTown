using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_DialogDisplayPopUp : MonoBehaviour
{
    [SerializeField] public GameObject DialogDisplayPopUp;

    [SerializeField] private TextMeshProUGUI talkerName;
    [SerializeField] private TextMeshProUGUI talkerDialog;

    public void OnDialogDisplay()
    {
        DialogDisplayPopUp.SetActive(true);
    }

    private void Update()
    {
        if (GameManager.Instance.CurPlayer.GetComponent<InterAction>().IsInterActing)
        {
            CharacterController target = GameManager.Instance.CurPlayer.GetComponent<InterAction>().TargetInterAction;

            NpcCharacterSO talker = target.characterSO as NpcCharacterSO;

            talkerName.text = target.characterSO.name;

            foreach (string str in talker.DialogList)
            {
                talkerDialog.text = str;
            }
        }
        else
        {
            OffDialogDisplay();
        }
    }

    public void OffDialogDisplay()
    {
        DialogDisplayPopUp.SetActive(false);
    }


}
