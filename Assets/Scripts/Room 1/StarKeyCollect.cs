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
        starKeyB.enabled = false;
      
    }

    // Update is called once per frame
    void Update()
    {

        

        if (StainedGlassWindowGame.complete) {

            starKeyB.enabled = true;


        }
        if (Collectable.blueC)
        {
            starKeyB.enabled = false;
        }
        

    }
}
