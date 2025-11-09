using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public int maxItems = 12;
    public InventorySlot[] InventorySlots;
    public GameObject DraggableItemPrefab;
    private static bool allStars;
    private int countStar;

    int selectedSlot = -1;

    private void Start()
    {
        countStar = 0;
        allStars = false;
        //ChangeSelectedSlot(0);
        
    }

    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 7)
            {
                ChangeSelectedSlot(number - 1);
            }
        }

        

        
    }
    void ChangeSelectedSlot(int slot)
    {
        if (selectedSlot >= 0)
        {
            InventorySlots[selectedSlot].Deselect();
        }

        InventorySlots[slot].Select();
        selectedSlot = slot;
    }

    public bool AddItem(Item item)
    {
        
        //Check for slot with less than maximum items to stack
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            InventorySlot slot = InventorySlots[i];
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();

            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxItems
                && itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;

            }
            
        }


        //find a empty slot
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            
            InventorySlot slot = InventorySlots[i];
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();


            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                if (item.getType() == "Key")
                {
                    countStar++;
                    Debug.Log("Star ++!");
                    //Debug.Log(InventorySlots.Length);
                }
                if (countStar == 3)
                {
                    allStars = true;
                    countStar = 0;
                }
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

    public Item getSelectedItem(bool use)
    {
        InventorySlot slot = InventorySlots[selectedSlot];
        DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();

        if (itemInSlot != null)
        {

            Item item = itemInSlot.item;
            if (use == true)
            {
                itemInSlot.count--;
                if(itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                    itemInSlot.RefreshCount();
                }
            }
            return item;
        }

        return null;

    } 

    public Item useItem(int slots)
    {
        InventorySlot slot = null;
        DraggableItem itemInSlot = null;
        Item item = null;
        for (int i = 0; i < slots; i++)
        {

            slot = InventorySlots[i];
            itemInSlot = slot.GetComponentInChildren<DraggableItem>();
            item = itemInSlot.item;
            if (itemInSlot != null)
            {

                Destroy(itemInSlot.gameObject);
                Debug.Log("working");
            }
            


        }
        return item;
        
    }

    public static bool getStars() {
        return allStars;
    }

    public static void setStars(bool val)
    {
        allStars = val;
    }
    
}