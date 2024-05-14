using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : TopDownController
{
    private Camera _camera;

    private void Awake() 
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>().normalized;
        Debug.Log(input);
        CallMoveEvent(input);
    }

    public void OnLook(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(input);
        input = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(input);
    }
}