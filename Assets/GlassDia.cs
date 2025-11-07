using UnityEngine;

public class GlassDia : MonoBehaviour
{
    private DialogueManager dMan;
    private string[] R1 = { "Huh, that looks expensive, why is it in this room?","I kinda want to touch it...","WAIT-"};
    private bool text1 = false;
    private GameObject window;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dMan = FindAnyObjectByType<DialogueManager>();
        window = GameObject.Find("WindowPuzzleNav");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
             if (hit.collider!= null)
                {

                    if (hit.collider.gameObject == window)
                    {
                        if (!text1)
                        {
                            text1 = dMan.ShowBox(R1);
                        }
                    }
                }
        }
}
}
