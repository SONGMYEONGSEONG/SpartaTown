using UnityEngine;

public class LookAim : MonoBehaviour
{
    SpriteRenderer renderer;
    InputController inputController;
    PlayerController playerController;

    Vector2 aimPos = Vector2.zero;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        inputController = GameManager.Instance.GetComponent<InputController>();

        renderer = playerController.GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        inputController.OnLookAimEvent += LookAt;
    }

    private void OnDestroy()
    {
        inputController.OnLookAimEvent -= LookAt;
    }

    private void LookAt(Vector2 mousePos)
    {
        aimPos = mousePos;
    }

    private void FixedUpdate()
    {
        ApplyLookAim(aimPos);
    }

    private void ApplyLookAim(Vector2 aimPos)
    {
        //

        float rotZ = Mathf.Atan2(aimPos.y, aimPos.x) * Mathf.Rad2Deg;
        //float rotZ = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;

        renderer.flipX = Mathf.Abs(rotZ) > 90.0f;

    }
}
