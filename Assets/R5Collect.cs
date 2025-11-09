using UnityEngine;

public class R5Collect : MonoBehaviour
{

    private GameObject watch;
    private GameObject ticket;
    public InventoryManager inventoryManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        watch = GameObject.Find("watch");
        ticket = GameObject.Find("ticket");

        ticket.GetComponent<BoxCollider2D>().enabled = false;
        ticket.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Collectable.watchC)
        {
            watch.GetComponent<BoxCollider2D>().enabled = false;
            watch.GetComponent<SpriteRenderer>().enabled = false;

            
        }

        if (watchGame.getEnd())
        {
            ticket.GetComponent<BoxCollider2D>().enabled = true;
            ticket.GetComponent<SpriteRenderer>().enabled = true;
           
        }

        if (Collectable.ticketC)
        {
            ticket.GetComponent<BoxCollider2D>().enabled = false;
            ticket.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
