using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Rope_Code : MonoBehaviour
{
    SpriteRenderer Rope_Render;
    
     public Sprite Rope;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rope_Render = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ThreadGame.isConnected())
        {
            Rope_Render.sprite = Rope;
        }
    }
}
