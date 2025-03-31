using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarKeyCollectB : MonoBehaviour
{
    

    SpriteRenderer starKeyB;



    // Start is called before the first frame update
    void Start()
    {
        
        starKeyB = gameObject.GetComponent<SpriteRenderer>();
      
    }

    // Update is called once per frame
    void Update()
    {

        

        if (StainedGlassWindowGame.complete) {

            starKeyB.GetComponent<BoxCollider2D>().enabled = true;
            starKeyB.GetComponent<SpriteRenderer>().enabled = true;


        }
        if (Collectable.blueC)
        {
            starKeyB.GetComponent<BoxCollider2D>().enabled = false;
            starKeyB.GetComponent<SpriteRenderer>().enabled = false;
        }
        

    }
}
