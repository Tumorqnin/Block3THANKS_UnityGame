using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;


public class DraggableJoint : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public delegate void DragEndedDelegate(DraggableJoint draggableObject);
    public DragEndedDelegate dragEndedCallback;

    private RectTransform rectTransform;
    private Vector2 pointerOffset;
    private bool isDragged = false;
    public bool isSnapped = false;
    private int counter = 0;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        LoadSceneAfterDelay("MainRoom", 1f);
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

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}