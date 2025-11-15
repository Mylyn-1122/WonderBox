using UnityEngine;
using UnityEngine.SceneManagement;

public class r3Dialogue : MonoBehaviour
{
    private DialogueManager dMan;
    public InventoryManager inventoryManager;
    private GameObject intro;
    private GameObject board;
    private GameObject classroom;
    private GameObject clock;
    private GameObject lunch;
    private string[] R1 = {"This place looks abandoned, i'm getting the creeps","Let's get out of here quickly"};
    private string[] R2 = {"I cant even remember what day it is.","Maybe it's related to my memory..."};
    private string[] R3 = {"Huh, I remember this class...","The clock was always broken, he used to complain about it all the time.","...","Why can't I remember his name?"};
    private string[] R4 = {"This thing looks ancient.","Why do the hands look so off?"};
    private string[] R5 ={"I remember this!","We always used to laugh about how bad they messed up the buttons on my lunch box","I think it was...","10 = 0, 11 = delete, 12 = enter"};
    private bool text1 = false;
    private bool text2 = false;
    private bool text3 = false;
    private bool text4 = false;
    private bool text5 = false;

    private GameObject exit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dMan = FindAnyObjectByType<DialogueManager>();  
        intro = GameObject.Find("StairsU");
        board = GameObject.Find("bday");
        classroom = GameObject.Find("Introarrow");
        clock = GameObject.Find("Clock");
        lunch = GameObject.Find("Locker");
        exit = GameObject.Find("Exit");
        MemoryShards.max = 2;
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
                if (hit.collider.gameObject.Equals(intro))
                {
                    if (!text1)
                    {
                        text1 = dMan.ShowBox(R1);
                    }
                }


                if (hit.collider.gameObject.Equals(board))
                {
                    if (!text2)
                    {
                        text2 = dMan.ShowBox(R2);
                    }
                }

                if (hit.collider.gameObject.Equals(classroom))
                {
                    if (!text3)
                    {
                        text3 = dMan.ShowBox(R3);
                    }
                }


                if (hit.collider.gameObject.Equals(clock))
                {
                    if (!text4)
                    {
                        text4 = dMan.ShowBox(R4);
                    }
                }

                if (hit.collider.gameObject.Equals(lunch))
                {
                    if (!text5)
                    {
                        text5 = dMan.ShowBox(R5);
                    }
                }
                if (hit.collider.gameObject.Equals(exit)&&ClockRotGame.getClear())
                {
                    SceneManager.LoadScene("Room4", LoadSceneMode.Single);
                }

            }

        }
    }
}
