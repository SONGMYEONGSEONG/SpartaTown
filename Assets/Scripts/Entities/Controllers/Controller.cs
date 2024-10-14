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
        OnMoveEvent?.Invoke(direction); // ?. 없으면 실행 X , 있으면 실행
    }

    public void CallInterActionEvent()
    {
        OnInterActionEvent?.Invoke(); // ?. 없으면 실행 X , 있으면 실행
    }

    public void CallLookAimEvent(Vector2 mousePos)
    {
        OnLookAimEvent?.Invoke(mousePos); 
    }
}
