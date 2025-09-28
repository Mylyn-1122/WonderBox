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
    private GameObject key;

    private Transform One;
    private Transform Two;
    private Transform Three;
    private Transform Four;
    private Transform Five;
    private Transform Six;
    private Transform Seven;
    private Transform Eight;
    private Transform Nine;
    private Transform Ten;
    private Transform Eleven;
    private Transform Twelve;

    private GameObject Console;

    // Start is called before the first frame update
    void Start()
    {
        closedSafe = gameObject.GetComponent<SpriteRenderer>();
        key = GameObject.Find("console");
        key.SetActive(false);

        One = GameObject.Find("1").transform;
        Two = GameObject.Find("2").transform;
        Three = GameObject.Find("3").transform;
        Four = GameObject.Find("4").transform;
        Five = GameObject.Find("5").transform;
        Six = GameObject.Find("6").transform;
        Seven = GameObject.Find("7").transform;
        Eight = GameObject.Find("8").transform;
        Nine = GameObject.Find("9").transform;
        Ten = GameObject.Find("10").transform;
        Eleven = GameObject.Find("11").transform;
        Twelve = GameObject.Find("12").transform;
        Console = GameObject.Find("console");
        answer = "";

        
        
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
                    if (answer.ToString().Equals("0730"))
                    {
                        closedSafe.sprite = openSafe;
                        key.SetActive(true);
                        complete = true;
                        Console.SetActive(true);
                        Debug.Log("Solved!");
                    }
                    else
                    {
                        Console.SetActive(false);
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
                Debug.Log(answer.ToString());
            }
            
        }
        //sets key inactive when clicked
        
    }

    public static bool returnClear()
    {
        return complete;
    }


}