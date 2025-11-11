using UnityEngine;

public class backpackNav : MonoBehaviour
{
    private GameObject Lock;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Lock = GameObject.Find("lock");
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
                if (hit.collider.gameObject.Equals(Lock)&&LockGameR4.getComp())
                {
                    Camera.main.transform.position = new Vector3(0, -20, -10);
                }else if(hit.collider.gameObject.Equals(Lock) && !LockGameR4.getComp())
                {
                    Camera.main.transform.position = new Vector3(20, -40, -10);
                }
            }
        }
    }
}
