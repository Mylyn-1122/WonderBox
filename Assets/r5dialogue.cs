using UnityEngine;

public class r5dialogue : MonoBehaviour
{
    private DialogueManager dMan;
    public InventoryManager inventoryManager;
    private GameObject bear;
    private GameObject poster;
    private GameObject watch;
    private GameObject bird;
    private GameObject ghost;
    private GameObject train;
    private string[] R1 = {"I remember this bear!","She liked this one a lot, I wish I found this in time to give it to her...", "No point in dwelling on that now...it looks like I can still fix it!"};
    private string[] R2 = {"Ugh, that smells awful. Who spilled this inky sludge all over the wall?"};
    private string[] R3 = {"Huh, it doesn't work...","That's ok, who want's to be reminded of the passage of time anyway haha.","Maybe I should give it away."};
    private string[] R4 = {"Wait, that bird guy never told me where to get a ticket..."};
    private string[] R5 = {"???: [Welcome dear customer!]", "Woah, it can talk.","Bird: [Please present your payment! Please remember, dear guest, there are no r-refunds]","Hello? Do you know a way out of here?","Bird: [Dear guest! Please p-proceed to the trains! The platform should be to the left]","Hey-","Bird: [D-dont forget your ticket, please procced.]", "Ticket? Where do I get-","Bird: [Please proceed, do not hold the hold the line.]", "...ugh"};
    private string[] R6 = {"So this is the train...","Dang, just like the treehouse. Looks like there's no easy way out of here."};
    private bool text1 = false;
    private bool text2 = false;
    private bool text3 = false;
    private bool text4 = false;
    private bool text5 = false;
    private bool text6 = false;
    private bool fin = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dMan = FindAnyObjectByType<DialogueManager>(); 
        bear = GameObject.Find("Untitled_Artwork 66_0 (1)");
        poster = GameObject.Find("poster");
        watch = GameObject.Find("watch");
        bird = GameObject.Find("mr.birdman");
        ghost = GameObject.Find("ghost");
        train = GameObject.Find("Navigate_Arrow (7)");
        
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
                if (hit.collider.gameObject.Equals(bear))
                {
                    if (!text1)
                    {
                        text1 = dMan.ShowBox(R1);
                    }
                }

            }

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(poster))
                {
                    if (!text2)
                    {
                        text2 = dMan.ShowBox(R2);
                    }
                }

            }

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(watch))
                {
                    if (!text3)
                    {
                        text3 = dMan.ShowBox(R3);
                    }
                }

            }

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(watch))
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
                    if (!text5)
                    {
                        text5 = dMan.ShowBox(R5);
                        fin = true;
                    }
                }

            }


            if (hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(train))
                {
                    if (!text6)
                    {
                        text6 = dMan.ShowBox(R6);
                    }
                }

            }

            if (fin == true && watchGame.used)
            {
                if (hit.collider.gameObject.Equals(ghost))
                {
                        if (!text4)
                        {
                            text4 = dMan.ShowBox(R4);
                        }
                }

            }



        }
    }
}
