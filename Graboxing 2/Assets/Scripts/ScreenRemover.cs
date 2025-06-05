using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenRemover : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }
}
