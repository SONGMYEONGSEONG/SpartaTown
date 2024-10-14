using System;
using TMPro;
using UnityEngine;

public class UI_InterActionPopUp : MonoBehaviour
{
    public event Action OnEventInterActionPopUp;

    [SerializeField] private TextMeshProUGUI targetName;
    [SerializeField] public GameObject interActionPopUp;
    public string TargetText { set { targetName.text = value; } }


}
