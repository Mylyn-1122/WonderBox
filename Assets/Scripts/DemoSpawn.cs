using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DemoSpawn : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickUp;

    public void PickUpItem(int id)
    {
        
       bool result = inventoryManager.AddItem(itemsToPickUp[id]);
        if (result == true)
        {
            Debug.Log("Item Added!");
        }
        else
        {
            Debug.Log("Inventory full!");
        }


    }
}
