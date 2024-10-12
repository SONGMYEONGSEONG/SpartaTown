using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 5.0f;
    Rigidbody2D rigid;
    InputController inputController;
    PlayerController playerController;

    private Vector2 direction = Vector2.zero;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        inputController = GameManager.Instance.GetComponent<InputController>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        speed = playerController.characterSO.speed;

        inputController.OnMoveEvent += Move;
    }

    private void OnDestroy()
    {
        inputController.OnMoveEvent -= Move;
    }

    private void Move(Vector2 direction)
    {
        this.direction = direction;
    }

    private void FixedUpdate()
    {
        ApplyMovement(direction);
    }

    private void ApplyMovement(Vector2 direction)
    {
        //5 = 매직넘버 , 수정해야됨
        rigid.velocity = direction * speed;
    }
}
