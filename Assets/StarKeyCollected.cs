using UnityEngine;

public class StarKeyCollected : MonoBehaviour
{
    SpriteRenderer starKeyB;
    SpriteRenderer starKeyY;
    SpriteRenderer starKeyR;

    GameObject starR;
    GameObject starB;
    GameObject starY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        starKeyB = GameObject.Find("starKey_Blue").GetComponent<SpriteRenderer>();
        starB = GameObject.Find("starKey_Blue");
        starKeyB.enabled = false;
        //starB.SetActive(false);
        starKeyY = GameObject.Find("starKey_Yellow").GetComponent<SpriteRenderer>();
        starY = GameObject.Find("starKey_Yellow");
        starKeyY.enabled = true;
        //starY.SetActive(true);
        starKeyR = GameObject.Find("starKey_Red").GetComponent<SpriteRenderer>();
        starR = GameObject.Find("starKey_Red");
        starKeyR.enabled = false;
        //starR.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (RPGManagerR1.getVictor()&&!Collectable.redC) {
            starKeyR.enabled = true;
            starR.SetActive(true);

        }
        if (StainedGlassWindowGame.complete&&!Collectable.blueC) {
            starKeyB.enabled = true;
            starB.SetActive(true);
        }
        if (Collectable.redC) {
            starKeyR.enabled = false;
            starR.SetActive(false);
        }
        if (Collectable.blueC) {
            starKeyB.enabled = false;
            starB.SetActive(false);
        }
        if (Collectable.yellowC) {
            starKeyY.enabled = false;
            starY.SetActive(false);
        }
       
     
    }

    
}

