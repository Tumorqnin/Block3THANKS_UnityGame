using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnappingLense : MonoBehaviour
{
    public Transform snapPoint;
    public List<DraggableLense> draggableObjects;
    public float snapRange = 1.5f;
    public static bool IsSnapped = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (DraggableLense draggable in draggableObjects)
        {
            draggable.dragEndedCallback = OnDragEnded;
        }
    }

    private void OnDragEnded(DraggableLense draggable)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
        if (closestSnapPoint == null || currentDistance < closestDistance)
        {
            closestSnapPoint = snapPoint;
            closestDistance = currentDistance;
        }

        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            draggable.transform.localPosition = closestSnapPoint.localPosition;
            IsSnapped = true;
        }
        else 
        {
            draggable.BackToOriginal();
        }
    }
}