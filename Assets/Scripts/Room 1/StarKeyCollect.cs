using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarKeyCollectB : MonoBehaviour
{


    //SpriteRenderer starKeyB;

    GameObject starKeyB;

    // Start is called before the first frame update
    void Start()
    {
        
        //starKeyB = gameObject.GetComponent<SpriteRenderer>();
        starKeyB = GameObject.Find("starKey_Blue");
        starKeyB.SetActive(false);
      
    }

    // Update is called once per frame
    void Update()
    {

        

        if (StainedGlassWindowGame.complete) {

            starKeyB.SetActive(true);


        }
        if (Collectable.blueC)
        {
            starKeyB.SetActive(false);
        }
        

    }
}
