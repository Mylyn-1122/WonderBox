using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class R1_DragObject : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{

    [SerializeField] private Camera mainCamera;

    [SerializeField] private float offset;
    //private CanvasGroup canvasGroup;

    // movable item is not hidden under slot
    Transform parentAfterDrag;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(null);
        transform.SetAsLastSibling();

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = -2;
        transform.position = newPos;
        


        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        Debug.Log("done");


    }

    public void OnDrop(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        Vector3 newSame = transform.position;

        Vector3 slotPosition3D = transform.parent.GetComponent<Transform>().position;
        Vector2 slotPos = new Vector2(slotPosition3D.x, slotPosition3D.y);
        Vector2 dropPos = new Vector2(transform.position.x, transform.position.y);
        Vector3 newPos = new Vector3(slotPos.x, slotPos.y, -2);

        if ((Mathf.Abs(dropPos.x - slotPos.x) < offset) && (Mathf.Abs(dropPos.x - slotPos.x) < offset))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            transform.position = newPos;

            // for example
            Debug.Log("success");
            Debug.Log(transform.position);
            

            

        }
    }



}
