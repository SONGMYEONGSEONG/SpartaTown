using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharaterNameDisplay : MonoBehaviour
{
    [SerializeField] private Camera mainCamera; // ���� ��ǥ -> ��ũ�� ��ǥ�� �Ű��ֱ�

    private TextMeshProUGUI textName;
    private RectTransform rectTr;
    private Transform target; //����ÿ��� ����ȭ ����

    private CharacterType curCharacterType;

    public Transform Target { set { target = value; }  }
    private void Awake()
    {
        textName = GetComponentInChildren<TextMeshProUGUI>();
        rectTr = GetComponent<RectTransform>();
    }

    private void Start()
    {
        textName.text = DataManager.Instance.UserName;

        curCharacterType = DataManager.Instance.SelectType;
    }

    public void SetUsername(string username)
    {
        textName.text = username;
    }

    private void FixedUpdate() //Update ����Ѱ�� �̵��� �ڿ������� ���ؼ� Fixed�� ����
    {
        Vector2 pos = new Vector2(target.position.x, target.position.y);

        pos.y += 1.5f;
        //if (curCharacterType == CharacterType.Hero_male) pos.y += 0.5f;

       //Vector3 screentTargetPos = mainCamera.WorldToScreenPoint(target.position);
       Vector3 screentTargetPos = mainCamera.WorldToScreenPoint(pos);

        rectTr.position = screentTargetPos;


    }
}
