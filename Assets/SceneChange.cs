using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class SceneChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    

    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider!= null)
            {
                if (hit.collider.gameObject.tag == "RPG" &&!SaveGameManager.RPG1)
                {

                    SaveGameManager.SaveSignal = true;

                    SaveGameManager.R1Stars[0] = Collectable.yellowC;
                    SaveGameManager.R1Stars[1] = Collectable.blueC;
                    SaveGameManager.R1Stars[2] = Collectable.redC;




                    SceneManager.LoadScene("RPG1");

                }
            }
           
        }
    }


    
}
