using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class r2_dialogue : MonoBehaviour
{
    private DialogueManager dMan;
    public InventoryManager inventoryManager;
    private GameObject Sheep;
    private GameObject Tv;
    private GameObject Tele;
    private GameObject Tree;
    private GameObject sky;
    private GameObject fren;
    private string[] R1 = { "I used to have one of these, she always smelled like the sun.", "I wonder what they did with it when I moved out.", "Moved out...", "Why did I move out?"};
    private string[] R2 = {"Wait, why do the antennas look like that?", "I thought they were supposed to be straight..."};
    private string [] R3 = {"Huh, I remember I gave this to her...when did it break?","Wait why am I remembering this now...","Ugh, this place is seriously messing with me."};
    private string[] R4 = {"For some reason this picture feels so cozy."};
    private string[] R5 = {"The sky again?", "This is getting creepy."};
    private string[] R6 = {"Who are these people?","Why can't I remember their faces?","...","I don't want to look at this anymore."};
    private bool text1 = false;
    private bool text2 = false;
    private bool text3 = false;
    private bool text4 = false;
    private bool text5 = false;
    private bool text6 = false;

    private VideoPlayer player;
    private bool animation2Finished = false;
    private GameObject hat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        dMan = FindAnyObjectByType<DialogueManager>();  
        Sheep = GameObject.Find("sheep");
        Tv = GameObject.Find("TV");
        Tele = GameObject.Find("Telescope");
        Tree = GameObject.Find("Tree");
        sky = GameObject.Find("sky");
        fren = GameObject.Find("friends");

        player = GameObject.Find("R2Cutsceen").GetComponent<VideoPlayer>();
        player.isLooping = false;
        hat = GameObject.Find("hat");
        //SaveSystem.Load();
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
                if (hit.collider.gameObject.Equals(Sheep))
                {
                    if (!text1)
                    {
                        text1 = dMan.ShowBox(R1);
                    }
                }

                if (hit.collider.gameObject.Equals(Tv))
                {
                    if (!text2)
                    {
                        text2 = dMan.ShowBox(R2);
                    }
                }
                
                if (hit.collider.gameObject.Equals(Tele))
                {
                    if (!text3)
                    {
                        text3 = dMan.ShowBox(R3);
                    }
                }
                                
                if (hit.collider.gameObject.Equals(Tree))
                {
                    if (!text4)
                    {
                        text4 = dMan.ShowBox(R4);
                    }
                }

                if (hit.collider.gameObject.Equals(sky))
                {
                    if (!text5)
                    {
                        text5 = dMan.ShowBox(R5);
                    }
                }

                if (hit.collider.gameObject.Equals(fren))
                {
                    if (!text6)
                    {
                        text6 = dMan.ShowBox(R6);
                    }
                }
                if (hit.collider.gameObject.Equals(hat))
                {
                    player.gameObject.SetActive(true);
                    player.Play();
                    MemoryShards.max++;
                    SaveSystem.Save();
                }
            }
        }

        if (animation2Finished)
        {
            SceneManager.LoadScene("Room2", LoadSceneMode.Single);
        }
        player.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.gameObject.SetActive(false);
        animation2Finished = true;
    }
}