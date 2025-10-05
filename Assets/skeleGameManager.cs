using UnityEngine;

public class skeleGameManager : MonoBehaviour
{
    private Transform posLeg;
    private Transform posWing;
    private Transform posNeck;
    private Transform posHead;
    private Transform posRib;
    private Transform posBeak;

    private Transform leg;
    private Transform head;
    private Transform neck;
    private Transform rib;
    private Transform wing;
    private Transform beak;

    private bool solvedHead;
    private bool solvedBeak;
    private bool solvedRib;
    private bool solvedWing;
    private bool solvedNeck;
    private bool solvedLeg;

    private static bool complete;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posLeg = GameObject.Find("posLeg").transform;
        posHead = GameObject.Find("posHead").transform;
        posWing = GameObject.Find("posWing").transform;
        posNeck = GameObject.Find("posNeck").transform;
        posBeak = GameObject.Find("PosBeak").transform;
        posRib = GameObject.Find("posRib").transform;

        leg = GameObject.Find("leg").transform;
        head = GameObject.Find("head").transform;
        rib = GameObject.Find("rib").transform;
        neck = GameObject.Find("neck").transform;
        wing = GameObject.Find("wing").transform;
        beak = GameObject.Find("beak").transform;

        solvedHead = false;
        solvedNeck = false;
        solvedLeg = false;
        solvedRib = false;
        solvedWing = false;
        solvedBeak = false;

        complete = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = posLeg.position - leg.position;
        float magnitude = distance.magnitude;
        if (magnitude < 0.5)
        {
            leg.position = posLeg.position;
            solvedLeg = true;
        }

        Vector3 distance1 = posHead.position - head.position;
        float magnitude1 = distance1.magnitude;
        if (magnitude1 < 0.5)
        {
            head.position = posHead.position;
            solvedHead = true;
        }

        Vector3 distance2 = posNeck.position - neck.position;
        float magnitude2 = distance2.magnitude;
        if (magnitude2 < 0.5)
        {
            neck.position = posNeck.position;
            solvedNeck = true;
        }

        Vector3 distance3 = posBeak.position - beak.position;
        float magnitude3 = distance3.magnitude;
        if (magnitude3 < 0.5)
        {
            beak.position = posBeak.position;
            solvedBeak = true;
        }

        Vector3 distance4 = posWing.position - wing.position;
        float magnitude4 = distance4.magnitude;
        if (magnitude4 < 0.5)
        {
            wing.position = posWing.position;
            solvedWing = true;
        }

        Vector3 distance5 = posRib.position - rib.position;
        float magnitude5 = distance5.magnitude;
        if (magnitude5 < 0.5)
        {
            rib.position = posRib.position;
            solvedRib = true;
        }

        if(solvedRib && solvedLeg && solvedHead && solvedBeak && solvedWing && solvedNeck)
        {
            complete = true;
        }
    }

    public static bool getComp()
    {
        return complete;
    }
}




