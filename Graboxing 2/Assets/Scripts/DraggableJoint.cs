using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableJoint : MonoBehaviour
{
    public delegate void DragEndedDelegate(DraggableJoint draggableObject);
    public DragEndedDelegate dragEndedCallback;

    private bool isDragged = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private Vector3 snapPosition;
    private Vector3 snapPositionStart;

    void Start()
    {
        snapPosition = this.transform.position;
        snapPositionStart = this.transform.position;
    }

    private void OnMouseDown()
    {
        print("penis");
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
    }

    private void OnMouseDrag()
    {
        if (isDragged)
        {
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }

    public void BackToOriginal()
    {
        transform.localPosition = snapPosition;
    }

    private void OnMouseUp()
    {
        isDragged = false;
        dragEndedCallback(this);
    }
}
