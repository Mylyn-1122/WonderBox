using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChangeR2 : MonoBehaviour
{
    
    
    SpriteRenderer tele;
    
    public Sprite teleCleared;


    // Start is called before the first frame update
    void Start()
    {
        
        
        tele = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
         if (OldTelescope.getClear())
        {
            tele.sprite = teleCleared;
        }
        
        
        
        
    }
}
