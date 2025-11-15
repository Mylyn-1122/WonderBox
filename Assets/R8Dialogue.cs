using UnityEngine;

public class R8Dialogue : MonoBehaviour
{
    private DialogueManager dMan;
    public InventoryManager inventoryManager;
    private GameObject projector;
    private GameObject nav;
    private GameObject nav2;
    private GameObject nav3;
    private bool idk = true;
    private bool text1 = false;
    private bool text2 = false;
    private bool text3 = false;
    private bool text4 = false;
    private bool text5 = false;
    private bool text6 = false;
    private bool text7 = false;
    private string[] R1 = {"woah...","It's as beautiful as I remember..."};
    private string[] R2 = {"Hey, I used to work with this projector!","If I remember correctly, I had to rotate the lens to focus it.","I can't remember which direction I had to twist it though..."};
    private string[] R3 = {"Sweet, it works!","That symbol looks really familiar...is it a snake?"};
    private string[] R4 = {"I remember now..","I was only ever qualified enough to play these projections...", "I had overheard my boss talking about me, he said it was unlikely for me to ever move up...", "...unlikley that i'd ever make it.", "I wish I worked harder for my dreams."};
    private string[] R5 ={"Ugh...","This place was always such a mess, none of the visitors had the decency to clean up after themselves."};
    private string[] R6 ={"Some old astrology books.","Can't believe I brought these with me."};
    private string[] R7 ={"That's better."};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dMan = FindAnyObjectByType<DialogueManager>();
        projector = GameObject.Find("Circle (1)"); 
        nav = GameObject.Find("Navigate_Arrow (7)");   
        nav2 = GameObject.Find("Navigate_Arrow"); 
        nav3 = GameObject.Find("Square");
    }

    // Update is called once per frame
    void Update()
    {       
        if (idk == true)
        {
            if (!text1)
            {
                text1 = dMan.ShowBox(R1);
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
                if (hit.collider.gameObject.Equals(projector))
                {
                    if (!text2)
                    {
                        text2 = dMan.ShowBox(R2);
                    }
                }

                if (Projector_Game.procomp)
                {
                    if(!text3)
                    {
                        text3 = dMan.ShowBox(R3);
                        Projector_Game.procomp = false;
                    }
                }
            

                if (hit.collider.gameObject.Equals(nav))
                {
                    if (!text4)
                    {
                        text4 = dMan.ShowBox(R4);
                    }
                }

                
                if (hit.collider.gameObject.Equals(nav2))
                {
                    if (!text5)
                    {
                        text5 = dMan.ShowBox(R5);
                    }
                }

                if (hit.collider.gameObject.Equals(nav3))
                {
                    if (!text6)
                    {
                        text6 = dMan.ShowBox(R6);
                    }
                }

                if (R9_Trash_Game.trashcomp)
                {
                    if (!text7)
                    {
                        text7 = dMan.ShowBox(R7);
                        R9_Trash_Game.trashcomp = false;
                    }
                }
            }
        }
    }
}
