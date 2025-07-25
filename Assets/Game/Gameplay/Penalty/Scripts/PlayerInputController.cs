using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private InputSystemActions inputActions = null;

    public Action onStartClick = null;
    public Action onEndClick = null;

    private void Awake()
    {
        inputActions = new InputSystemActions();

        inputActions.UI.Click.started += StartClick;
        inputActions.UI.Click.canceled += EndClick;
    }

    private void OnDestroy()
    {
        if (inputActions == null) return;

        inputActions.UI.Click.started += StartClick;
        inputActions.UI.Click.canceled += EndClick;
    }

    void OnEnable()
    {
        inputActions?.Enable();
    }

    void OnDisable()
    {
        inputActions?.Disable();
    }

    public Vector2 GetMousePosition()
    {
        return inputActions.UI.Point.ReadValue<Vector2>();
    }

    private void StartClick(InputAction.CallbackContext ctx)
    {
        onStartClick?.Invoke();
    }

    private void EndClick(InputAction.CallbackContext ctx)
    {
        onEndClick?.Invoke();
    }
}
