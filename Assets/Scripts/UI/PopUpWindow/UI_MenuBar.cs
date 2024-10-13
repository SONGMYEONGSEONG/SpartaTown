using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MenuBar: MonoBehaviour
{
    [SerializeField] private GameObject menuBox;

    private void Update()
    {
        menuBox.SetActive(GameManager.Instance.UI_MenuBar);
    }

}