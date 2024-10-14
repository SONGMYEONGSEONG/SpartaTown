using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class UI_ParticipantsListDisplay : MonoBehaviour
{
    [SerializeField] private GameObject prefeb;
    [SerializeField] private GameObject participantsListParents;

    private List<GameObject> participantsList;
    string userName;

    //코루틴을 이용하여 참여자 리스트를 계속 체크하고
    //출력하게 되는건 
    private void OnEnable()
    {
        participantsList = new List<GameObject>();

        GameObject obj = Instantiate(prefeb, participantsListParents.transform);
        obj.GetComponent<TextMeshProUGUI>().text = DataManager.Instance.UserName;

        participantsList.Add(obj);

        foreach (CharacterController character in GameManager.Instance.Paricipants)
        {
            obj = Instantiate(prefeb, participantsListParents.transform);
            obj.GetComponent<TextMeshProUGUI>().text = character.characterSO.name;
            participantsList.Add(obj);
        }

    }

    private void Update()
    {
        if(userName != DataManager.Instance.UserName)
        {
            participantsList[0].GetComponent<TextMeshProUGUI>().text = DataManager.Instance.UserName;
        }
    }

    private void OnDisable()
    {
        foreach (GameObject displayName in participantsList)
        {
            Destroy(displayName);
        }
    }

    IEnumerator ListUpdateCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
        }



    }



}
