using System.Collections.Generic;
using UnityEngine;

public class UISnapController : MonoBehaviour
{
    public List<RectTransform> snapPoints;
    public List<UIDraggable> draggableObjects;
    public float snapRange = 50f;

    private Dictionary<RectTransform, UIDraggable> snapOccupancy = new Dictionary<RectTransform, UIDraggable>();
    private Dictionary<UIDraggable, RectTransform> currentSnaps = new Dictionary<UIDraggable, RectTransform>();

    void Start()
    {
        foreach (var draggable in draggableObjects)
        {
            draggable.dragEndedCallback = OnDragEnded;
        }
    }

    private void OnDragEnded(UIDraggable draggable)
    {
        RectTransform draggableRect = draggable.GetComponent<RectTransform>();
        Vector2 draggablePosition = draggableRect.anchoredPosition;

        // Free previous snap, if any
        if (currentSnaps.ContainsKey(draggable))
        {
            RectTransform oldSnapPoint = currentSnaps[draggable];
            snapOccupancy.Remove(oldSnapPoint);
            currentSnaps.Remove(draggable);
        }

        float closestDistance = float.MaxValue;
        RectTransform closestSnapPoint = null;

        foreach (var snapPoint in snapPoints)
        {
            if (snapOccupancy.ContainsKey(snapPoint))
                continue; // Skip if already occupied

            float distance = Vector2.Distance(draggablePosition, snapPoint.anchoredPosition);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestSnapPoint = snapPoint;
            }
        }

        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            draggableRect.anchoredPosition = closestSnapPoint.anchoredPosition;
            snapOccupancy[closestSnapPoint] = draggable;
            currentSnaps[draggable] = closestSnapPoint;
        }
        else
        {
            draggable.BackToOriginal();
        }
    }
}