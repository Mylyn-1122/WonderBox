using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Fix all to match with new project
public class LockGameR3 : MonoBehaviour
{
    private string answer;
    private static bool complete;
    SpriteRenderer closedSafe;
    public Sprite openSafe;
    

    private GameObject One;
    private GameObject Two;
    private GameObject Three;
    private GameObject Four;
    private GameObject Five;
    private GameObject Six;
    private GameObject Seven;
    private GameObject Eight;
    private GameObject Nine;
    private GameObject Ten;
    private GameObject Eleven;
    private GameObject Twelve;

    private GameObject Console;

    // Start is called before the first frame update
    void Start()
    {
        closedSafe = gameObject.GetComponent<SpriteRenderer>();
      
        

        One = GameObject.Find("1");
        Two = GameObject.Find("2");
        Three = GameObject.Find("3");
        Four = GameObject.Find("4");
        Five = GameObject.Find("5");
        Six = GameObject.Find("6");
        Seven = GameObject.Find("7");
        Eight = GameObject.Find("8");
        Nine = GameObject.Find("9");
        Ten = GameObject.Find("10");
        Eleven = GameObject.Find("11");
        Twelve = GameObject.Find("12");

        Console = GameObject.Find("console");
        answer = "";
        Console.GetComponent<SpriteRenderer>().enabled = false;
        Console.GetComponent<BoxCollider2D>().enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        //Code for safe game, all click-check for user input
        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == Twelve)
                {
                    if (answer.Equals("0730"))
                    {
                        closedSafe.sprite = openSafe;
                     
                        complete = true;
                        Console.GetComponent<SpriteRenderer>().enabled = true;
                        Console.GetComponent<BoxCollider2D>().enabled = true;

                        Debug.Log("Solved!");
                    }
                   
                }
                if (hit.collider.gameObject == Eleven)
                {
                    if (answer.Length > 0)
                    {
                        answer = "";
                    }

                }
                if (hit.collider.gameObject == One)
                {
                    answer += "1";
                }
                if (hit.collider.gameObject == Two)
                {
                    answer += "2";
                }
                if (hit.collider.gameObject == Three)
                {
                    answer += "3";
                }
                if (hit.collider.gameObject == Four)
                {
                    answer += "4";
                }
                if (hit.collider.gameObject == Five)
                {
                    answer += "5";
                }
                if (hit.collider.gameObject == Six)
                {
                    answer += "6";
                }
                if (hit.collider.gameObject == Seven)
                {
                    answer += "7";
                }
                if (hit.collider.gameObject == Eight)
                {
                    answer += "8";
                }
                if (hit.collider.gameObject == Nine)
                {
                    answer += "9";
                }
                if (hit.collider.gameObject == Ten)
                {
                    answer += "0";
                }
                Debug.Log("answer is " + answer);
            }
            
        }
        //sets key inactive when clicked
        
    }

    public static bool returnClear()
    {
        return complete;
    }


}