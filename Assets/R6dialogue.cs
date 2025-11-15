using UnityEngine;
using UnityEngine.SceneManagement;

public class R6dialogue : MonoBehaviour
{
    private DialogueManager dMan;
    public InventoryManager inventoryManager;
    private GameObject crack;
    private GameObject nav;
    private GameObject bird;
    private GameObject nav2;
    private GameObject comp;
    private string[] R1 = {"This place looks strange…","I'm getting deja vu, but i've never-",  "...I don't think i've ever been here.","...","Hey is that glass cracked?"};
    private string[] R2 = {"Yikes.", "Theres a lot of water behind there…lets hope this glass holds.","Maybe I should check on the rest of the glass..."};
    private string[] R3 ={"What the heck?!", "That thing look sick, better not let that liquid touch me."};
    private string[] R4 ={"Huh, I forgot I had this.", "I think it was supposed to be a...bird?", "Maybe I can piece it back together."};
    private string[] R5 ={"Ugh, what is that smell?","Oh my god. My room is usually cleaner than this...","I should clean up before someone sees this.", "Let me put some of the spare litter in those trash bags before anyone sees"};
    private string[] R6 ={"Man, I had this computer back in college, I remember how it took 5 minutes to boot up.", "God, what was the password again? Something I could remember easily...", "Maybe something i've used before?"};
    private string[] R7 ={"Oh now I remember!","It was the bird fossil I loved when I was younger! I thought it was super rare.","Then my mom told me it was made out of plastic...fun times."};
    private string[] R8 ={"Phew...I think thats clean enough for now."};
     private bool idk = true;
    private bool text1 = false;
    private bool text2 = false;
    private bool text3 = false;
    private bool text4 = false;
    private bool text5 = false;
    private bool text6 = false;
    private bool text7 = false;
     private bool text8 = false;

    private GameObject left;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dMan = FindAnyObjectByType<DialogueManager>();
        nav = GameObject.Find("Aquarium");  
        crack = GameObject.Find("crack"); 
        bird = GameObject.Find("Untitled_Artwork 76_0"); 
        nav2 = GameObject.Find("Square (1)");  
        comp = GameObject.Find("Comp");
        left = GameObject.Find("Leaving");
        MemoryShards.max=5;
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
                if (hit.collider.gameObject.Equals(crack))
                {
                    if (!text2)
                    {
                        text2 = dMan.ShowBox(R2);
                    }
                }

            }

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(nav))
                {
                    if (!text3)
                    {
                        text3 = dMan.ShowBox(R3);
                    }
                }

            }

            
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(bird))
                {
                    if (!text4)
                    {
                        text4 = dMan.ShowBox(R4);
                    }
                }

            }

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(nav2))
                {
                    if (!text5)
                    {
                        text5 = dMan.ShowBox(R5);
                    }
                }

            }

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(comp))
                {
                    if (!text6)
                    {
                        text6 = dMan.ShowBox(R6);
                    }
                }



            }

            if (skeleGameManager.comdialogue)
            {
                if (!text7)
                {
                    text7 = dMan.ShowBox(R7);
            
                }
            }
            if (TrashGame.trashcomp)
            {
                if(!text8)
                {
                    text8 = dMan.ShowBox(R8);
                }
            }

            if(hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(left))
                {
                    SceneManager.LoadScene("Room7", LoadSceneMode.Single);
                }
            }
        }
    }

}
