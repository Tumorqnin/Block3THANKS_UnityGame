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

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                isDragged = true;
                mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                spriteDragStartPosition = transform.localPosition;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                if (isDragged)
                {
                    transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
                }
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                isDragged = false;
                dragEndedCallback(this);
            }
        }
    }

    /*public void BackToOriginal()
    {
        transform.localPosition = snapPosition;
    }*/
}
