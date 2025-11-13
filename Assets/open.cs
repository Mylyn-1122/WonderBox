using UnityEngine;

public class open : MonoBehaviour
{
    private GameObject door;
    public InventoryManager inventoryManager;
    private bool used;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        door = GameObject.Find("Door");
        used = false;
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
                if (hit.collider.gameObject.Equals(door))
                {
                    if (R5Collect.ticketC)
                    {
                        Camera.main.transform.position = new Vector3(-20, -20, -10);
                        if (!used)
                        {
                            inventoryManager.useItem(1);
                            used = true;
                        }
                    }
                }
            }
        }
    
    }
}
