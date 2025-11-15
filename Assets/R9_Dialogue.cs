using UnityEngine;
using UnityEngine.SceneManagement;

public class R9_Dialogue : MonoBehaviour
{
    private DialogueManager dMan;
    public InventoryManager inventoryManager;
    private GameObject book;
    private GameObject door;
    private GameObject paint;
    private GameObject mirror;
    private string[] R1 = {"Ah, this old thing...", "I still haven't gotten around to making any more friends...atleast not like them", "I don’t think I remember what their faces looked like, now that I think of it. Maybe revisiting some memories will help me out of this slump."};
    private string[] R3 = {"I can't leave, not now."};
    private string[] R4 = {"Who are these people?"};
    private string[] R5 = {"I don't want to look at myself."};
    private bool text1 = false;
    private bool text3 = false;
    private bool text4 = false;
    private bool text5 = false;
    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dMan = FindAnyObjectByType<DialogueManager>();
        book =GameObject.Find("Untitled123_20250924223528_0");  
        door =GameObject.Find("Square (1)");  
        paint =GameObject.Find("Square");  
        mirror = GameObject.Find("Square (2)");
        MemoryShards.max = 8;
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
                if (hit.collider.gameObject.Equals(book))
                {
                    if (!text1)
                    {
                        text1 = dMan.ShowBox(R1);
                    }

                    if (text1 && R9_ShardGame.getComp())
                    {
                        SceneManager.LoadScene("Room10", LoadSceneMode.Single);
                    }
                }
            

                if (hit.collider.gameObject.Equals(door))
                {
                    if (!text3)
                    {
                        text3 = dMan.ShowBox(R3);
                    }
                }

                if (hit.collider.gameObject.Equals(paint))
                {
                    if (!text4)
                    {
                        text4 = dMan.ShowBox(R4);
                    }
                }
                if (hit.collider.gameObject.Equals(mirror))
                {
                    if (!text5)
                    {
                        text5 = dMan.ShowBox(R5);
                    }
                }
            }
        }

        
    }
}
