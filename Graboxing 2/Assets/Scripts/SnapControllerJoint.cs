using System.Collections.Generic;
using UnityEngine;

public class SnapControllerJoint : MonoBehaviour
{
    public Transform snapPoint;
    public List<DraggableJoint> draggableObjects;
    public float snapRange = 1f;

    private int snappedCount = 0;
    public int SnappedCount => snappedCount;

    private SnapManager manager;

    void Start()
    {
        manager = FindFirstObjectByType<SnapManager>();

        foreach (DraggableJoint draggable in draggableObjects)
        {
            draggable.dragEndedCallback = OnDragEnded;
        }
    }

    private void OnDragEnded(DraggableJoint draggable)
    {
        if (draggable.isSnapped) return;

        float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);

        if (currentDistance <= snapRange)
        {
            draggable.transform.localPosition = snapPoint.localPosition;
            draggable.isSnapped = true;
            snappedCount++;
            manager.CheckConditions();
        }
    }
}
