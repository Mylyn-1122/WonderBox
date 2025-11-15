using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class R6_Password_Game : MonoBehaviour
{
  private string answer;
    private static bool complete;


    private GameObject Zero;
    private GameObject One;
    private GameObject Two;
    private GameObject Three;
    private GameObject Four;
    private GameObject Five;
    private GameObject Six;
    private GameObject Seven;
    private GameObject Eight;
    private GameObject Nine;


    private GameObject Delete;
    private GameObject Enter;


    // Start is called before the first frame update
    void Start()
    {
     

        Zero = GameObject.Find("Zero");
        One = GameObject.Find("One");
        Two = GameObject.Find("Two");
        Three = GameObject.Find("Three");
        Four = GameObject.Find("Four");
        Five = GameObject.Find("Five");
        Six = GameObject.Find("Six");
        Seven = GameObject.Find("Seven");
        Eight = GameObject.Find("Eight");
        Nine = GameObject.Find("Nine");

        Enter = GameObject.Find("Enter");
        Delete = GameObject.Find("Delete");

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
                if (hit.collider.gameObject == Enter)
                {
                    if (answer.Equals("0730"))
                    {


                        Debug.Log("Solved!");
                    }
                   
                }
                if (hit.collider.gameObject == Delete)
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
                if (hit.collider.gameObject == Zero)
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