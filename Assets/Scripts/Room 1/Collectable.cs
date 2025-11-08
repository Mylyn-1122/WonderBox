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
    public static bool RPG1Comp = false;
    public static bool watchC;
    public static bool ticketC;

    private void Awake()
    {
        SaveGameManager.Instance.Collectable = this;
    }

    public void Start()
    {
        if (SaveGameManager.JustFinRPG1 == true){
            if (SaveGameManager.R1Stars[0])
            {
                yellowC = true;
                PickUpItem(2);
            }
            if(SaveGameManager.R1Stars[1])
            {
                blueC = true;
                PickUpItem(0);
            }
            if (SaveGameManager.R1Stars[2])
            {
                redC = true;
                PickUpItem(1);
            }
            SaveGameManager.JustFinRPG1 = false;
        }
    }

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
                        PickUpItem(1);
                        redC = true;
                        SaveGameManager.R1Stars[2] = redC;

                    }
                    else if (hit.collider.gameObject.name == "starKey_Blue")
                    {
                        PickUpItem(0);
                        blueC = true;
                        SaveGameManager.R1Stars[1] = blueC;
                    }
                    else if (hit.collider.gameObject.name == "starKey_Yellow") {
                        PickUpItem(2);
                        yellowC = true;
                        SaveGameManager.R1Stars[0] = yellowC;
                    }
                    else if(hit.collider.gameObject.name == "watch")
                    {
                        PickUpItem(0);
                        watchC = true;
                    }
                    else if(hit.collider.gameObject.name == "ticket")
                    {
                        PickUpItem(1);
                        ticketC = true;
                    }
                }
            }
        }

        if (yellowC&& blueC&&redC)
        {
            InventoryManager.setStars(true);
        }
    }

    #region Save and Load

    public void Save(ref PlayerSaveData data)
    {
        data.YStar = yellowC;
        data.BStar = blueC;
        data.RStar = redC;
        data.RPG1Complete = SaveGameManager.RPG1;
    }

    public void Load(PlayerSaveData data)
    {
        if (data.YStar)
        {
            PickUpItem(2);
            
        }

        yellowC = data.YStar;
        SaveGameManager.R1Stars[0] = yellowC;

        if (data.BStar)
        {
            PickUpItem(0);
            
        }

        blueC = data.BStar;
        SaveGameManager.R1Stars[1] = blueC;

        if (data.RStar)
        {
            PickUpItem(1);
            
        }
        redC = data.RStar;
        SaveGameManager.R1Stars[2] = redC;


        RPG1Comp = data.RPG1Complete;
        SaveGameManager.RPG1 = RPG1Comp;


    }
    #endregion
}

[System.Serializable]
public struct PlayerSaveData
{
    public bool YStar;
    public bool BStar;
    public bool RStar;
    public bool RPG1Complete;
}