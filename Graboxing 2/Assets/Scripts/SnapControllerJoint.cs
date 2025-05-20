using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapControllerJoint : MonoBehaviour
{
    public Transform snapPoint;
    public List<DraggableJoint> draggableObjects;
    public float snapRange = 1f;

    void Start()
    {
        foreach (DraggableJoint draggable in draggableObjects)
        {
            draggable.dragEndedCallback = OnDragEnded;
        }
    }

    private void OnDragEnded(DraggableJoint draggable)
    {
        float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);

        if(currentDistance <= snapRange)
        {
            draggable.transform.localPosition = snapPoint.localPosition;
            draggable.isSnapped = true;
        }
    }
}