using UnityEngine;
using UnityEngine.SceneManagement;

public class R7Dialogue : MonoBehaviour
{
     private DialogueManager dMan;
    public InventoryManager inventoryManager;
     private GameObject chart;
     private GameObject navup;
     private GameObject rope;
     private GameObject comp;
    private string[] R1 = {"Is this...a constellation chart?"};
    private string[] R2 = {"Woah...","Hey, this kinda looks like a constellation!"};
    private string[] R3 = {"This looks useful.","Maybe I can attach this to something to climb out of here."};
    private string[] R4 = {"Is this...my college computer?", "What happened to it..."};
    private string[] R5 = {"...", "I dont't think...", "I don't think I ever made any friends afer them","There was just too much to do and-","I let time get by me...","...some college expirence, huh?", "Let's just move on."};
    private string[] R6 = {"..."};
    private bool idk = true;
    private bool text1 = false;
    private bool text2 = false;
    private bool text3 = false;
    private bool text4 = false;
     private bool text5 = false;
     private bool text6 = false;
    private GameObject ropeH;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
         dMan = FindAnyObjectByType<DialogueManager>();
         chart= GameObject.Find("chart");  
         navup = GameObject.Find("Navigate_Arrow (4)");
         rope = GameObject.Find("Rope");
         comp = GameObject.Find("Comp");
        ropeH = GameObject.Find("Rope_H");
        MemoryShards.max = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (idk == true)
        {
            if (!text6)
            {
                text6 = dMan.ShowBox(R6);
                idk = false;
            }
         }
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);


            if (hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(chart))
                {
                    if (!text1)
                    {
                        text1 = dMan.ShowBox(R1);
                    }
                }
            }

            
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(navup))
                {
                    if (!text2)
                    {
                        text2 = dMan.ShowBox(R2);
                    }
                }
            }


             if (hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(rope))
                {
                    if (!text3)
                    {
                        text3 = dMan.ShowBox(R3);
                    }
                }
            }

             if (hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(comp))
                {
                    if (!text4)
                    {
                        text4 = dMan.ShowBox(R4);
                    }
                }

                if (hit.collider.gameObject.Equals(ropeH))
                {
                    SceneManager.LoadScene("Room8", LoadSceneMode.Single);
                }
            }

            if(RedBKG_Password_Game.comred)
            {
                if (!text5)
                {
                    text4 = dMan.ShowBox(R5);
                    RedBKG_Password_Game.comred = false;
                }
            }


        } 
    }
}
