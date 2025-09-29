using UnityEngine;

public class TrashGame : MonoBehaviour
{
    private Transform TrashBag;
    private Transform Trash1pos;
    private Transform Trash2pos;
    private Transform Trash3pos;
    private Transform Trash4pos;
    private Transform Trash5pos;
    private Transform Trash6pos;
    
    private static bool complete;
   

    private GameObject T1;
    private GameObject T2;
    private GameObject T3;
    private GameObject T4;
    private GameObject T5;
    private GameObject T6;

    private bool One;
    private bool Two;
    private bool Three;
    private bool Four;
    private bool Five;
    private bool Six;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Trash1pos = GameObject.Find("Trash1").transform;
        Trash2pos = GameObject.Find("Trash2").transform;
        Trash3pos = GameObject.Find("Trash3").transform;
        Trash4pos = GameObject.Find("Trash4").transform;
        Trash5pos = GameObject.Find("Trash5").transform;
        Trash6pos = GameObject.Find("Trash6").transform;

        TrashBag = GameObject.Find("TrashBag").transform;
        
        

        T1 = GameObject.Find("Trash1");
        T2 = GameObject.Find("Trash2");
        T3 = GameObject.Find("Trash3");
        T4 = GameObject.Find("Trash4");
        T5 = GameObject.Find("Trash5");
        T6 = GameObject.Find("Trash6");

        One = false;
        Two = false;
        Three = false;
        Four = false;
        Five = false;
        Six = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = Trash1pos.position - TrashBag.position;
        float magnitude = distance.magnitude;
        if (magnitude < 0.5)
        {
            One = true;
            T1.SetActive(false);
        }

        Vector3 distance1 = Trash2pos.position - TrashBag.position;
        float magnitude1 = distance1.magnitude;
        if (magnitude1 < 0.5)
        {
            Two = true;
            T2.SetActive(false);
        }

        Vector3 distance2 = Trash3pos.position - TrashBag.position;
        float magnitude2 = distance2.magnitude;
        if (magnitude2 < 0.5)
        {
            Three = true;
            T3.SetActive(false);
        }

        Vector3 distance3 = Trash4pos.position - TrashBag.position;
        float magnitude3 = distance3.magnitude;
        if (magnitude3 < 0.5)
        {
            Four = true;
            T4.SetActive(false);
        }

        Vector3 distance4 = Trash5pos.position - TrashBag.position;
        float magnitude4 = distance4.magnitude;
        if (magnitude4 < 0.5)
        {
            Five = true;
            T5.SetActive(false);
        }

        Vector3 distance5 = Trash6pos.position - TrashBag.position;
        float magnitude5 = distance5.magnitude;
        if (magnitude5 < 0.5)
        {
            Six = true;
            T6.SetActive(false);
        }

        if (One && Two && Three && Four && Five && Six)
        {
            complete = true;
            
        }

    }

    public static bool returnComp()
    {
        return complete;
    }
}
