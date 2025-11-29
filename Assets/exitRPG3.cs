using UnityEngine;
using UnityEngine.SceneManagement;

public class exitRPG3 : MonoBehaviour
{
    private GameObject exit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        exit = GameObject.Find("Exit");
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
                if (hit.collider.gameObject.Equals(exit) && RPGManagerR3.getVictor())
                {
                    SaveGameManager.RPG3 = true;
                    SaveGameManager.RPG3Fin = true;
                    SceneManager.LoadScene("Room3");
                    Debug.Log("win");
                }

                if (hit.collider.gameObject.Equals(exit) && !RPGManagerR3.getVictor())
                {
                    Camera.main.transform.position = new Vector3(0, 0, -10);
                    Debug.Log("lose");

                }
            }
        }
    }
}
