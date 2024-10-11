using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CharacterChangeButton : MonoBehaviour
{
    [SerializeField] private GameObject UI_CharacterChangePopUp;

    public void OnChangeCharacter()
    {

        Vector2 curPlayerPos = GameManager.Instance.CurPlayer.transform.position;

        GameObject newCharacter = Instantiate(DataManager.Instance.ChangeCharacter(DataManager.Instance.SelectType), curPlayerPos,Quaternion.identity);
        GameManager.Instance.Initialize(newCharacter);

        UI_CharacterChangePopUp.SetActive(false);
    }
}
