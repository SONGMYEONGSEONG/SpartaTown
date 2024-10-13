using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookAimEvent;
    public event Action OnInterActionEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // ?. ������ ���� X , ������ ����
    }

    public void CallInterActionEvent()
    {
        OnInterActionEvent?.Invoke(); // ?. ������ ���� X , ������ ����
    }

    public void CallLookAimEvent(Vector2 mousePos)
    {
        OnLookAimEvent?.Invoke(mousePos); 
    }
}
