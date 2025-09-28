using UnityEngine;

public class TelescopeMovementCheck : MonoBehaviour
{
    private GameObject teleport;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        teleport = GameObject.Find("Telescope");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == teleport && OldTelescope.getClear())
                {
                    Camera.main.transform.position = new Vector3(-20, 0, -10);
                }
                else if(hit.collider.gameObject == teleport && !OldTelescope.getClear())
                {
                    Camera.main.transform.position = new Vector3(0, -20, -10);
                }
            }
        }
    }
}
