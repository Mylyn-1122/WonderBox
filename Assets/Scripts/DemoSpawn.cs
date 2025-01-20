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

    public void GetSelectedItem()
    {
        Item receivedItem = inventoryManager.getSelectedItem(false);

        if(receivedItem != null)
        {
            Debug.Log("Received!");
        }
        else
        {
            Debug.Log("Nothing received :(");
        }
    }

    public void UseSelectedItem()
    {
        Item receivedItem = inventoryManager.getSelectedItem(true);

        if (receivedItem != null)
        {
            Debug.Log("Used!");
        }
        else
        {
            Debug.Log("Nothing used :(");
        }
    }
}
