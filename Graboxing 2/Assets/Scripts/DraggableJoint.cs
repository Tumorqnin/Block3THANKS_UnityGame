using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableJoint : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public delegate void DragEndedDelegate(DraggableJoint draggableObject);
    public DragEndedDelegate dragEndedCallback;

    private RectTransform rectTransform;
    private Vector2 pointerOffset;
    private bool isDragged = false;
    public bool isSnapped = false;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isSnapped) return;

        isDragged = true;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform, eventData.position, eventData.pressEventCamera, out pointerOffset);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragged) return;

        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out localPointerPosition))
        {
            rectTransform.localPosition = localPointerPosition - pointerOffset;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dragEndedCallback(this);
        isDragged = false;
    }
}
