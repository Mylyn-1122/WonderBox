/*
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Intro : MonoBehaviour
{
    private DialogueManager dMan;
    private string[] R1 = {"Where am I? I don’t remember"};
    private bool text1 = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dMan = FindAnyObjectByType<DialogueManager>();

    }

        
    // Update is called once per frame
    void Update()
    {
        if (!text1)
        {
            text1 = dMan.ShowBox(R1);
        }
    }

}
*/
