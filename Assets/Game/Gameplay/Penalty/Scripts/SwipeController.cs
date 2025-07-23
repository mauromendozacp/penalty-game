using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [Header("Swipe Settings")]
    [SerializeField] private float minSwipeDistance = 50f;
    [SerializeField] private float maxSwipeDistance = 300f;
    [SerializeField] private float minForce = 5f;
    [SerializeField] private float maxForce = 30f;

    private Vector2 startPos;
    private float startTime;
    private bool isSwiping = false;

    private PlayerInputController inputController;

    public void Init(PlayerInputController inputController)
    {
        this.inputController = inputController;
        this.inputController.onStartClick = () => StartSwipe();
        this.inputController.onEndClick = () => EndSwipe();
    }

    private void StartSwipe()
    {
        isSwiping = true;
        startPos = inputController.GetMousePosition();
        startTime = Time.time;
    }

    private void EndSwipe()
    {
        if (!isSwiping) return;

        isSwiping = false;
        Vector2 endPos = inputController.GetMousePosition();
        float swipeDistance = endPos.y - startPos.y;
        float swipeTime = Time.time - startTime;

        if (swipeDistance > minSwipeDistance)
        {
            float clamped = Mathf.Clamp(swipeDistance, minSwipeDistance, maxSwipeDistance);
            float normalized = (clamped - minSwipeDistance) / (maxSwipeDistance - minSwipeDistance);
            float force = Mathf.Lerp(minForce, maxForce, normalized);

            Debug.Log($"[Input System] Swipe Force: {force} | Distancia: {swipeDistance} | Tiempo: {swipeTime}");
        }
    }
}
