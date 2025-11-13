using UnityEngine;

public class R5Collect : MonoBehaviour
{

    private GameObject watch;
    private GameObject ticket;
    public InventoryManager inventoryManager;
    public Item[] itemsToPickUp;

    public static bool ticketC;
    public static bool watchC;

    public static bool R5C;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        watch = GameObject.Find("watch");
        ticket = GameObject.Find("ticket");

        ticket.GetComponent<BoxCollider2D>().enabled = false;
        ticket.GetComponent<SpriteRenderer>().enabled = false;

        //SaveSystem.Save();
        if (SaveGameManager.R5Ticket)
        {
            ticketC = true;
            PickUpItem(1);
        }
        if (SaveGameManager.R5Watch)
        {
            watchC = true;
            PickUpItem(0);
        }
        //SaveSystem.Load();
    }

    public void PickUpItem(int id)
    {



        bool result = inventoryManager.AddItem(itemsToPickUp[id]);
        if (result == true)
        {
            Debug.Log("Item Added!");

        }
        else
        {
            Debug.Log("Inventory full!");
        }

    }

    public void GetSelectedItem()
    {
        Item receivedItem = inventoryManager.getSelectedItem(false);

        if (receivedItem != null)
        {
            Debug.Log("Received!");
        }
        else
        {
            Debug.Log("Nothing received :(");
        }
    }

    public void UseSelectedItem()
    {
        Item receivedItem = inventoryManager.getSelectedItem(true);

        if (receivedItem != null)
        {
            Debug.Log("Used!");
        }
        else
        {
            Debug.Log("Nothing used :(");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Collectable")
                {

                    if (hit.collider.gameObject.name == "watch")
                    {
                        PickUpItem(0);
                        watchC = true;
                    }
                    else if (hit.collider.gameObject.name == "ticket")
                    {
                        PickUpItem(1);
                        ticketC = true;
                    }
                }
            }
            if (watchC)
            {
                watch.GetComponent<BoxCollider2D>().enabled = false;
                watch.GetComponent<SpriteRenderer>().enabled = false;


            }

            if (watchGame.getEnd())
            {
                ticket.GetComponent<BoxCollider2D>().enabled = true;
                ticket.GetComponent<SpriteRenderer>().enabled = true;

            }

            if (ticketC)
            {
                ticket.GetComponent<BoxCollider2D>().enabled = false;
                ticket.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
    #region Save and Load

    public void Save(ref R5Data data)
    {
        
        data.R5Complete = (watchGame.getEnd()&&ticketC&&ThreadGameMan.getWins());
        data.ticket = ticketC;
        data.watch = watchC;
    }

    public void Load(R5Data data)
    {
        R5C = data.R5Complete;
        SaveGameManager.R5 = R5C;

    }
    #endregion
}

[System.Serializable]
public struct R5Data
{
    
    public bool R5Complete;
    public bool ticket;
    public bool watch;

}
