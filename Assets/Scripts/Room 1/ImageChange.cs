using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    //SpriteRenderer ClosedM;
    //public Sprite OpenM;
    //SpriteRenderer ClosedW;
    SpriteRenderer window;


    // Start is called before the first frame update
    void Start()
    {
        //ClosedM = gameObject.GetComponent<SpriteRenderer>();
        //ClosedW = gameObject.GetComponent<SpriteRenderer>();
        window = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /* if (InventoryManager.getStars())
        {
            ClosedM.sprite = OpenM;
        }
        if (StainedGlassWindowGame.complete) {
            ClosedW.enabled = true;
           

        }
        
        */
        if (StainedGlassWindowGame.complete)
        {
            window.enabled = false;

        }
    }
}
