using System;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private InputSystemActions inputActions = null;

    public Action onStartClick = null;
    public Action onEndClick = null;

    private void Awake()
    {
        inputActions = new InputSystemActions();

        inputActions.UI.Click.started += ctx => StartClick();
        inputActions.UI.Click.canceled += ctx => EndClick();
    }

    public Vector2 GetMousePosition()
    {
        return inputActions.UI.Point.ReadValue<Vector2>();
    }

    private void StartClick()
    {
        onStartClick?.Invoke();
    }

    private void EndClick()
    {
        onEndClick?.Invoke();
    }
}
