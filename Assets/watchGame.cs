using UnityEngine;

public class watchGame : MonoBehaviour
{
    private GameObject ghost;
    private static bool start;
    private static bool end;
    public InventoryManager inventoryManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ghost = GameObject.Find("ghost");
        start = false;
        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        if (Input.GetMouseButtonDown(0))
        {


            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(ghost))
                {
                    if(start == false)
                    {
                        start = true;
                    }
                    else
                    {
                        end = true;
                        inventoryManager.useItem(1);
                    }
                }
            }
        }
    }

    public static bool getStart()
    {
        return start;
    }

    public static bool getEnd()
    {
        return end;
    }


}
