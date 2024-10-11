using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterCreate: MonoBehaviour
{
    [SerializeField] private List<GameObject> characterSprites;
    [SerializeField] private List<UI_CharacterSelectButton> selectButtons;
    [SerializeField] private TextMeshProUGUI inputName;
    
    public TextMeshProUGUI InputName { get { return inputName; }  }
    public GameObject curCharacterSprite { get; private set; }
    public void CheckSelectCharater(UI_CharacterSelectButton selected)
    {
        foreach (UI_CharacterSelectButton selectButton in selectButtons)
        {
            if (selectButton == selected)
            {
                DataManager.Instance.SelectType = selected.Type;
                selectButton.indicator.SetActive(true);
            }
            else
            {
                selectButton.indicator.SetActive(false);
            }
            
        }
    }

    public void Awake()
    {
        foreach (GameObject character in characterSprites)
        {
            character.SetActive(true); 
        }

        foreach (UI_CharacterSelectButton selectButtoned in selectButtons)
        {
            selectButtoned.EventSelected += CheckSelectCharater;
        }
    }

    public void OnDestroy()
    {
        foreach (UI_CharacterSelectButton selectButtoned in selectButtons)
        {
            selectButtoned.EventSelected -= CheckSelectCharater;
        }
    }

}