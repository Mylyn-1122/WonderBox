using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarKeyCollectR: MonoBehaviour
{


    SpriteRenderer starKeyR;



    // Start is called before the first frame update
    void Start()
    {

        starKeyR = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {


        if (Collectable.redC)
        {
            starKeyR.enabled = false;
        }


    }
}
