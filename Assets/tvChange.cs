using UnityEngine;

public class tvChange : MonoBehaviour
{
    
    private GameObject tvBg;
   
    public Sprite tvFixF;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        tvBg = GameObject.Find("tvFar");
    }

    // Update is called once per frame
    void Update()
    {
        if (WireGameTV.getComplete())
        {
           
            tvBg.GetComponent<SpriteRenderer>().sprite = tvFixF;
        }
    }
}
