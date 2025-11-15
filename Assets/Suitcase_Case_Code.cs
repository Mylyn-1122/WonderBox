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

    private SpriteRenderer closed;
    public Sprite open;
    private GameObject picture;


    private void Awake()
    {
        SaveGameManager.Instance.Suitcase = this;
    }

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

        picture = GameObject.Find("picture");
        closed = gameObject.GetComponent<SpriteRenderer>();

        picture.GetComponent<BoxCollider2D>().enabled = false;
        picture.GetComponent<SpriteRenderer>().enabled = false;

        complete = false;

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
                        complete = true;

                        Debug.Log("Solved!");
                    }
                    else
                    {
                        answer = "";
                    }
                   
                }
                if (hit.collider.gameObject == Delete)
                {
                    if (answer.Length > 0)
                    {
                        answer = "";
                    }


                }
                if (hit.collider.gameObject == Zero)
                {
                    answer += "0";
                    Debug.Log('0');
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
                     Debug.Log('3');
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
                    Debug.Log('7');
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
        if (complete)
        {
            picture.GetComponent<BoxCollider2D>().enabled = true;
            picture.GetComponent<SpriteRenderer>().enabled = true;

            closed.sprite = open;

            One.GetComponent<BoxCollider2D>().enabled = false;
            Two.GetComponent<BoxCollider2D>().enabled = false;
            Three.GetComponent<BoxCollider2D>().enabled = false;
            Four.GetComponent<BoxCollider2D>().enabled = false;
            Five.GetComponent<BoxCollider2D>().enabled = false;
            Six.GetComponent<BoxCollider2D>().enabled = false;
            Seven.GetComponent<BoxCollider2D>().enabled = false;
            Eight.GetComponent<BoxCollider2D>().enabled = false;
            Nine.GetComponent<BoxCollider2D>().enabled = false;
            Enter.GetComponent<BoxCollider2D>().enabled = false;
            Delete.GetComponent<BoxCollider2D>().enabled = false;
        }
       
    }


    public static bool returnClear()
    {
        return complete;
    }

    #region save and load

    public void Save(ref SuitcaseData data)
    {
        data.SuitcaseComp = complete;

    }

    public void Load(SuitcaseData data)
    {
        complete = data.SuitcaseComp;
    }



    #endregion


}
[System.Serializable]
public struct SuitcaseData
{
    public bool SuitcaseComp;
}