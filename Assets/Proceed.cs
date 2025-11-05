using UnityEngine;

public class Proceed : MonoBehaviour
{
    private GameObject next;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        next = GameObject.Find("Next");
        next.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        if (KeyShardGame.getVictor())
        {
            next.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (Input.GetMouseButtonDown(0))
        {


            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);



            if (hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(next))
                {
                    Camera.main.transform.position = new Vector3(0, 20, -10);
                }
            }
        }
    }
}
