using UnityEngine;

public class open : MonoBehaviour
{
    private GameObject door;
    public InventoryManager inventoryManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        door = GameObject.Find("Door");
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
                    if (Collectable.ticketC)
                    {
                        Camera.main.transform.position = new Vector3(-20, -20, -10);
                        inventoryManager.useItem(1);
                    }
                }
            }
        }
    
    }
}
