using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;

public class UI_InterActionPopUp : MonoBehaviour
{
    public event Action OnEventInterActionPopUp;

    [SerializeField] private TextMeshProUGUI targetName;
    [SerializeField] public GameObject interActionPopUp;
    public string TargetText { set { targetName.text = value; } }

}
