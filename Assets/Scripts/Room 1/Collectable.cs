using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Collectable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //player clicks on collectable
    //add collectable to player
    //collectable disapears
    public CollectableType type;
    

    void Start()
    {

    }

    void Update()
    {
    
    }

    private void OnMouseDown()
    {
        Player inventory = GetComponent<Player>();
        if (gameObject.tag == "Collectable")
        {
            print("Collected!");
            inventory.inventory.Add(type);
            Destroy(this.gameObject);
        }
    }
}

public enum CollectableType
{
    NONE, STARKEY_YELLOW, STARKEY_BLUE, STARKEY_RED
}