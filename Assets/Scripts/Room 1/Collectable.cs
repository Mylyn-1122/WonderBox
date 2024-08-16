using UnityEngine;
using System.Collections.Generic;
using UnityEngine;


public class Collectable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //player clicks on collectable
    //add collectable to player
    //collectable disapears
    void Start()
    {


    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider.gameObject.tag == "Collectable")
            {
                print("Collected!");
            }
        }
    }
}