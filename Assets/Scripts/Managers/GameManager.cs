
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public GameObject CurPlayer { get { return curPlayer; } set { curPlayer = value; } }

    public bool DeubgMode; //TitleScene을 사용 안할때 키고 하면됨
    public bool UI_MenuBar = false;

    private void Start()
    {
        PlayerInput = gameObject.GetComponent<InputController>();
        PlayerInput.OnPlayerInputActionMap();

        GameObject player = Instantiate(DataManager.Instance.InitCharacter());
        Initialize(player);     
    }


    public void Initialize(GameObject player)
    {
        if(curPlayer != null)
        {
            Destroy(curPlayer.gameObject);
        }

        CharacterNameDisplayTarget.Target = player.transform;
        cinemachine.Follow = player.transform;

        curPlayer = player;
    }
}
