using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] InventorySlots;
    public GameObject DraggableItemPrefab;

    public bool AddItem(Item item)
    {

        //find a empty slot
        for(int i = 0; i<InventorySlots.Length; i++)
        {
            InventorySlot slot = InventorySlots[i];
            DraggableItem itemInSlot = slot.GetComponentInChildren < DraggableItem>();

            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;

            }
        }
        return false;

    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(DraggableItemPrefab, slot.transform);
        DraggableItem draggableItem = newItemGo.GetComponent<DraggableItem>();
        draggableItem.InitialiseItem(item);
    }

}
