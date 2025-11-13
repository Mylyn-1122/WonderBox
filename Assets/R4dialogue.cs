using UnityEngine;

public class R4dialogue : MonoBehaviour
{
    private DialogueManager dMan;
    public InventoryManager inventoryManager;
    private GameObject fish;
    private GameObject lake;
    private GameObject chess;
    private string[] R1 = {"Something feels off here...","Why is this place toying with me?"};
    private string[] R2 = {"Is...that fish holding something?", "Hey, that's the key to our treehouse!","How'd the fish get that?","No, nevermind that, I have to get that key back!"};
    private string[] R3 ={"Ah, I remember now. They wanted to talk with me...","...I guess they wanted to see if I woild make the right choice or not","Guessing from their reactions, I don't think they liked my idea of the future very much.","I wonder if my friends got the same questions...", "...hah"};
    private bool text1 = false;
    private bool text2 = false;
    private bool text3 = false;
    private bool idk = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dMan = FindAnyObjectByType<DialogueManager>(); 
        fish = GameObject.Find("Inside");
        lake = GameObject.Find("Lake");
        chess = GameObject.Find("Square");
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

                if (hit.collider.gameObject.Equals(lake))
                {
                    if (!text2)
                    {
                        text2 = dMan.ShowBox(R2);
                    }
                }

                if (hit.collider.gameObject.Equals(chess))
                {
                    if (!text3)
                    {
                        text3 = dMan.ShowBox(R3);
                    }
                }
                
                

            }
        }
    }
}
