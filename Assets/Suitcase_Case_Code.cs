using UnityEngine;

public class Suitcase_Case_Code : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        

        Zero = GameObject.Find("0");
        One = GameObject.Find("1");
        Two = GameObject.Find("2");
        Three = GameObject.Find("3");
        Four = GameObject.Find("4");
        Five = GameObject.Find("5");
        Six = GameObject.Find("6");
        Seven = GameObject.Find("7");
        Eight = GameObject.Find("8");
        Nine = GameObject.Find("9");


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
                    Debug.Log(answer);
                }
                if (hit.collider.gameObject == Two)
                {
                    answer += "2";
                     Debug.Log(answer);
                }
                if (hit.collider.gameObject == Three)
                {
                    answer += "3";
                     Debug.Log(answer);
                }
                if (hit.collider.gameObject == Four)
                {
                    answer += "4";
                     Debug.Log(answer);
                }
                if (hit.collider.gameObject == Five)
                {
                    answer += "5";
                     Debug.Log(answer);
                }
                if (hit.collider.gameObject == Six)
                {
                    answer += "6";
                     Debug.Log(answer);
                }
                if (hit.collider.gameObject == Seven)
                {
                    answer += "7";
                    Debug.Log(answer);
                }
                if (hit.collider.gameObject == Eight)
                {
                    answer += "8";
                     Debug.Log(answer);
                }
                if (hit.collider.gameObject == Nine)
                {
                    answer += "9";
                     Debug.Log(answer);
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