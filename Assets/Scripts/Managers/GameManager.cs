using System.Collections;
using System.Collections.Generic;
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

    //참여한 NPC들 목록을 보관하는 리스트 
    [SerializeField] public List<CharacterController> Paricipants = new List<CharacterController>();//참석한 객체들의 컨트롤러를 List로 관리

    [SerializeField] private CinemachineVirtualCamera cinemachine;
    [SerializeField] private UI_CharaterNameDisplay CharacterNameDisplayTarget;
    public InputController PlayerInput { get; private set; }
    private GameObject curPlayer;
    public GameObject CurPlayer { get { return curPlayer; } set { curPlayer = value; } }

    public int DialogIndex { get; set; }
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

        //Test: 참여한 NPC들 이름 출력 
        foreach(CharacterController controller in Paricipants)
        {
            Debug.Log(controller.characterSO.name);
        }

        curPlayer = player;
    }
}
