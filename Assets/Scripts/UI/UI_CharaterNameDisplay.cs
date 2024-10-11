using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharaterNameDisplay : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Camera mainCamera; // ���� ��ǥ -> ��ũ�� ��ǥ�� �Ű��ֱ�

    private TextMeshProUGUI textName;
    private RectTransform rectTr;

    private void Awake()
    {
        textName = GetComponentInChildren<TextMeshProUGUI>();
        rectTr = GetComponent<RectTransform>();
    }

    private void Start()
    {
        //Test
        textName.text = "�� - ��";
    }

    private void FixedUpdate() //Update ����Ѱ�� �̵��� �ڿ������� ���ؼ� Fixed�� ����
    {
       Vector3 screentTargetPos = mainCamera.WorldToScreenPoint(target.position);

        rectTr.position = screentTargetPos;


    }
}
