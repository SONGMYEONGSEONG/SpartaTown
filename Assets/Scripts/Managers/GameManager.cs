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

    //������ NPC�� ����� �����ϴ� ����Ʈ 
    [SerializeField] public List<CharacterController> Paricipants = new List<CharacterController>();//������ ��ü���� ��Ʈ�ѷ��� List�� ����

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

        //Test: ������ NPC�� �̸� ��� 
        foreach(CharacterController controller in Paricipants)
        {
            Debug.Log(controller.characterSO.name);
        }

        curPlayer = player;
    }
}
