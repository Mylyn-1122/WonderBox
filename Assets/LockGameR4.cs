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

    private void Awake()
    {
        SaveGameManager.Instance.LockGameR4 = this;
    }


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
                        Debug.Log(open);
                    }
                    else
                    {
                        A1 = 0;
                        A2 = 0;
                    }
                }
                if (hit.collider.gameObject == One)
                {
                    A1 += 1;
                    Debug.Log(A1);
                }
                if (hit.collider.gameObject == Two)
                {
                    A2 +=1;
                    Debug.Log(A2);
                }
            }
        }
    }

    #region save and load

    public void Save(ref LockGameR4Data data)
    {
        data.LockGameR4Comp = complete;

    }

    public void Load(LockGameR4Data data)
    {
        complete = data.LockGameR4Comp;
    }



    #endregion


}
[System.Serializable]
public struct LockGameR4Data
{
    public bool LockGameR4Comp;
}

