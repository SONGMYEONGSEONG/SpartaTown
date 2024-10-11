using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_StartGameButton : MonoBehaviour
{
    private UI_CharacterCreate ui_CharacterCreate;

    public void Awake()
    {
        ui_CharacterCreate = GetComponentInParent<UI_CharacterCreate>();
    }

    public void StartGame()
    {
        DataManager.Instance.UserName = ui_CharacterCreate.InputName.text.ToString();

        SceneManager.LoadScene("MainScene");
    }
}
