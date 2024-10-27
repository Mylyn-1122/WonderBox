using UnityEngine;
using UnityEngine.EventSystems;

public class R1_ItemSlot : MonoBehaviour, IDropHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped");
    }
    
}
