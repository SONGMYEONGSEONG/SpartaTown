
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(GameManager).Name + "Auto";
                    instance = obj.AddComponent<GameManager>();
                }
            }

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
        }
    }


    [SerializeField] private CinemachineVirtualCamera cinemachine;
    [SerializeField] private UI_CharaterNameDisplay CharacterNameDisplayTarget;
    public InputController PlayerInput { get; private set; }
    private GameObject curPlayer;
    public GameObject CurPlayer { get { return curPlayer; } }

    private void Start()
    {
        PlayerInput = gameObject.GetComponent<InputController>();
        PlayerInput.OnPlayerInputActionMap();

        Initialize();
    }


    public void Initialize()
    {
        GameObject player = Instantiate(DataManager.Instance.InitCharacter());
        CharacterNameDisplayTarget.Target = player.transform;
        cinemachine.Follow = player.transform;

        curPlayer = player;
    }
}
