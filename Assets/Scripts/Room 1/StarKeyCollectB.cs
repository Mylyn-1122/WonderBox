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
        starKeyR.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (RPGManagerR1.getVictor()) {
            starKeyR.enabled = true;
        }

        if ()
        {
            starKeyR.enabled = false;
        }


    }
}
