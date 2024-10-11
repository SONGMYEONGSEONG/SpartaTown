using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_CharacterSelectButton : MonoBehaviour
{
    public event Action<UI_CharacterSelectButton> EventSelected;

    [SerializeField] public GameObject indicator;
    [SerializeField] public CharacterType Type;

    public void CharacterSelect()
    {
        EventSelected.Invoke(this);
    }
}
