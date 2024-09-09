using UnityEngine;
using UnityEngine.EventSystems;

public class R1_DragObject : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler 
{

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;


    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
        Debug.Log(canvas.scaleFactor);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
