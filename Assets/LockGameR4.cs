using UnityEngine;

public class LockGameR4 : MonoBehaviour
{
    private static bool complete;
    SpriteRenderer closedLock;
    public Sprite openLock;
    private int A1;
    private int A2;


    private GameObject One;
    private GameObject Two;
    private GameObject open;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closedLock = gameObject.GetComponent<SpriteRenderer>();

        One = GameObject.Find("One");
        Two = GameObject.Find("Two");
        open = GameObject.Find("Open");

        A1 = 0;
        A2 = 0;
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
                if (hit.collider.gameObject == open)
                {
                    if(A1 == 5 && A2 == 2)
                    {
                        complete = true;
                        closedLock.sprite = openLock;
                    }
                    else
                    {
                        A1 = 0;
                        A2 = 0;
                    }
                }
                if (hit.collider.gameObject == One)
                {
                    A1++;
                }
                if (hit.collider.gameObject == Two)
                {
                    A2++;
                }
            }
        }
    }
}
