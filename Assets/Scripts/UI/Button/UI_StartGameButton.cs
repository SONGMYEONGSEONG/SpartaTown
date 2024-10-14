using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class UI_StartGameButton : MonoBehaviour
{
    private UI_CharacterCreate ui_CharacterCreate;

    public void Awake()
    {
        ui_CharacterCreate = GetComponentInParent<UI_CharacterCreate>();
    }

    public void StartGame()
    {
        int nameSize = ui_CharacterCreate.InputName.text.Count();

        if (nameSize > 2 && nameSize <= 11)
        {
            DataManager.Instance.UserName = ui_CharacterCreate.InputName.text.ToString();
            SceneManager.LoadScene("MainScene");
        }

    }
}
