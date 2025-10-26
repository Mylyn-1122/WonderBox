using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarKeyCollectR: MonoBehaviour
{


    GameObject starKeyR;


    // Start is called before the first frame update
    void Start()
    {

        starKeyR = GameObject.Find("starKey_Red");
        starKeyR.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SaveGameManager.RPG1);
        if (SaveGameManager.RPG1) {
            starKeyR.SetActive(true);
        }

        if (Collectable.redC)
        {
            starKeyR.SetActive(false);
        }


    }

    

    
}

