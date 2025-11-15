using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class MemoryShards : MonoBehaviour
{
    public  Sprite[] images;
    public  string[] text;
    public static int count;

    private GameObject next;
    private GameObject last;

    private GameObject pictures;
    private GameObject words;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        count = 0;
        next = GameObject.Find("NextPage");
        last = GameObject.Find("LastPage");

        pictures = GameObject.FindGameObjectWithTag("Picture");

        words = GameObject.FindGameObjectWithTag("Words");

        pictures.GetComponent<Image>().enabled = false;
        words.GetComponent<TextMeshProUGUI>().enabled = false;

        last.GetComponent<Image>().enabled = false;
        last.GetComponent<BoxCollider2D>().enabled = false;

        next.GetComponent<Image>().enabled = false;
        next.GetComponent<BoxCollider2D>().enabled = false;

        //images = new Sprite[9];
        //text = new string[9];
    }

    // Update is called once per frame
    void Update()
    {
        if (words.GetComponent<TextMeshProUGUI>().enabled)
        {
            last.GetComponent<BoxCollider2D>().enabled = true;
            next.GetComponent<BoxCollider2D>().enabled = true;
        }
        
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            if (Input.GetMouseButtonDown(0))
            {


                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.Equals(next))
                    {
                        if (count < images.Length - 1)
                        {
                            count++;

                        }
                    }
                    else if (hit.collider.gameObject.Equals(last))
                    {
                        if (count > 0)
                        {
                            count--;

                        }
                    }
                pictures.GetComponent<SpriteRenderer>().sprite = images[count];
                words.GetComponent<TextMeshProUGUI>().text = text[count];
            }
                
            }
        }

        
     

    public static void incCount()
    {
        count++;
    }

    
}
