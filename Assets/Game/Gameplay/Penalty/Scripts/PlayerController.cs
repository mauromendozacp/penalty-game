using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInputController inputController;
    [SerializeField] private SwipeController swipeController;

    private void Start()
    {
        inputController.onStartClick = () => swipeController.StartSwipe();
        inputController.onEndClick = () => swipeController.EndSwipe();

        swipeController.onGetMousePosition = () => inputController.GetMousePosition();
    }
}
