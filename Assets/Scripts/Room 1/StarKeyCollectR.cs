using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarKeyCollectY : MonoBehaviour
{


    SpriteRenderer starKeyY;



    // Start is called before the first frame update
    void Start()
    {

        starKeyY = gameObject.GetComponent<SpriteRenderer>();
        if (Collectable.yellowC)
        {
            starKeyY.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (Collectable.yellowC)
        {
            starKeyY.enabled = false;
        }


    }
}




