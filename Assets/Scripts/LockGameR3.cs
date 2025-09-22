using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Fix all to match with new project
public class LockGameR3 : MonoBehaviour
{
    private string answer;
    private bool complete;
    SpriteRenderer closedSafe;
    public Sprite openSafe;
    private GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        closedSafe = gameObject.GetComponent<SpriteRenderer>();
        key = GameObject.Find("key");
        key.SetActive(false);
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
                if (hit.collider.gameObject.tag == "Enter")
                {
                    if (answer.Equals("3369"))
                    {
                        closedSafe.sprite = openSafe;
                        key.SetActive(true);

                        Debug.Log("Solved!");
                    }
                }
                if (hit.collider.gameObject.tag == "Delete")
                {
                    if (answer.Length > 0)
                    {
                        answer = answer.Substring(0, answer.Length - 1);
                    }

                }
                if (hit.collider.gameObject.tag == "One")
                {
                    answer += "1";
                }
                if (hit.collider.gameObject.tag == "Two")
                {
                    answer += "2";
                }
                if (hit.collider.gameObject.tag == "Three")
                {
                    answer += "3";
                }
                if (hit.collider.gameObject.tag == "Four")
                {
                    answer += "4";
                }
                if (hit.collider.gameObject.tag == "Five")
                {
                    answer += "5";
                }
                if (hit.collider.gameObject.tag == "Six")
                {
                    answer += "6";
                }
                if (hit.collider.gameObject.tag == "Seven")
                {
                    answer += "7";
                }
                if (hit.collider.gameObject.tag == "Eight")
                {
                    answer += "8";
                }
                if (hit.collider.gameObject.tag == "Nine")
                {
                    answer += "9";
                }
                if (hit.collider.gameObject.tag == "Zero")
                {
                    answer += "0";
                }
            }
        }
        //sets key inactive when clicked
        if (CaveNavigate.returnKey())
        {
            key.SetActive(false);
        }
    }



}