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

    //�ڷ�ƾ�� �̿��Ͽ� ������ ����Ʈ�� ��� üũ�ϰ�
    //����ϰ� �Ǵ°� 
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


        //if (participantsListUpdateCoroutine == null)
        //{
        //    participantsListUpdateCoroutine = StartCoroutine(ListUpdateCoroutine());
        //}
        //else
        //{
        //    StopCoroutine(participantsListUpdateCoroutine);
        //    participantsListUpdateCoroutine = StartCoroutine(ListUpdateCoroutine());
        //}
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
