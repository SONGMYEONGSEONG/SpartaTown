using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_CharacterCreateStartButton : MonoBehaviour
{
    [SerializeField] private GameObject characterCreate;

    public void CharacterCreateStart()
    {
        characterCreate.SetActive(true);
        gameObject.SetActive(false);
    }
}
