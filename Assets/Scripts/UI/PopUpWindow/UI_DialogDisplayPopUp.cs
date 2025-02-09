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
        GameManager.Instance.DialogIndex = 0;
        DialogDisplayPopUp.SetActive(true);
    }

    private void Update()
    {
        if (GameManager.Instance.CurPlayer.GetComponent<InterAction>().IsInterActing)
        {
            CharacterController target = GameManager.Instance.CurPlayer.GetComponent<InterAction>().TargetInterAction;

            NpcCharacterSO talker = target.characterSO as NpcCharacterSO;

            talkerName.text = target.characterSO.name;

            if (GameManager.Instance.DialogIndex < talker.DialogList.Count)
            {
                talkerDialog.text = talker.DialogList[GameManager.Instance.DialogIndex];
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
