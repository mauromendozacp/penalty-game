using System;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [Header("Swipe Settings")]
    [SerializeField] private float minSwipeDistance = 50f;
    [SerializeField] private float maxSwipeDistance = 300f;
    [SerializeField] private float minForce = 5f;
    [SerializeField] private float maxForce = 30f;
    [SerializeField] private LayerMask ballLayer = default;

    private Vector2 startPos = Vector2.zero;
    private float startTime = 0f;
    private bool isSwiping = false;

    public Func<Vector2> onGetMousePosition = null;

    public void StartSwipe()
    {
        Vector2 screenPos = GetMousePosition();
        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Utils.CheckLayerInMask(ballLayer, hit.collider.gameObject.layer))
            {
                isSwiping = true;
                startPos = GetMousePosition();
                startTime = Time.time;
            }
        }
    }

    public void EndSwipe()
    {
        if (!isSwiping) return;

        isSwiping = false;
        Vector2 endPos = GetMousePosition();
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

    private Vector2 GetMousePosition()
    {
        return onGetMousePosition != null ? onGetMousePosition.Invoke() : Vector2.zero;
    }
}
