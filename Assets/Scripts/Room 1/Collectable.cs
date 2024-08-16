using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Collectable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //player clicks on collectable
    //add collectable to player
    //collectable disapears

    private Inventory inventory;
    public CollectableType type;
    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    private void OnMouseDown()
    {
        
        if (gameObject.tag == "Collectable")
        {
            print("Collected!");
            inventory.Add(type);
            Destroy(this.gameObject);
        }
    }
}

public enum CollectableType
{
    NONE, STARKEY_YELLOW, STARKEY_BLUE, STARKEY_RED
}