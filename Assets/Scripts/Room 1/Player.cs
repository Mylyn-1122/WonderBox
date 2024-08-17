using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    //public bool player;
    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(5);
    }
    
}
