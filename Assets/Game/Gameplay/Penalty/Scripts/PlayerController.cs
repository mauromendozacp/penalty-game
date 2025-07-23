using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInputController inputController;
    [SerializeField] private SwipeController swipeInputSystem;

    private void Start()
    {
        swipeInputSystem.Init(inputController);
    }
}
