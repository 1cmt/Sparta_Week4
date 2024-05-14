using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        Debug.Log("callMove"); //call이 출력되는건 확인... 근데 왜 안움직..?
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        Debug.Log("callLook"); 
        OnLookEvent?.Invoke(direction);
    }
}
