using System;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private static readonly int isWalking = Animator.StringToHash("isWalking");

    protected Animator anim;
    protected Controller controller;
    protected SpriteRenderer renderer;

    private void Awake()
    {
        controller = GameManager.Instance.GetComponent<Controller>();

        anim = GetComponentInChildren<Animator>();
        renderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 vector)
    {
        if (vector == Vector2.zero)
        {
            anim.SetBool(isWalking, false);
        }
        else
        {
            anim.SetBool(isWalking, true);
        }

        if (vector.x == 0) return;
        renderer.flipX = vector.x < 0;
    }

    private void OnDestroy()
    {
        anim = null;
        renderer = null;
        controller.OnMoveEvent -= Move;

    }
}
