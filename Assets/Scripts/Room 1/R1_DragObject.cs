using UnityEngine;
using UnityEngine.EventSystems;

public class R1_DragObject : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IInitializePotentialDragHandler
{

    [SerializeField] private Camera mainCamera;

    private RectTransform rectTransform;


    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        eventData.useDragThreshold = false;
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
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 newPos = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
        rectTransform.anchoredPosition = newPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
