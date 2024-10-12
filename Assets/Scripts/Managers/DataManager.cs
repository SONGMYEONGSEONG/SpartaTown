using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(DataManager).Name + "Auto";
                    instance = obj.AddComponent<DataManager>();
                }
            }

            DontDestroyOnLoad(instance);
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    [SerializeField] private List<GameObject> playableCharacters;
    
    public string UserName { get; set; }
    public CharacterType SelectType { get; set; }

    public GameObject InitCharacter ()
    {
        return playableCharacters[(int)SelectType];
    }

    public GameObject ChangeCharacter(CharacterType type)
    {
        return playableCharacters[(int)type];
    }
}
