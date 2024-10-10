using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rigid;
    Controller controller;

    private Vector2 direction = Vector2.zero;

    private void Awake()
    {
        controller = GameManager.Instance.GetComponent<Controller>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
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
        //5 = �����ѹ� , �����ؾߵ�
        rigid.velocity = direction * 5f;
    }
}
