using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DemoSpawn : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickUp;

    public void PickUpItem(int id)
    {
        
        inventoryManager.AddItem(itemsToPickUp[id]);
        


    }
}
