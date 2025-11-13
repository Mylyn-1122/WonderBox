using UnityEngine;

public class houseNav : MonoBehaviour
{
    private GameObject house;
    private GameObject Lock;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        house = GameObject.Find("house");
        Lock = GameObject.Find("lock");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);



        if (hit.collider != null)
        {
            if (OldTelescope.getClear()) {
                if (hit.collider.gameObject.Equals(Lock) && KeyShardGame.getVictor())
                {
                    Camera.main.transform.position = new Vector3(0, 20, -10);
                } else if (hit.collider.gameObject.Equals(house))
                {
                    Camera.main.transform.position = new Vector3(-20, -20, -10);
                }
            }
        }
    }
}
