using UnityEngine;
using UnityEngine.SceneManagement;

public class R10Dialogue : MonoBehaviour
{
    private DialogueManager dMan;
    public InventoryManager inventoryManager;
    private GameObject nav;
    private GameObject nav2;
     private GameObject nav3;
    private string[] R1 = {"I-I don't recognize this place", "This mist is so thick, I feel like im suffocating"};
    private string[] R3 = {"I feel like something's here...watching."};
    private string[] R4 = {"I don't think I should be here."};
    private string[] R5 = {"Why does it feel like i've seen all of this before?"};
    private bool text1 = false;
    private bool text3 = false;
    private bool text4 = false;
    private bool text5 = false;
    private bool idk = true;
    private GameObject end;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dMan = FindAnyObjectByType<DialogueManager>();  
        nav = GameObject.Find("Square (2)");
        nav2 = GameObject.Find("Square (3)");
        nav3 = GameObject.Find("Square (4)");
        end = GameObject.Find("TheEnd");
       
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
                if (hit.collider.gameObject.Equals(nav))
                {
                    if (!text3)
                    {
                        text3 = dMan.ShowBox(R3);
                    }
                }

                if (hit.collider.gameObject.Equals(nav2))
                {
                    if (!text4)
                    {
                        text4 = dMan.ShowBox(R4);
                    }
                }
                if (hit.collider.gameObject.Equals(nav3))
                {
                    if (!text5)
                    {
                        text5 = dMan.ShowBox(R5);
                    }
                }
                if (hit.collider.gameObject.Equals(end)&&Mirror_Shard_Game.getComp()&&Suitcase_Case_Code.returnClear())
                {
                    SceneManager.LoadScene("Finale", LoadSceneMode.Single);
                }
                //Debug.Log(TVR10.getComp() && Ticket_Shard_Minigame.getComp() && Mirror_Shard_Game.getComp() && Suitcase_Case_Code.returnClear());
            }
        }

        
    }
}

