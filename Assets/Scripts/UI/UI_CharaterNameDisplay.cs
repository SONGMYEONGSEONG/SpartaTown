using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharaterNameDisplay : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Camera mainCamera; // 월드 좌표 -> 스크린 좌표로 옮겨주기

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
        textName.text = "펭 - 귄";
    }

    private void FixedUpdate() //Update 사용한경우 이동이 자연스럽지 못해서 Fixed로 변경
    {
       Vector3 screentTargetPos = mainCamera.WorldToScreenPoint(target.position);

        rectTr.position = screentTargetPos;


    }
}
