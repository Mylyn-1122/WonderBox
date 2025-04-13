using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Dialouge : MonoBehaviour
{
    private DialogueManager dMan;
    private string[] R1 = { "I'm so high up..." , "Its beautiful."};
    private string[] R2 = { "Woah!", "It opened!"};
    private string[] R3 = { "I don't want to touch that yet." };
    private string[] R4 = { "What just happened?? I ..won?" };
    private string[] R5 = { "Ouch...I lost" };
    private bool text1 = false;
    private bool text2 = false;
    private bool text3 = false;
    private bool text4 = false;
    private bool text5 = false;




    // Start is called before the first frame update
    void Start()
    {
        dMan = FindAnyObjectByType<DialogueManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Window")
                {
                    if (!text1)
                    {
                        text1 = dMan.ShowBox(R1);
                    }
                    
                }
                if (hit.collider.gameObject.tag == "FinalP")
                {
                    if (!InventoryManager.getStars())
                    {
                       
                        text3 = dMan.ShowBox(R3);
                        
                    }
                    else
                    {
                        text2 = dMan.ShowBox(R2);
                        Camera.main.transform.position = new Vector3(20, -20, -10);


                    }
                }

            }
            
            
            
        }
                
        
      
    }
}
