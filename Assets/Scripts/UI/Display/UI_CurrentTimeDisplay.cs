using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UI_CurrentTimeDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textTime;

    private void Update()
    {
        textTime.text = DateTime.Now.ToString("HH:mm");
    }
}
