using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Rope_Code : MonoBehaviour
{
    private GameObject Rope;
    private GameObject Rope1;
    private static bool clicked;


    private void Awake()
    {
        SaveGameManager.Instance.Rope_Code = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rope = GameObject.Find("Rope");
        Rope1 = GameObject.Find("Rope_H");
        Rope1.GetComponent<SpriteRenderer>().enabled = false;
        Rope1.GetComponent<BoxCollider2D>().enabled = false;
        clicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if (ThreadGame.Connected1())
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.Equals(Rope))
                    {
                        clicked = true;
                        
                    }
                }
            }
        }

        if(clicked == true)
        {
            Rope.GetComponent<SpriteRenderer>().enabled = false;
            Rope.GetComponent<BoxCollider2D>().enabled = false;

            Rope1.GetComponent<SpriteRenderer>().enabled = true;
            Rope1.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    #region save and load

    public void Save(ref Rope_CodeData data)
    {
        data.RopeComp = clicked;

    }

    public void Load(Rope_CodeData data)
    {
        clicked = data.RopeComp;
    }



    #endregion


}
[System.Serializable]
public struct Rope_CodeData
{
    public bool RopeComp;
}

