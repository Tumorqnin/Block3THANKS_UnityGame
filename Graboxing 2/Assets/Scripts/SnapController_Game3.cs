using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnappingJoint : MonoBehaviour
{
    public Transform snapPoint;
    public List<DraggableJoint> draggableObjects;
    public float snapRange = 1f;
    public static bool IsSnapped = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (DraggableJoint draggable in draggableObjects)
        {
            draggable.dragEndedCallback = OnDragEnded;
        }
    }

    private void OnDragEnded(DraggableJoint draggable)
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
    }
}