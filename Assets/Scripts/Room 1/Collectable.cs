using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Collectable : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickUp;
    public static bool redC;
    public static bool yellowC;
    public static bool blueC;

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

        if (receivedItem != null)
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

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Collectable")
                {
                    if (hit.collider.gameObject.name == "starKey_Red")
                    {
                        PickUpItem(0);
                        redC = true;

                    }
                    else if (hit.collider.gameObject.name == "starKey_Blue")
                    {
                        PickUpItem(0);
                        blueC = true;
                    }
                    else if (hit.collider.gameObject.name == "starKey_Yellow") {
                        PickUpItem(0);
                        yellowC = true;
                    }
                }
            }
        }
    }
}

