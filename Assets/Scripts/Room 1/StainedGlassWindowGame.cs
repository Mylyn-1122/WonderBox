using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StainedGlassWindowGame : MonoBehaviour
{
    private Transform Shard1;
    private Transform Shard2;
    private Transform Shard3;
    private Transform Shard4;
    private Transform Shard5;
    private Transform Shard6;
    private Transform Shard7;
    private Transform Shard8;
    private Transform posShard1;
    private Transform posShard2;
    private Transform posShard3;
    private Transform posShard4;
    private Transform posShard5;
    private Transform posShard6;
    private Transform posShard7;
    private Transform posShard8;


    private bool shard1_solved = false;
    private bool shard2_solved = false;
    private bool shard3_solved = false;
    private bool shard4_solved = false;
    private bool shard5_solved = false;
    private bool shard6_solved = false;
    private bool shard7_solved = false;
    private bool shard8_solved = false;

    private DialogueManager dMan;

    private string[] compTextD = { "Its fixed now!" };
    private bool compText = false;

    public InventoryManager inventoryManager;
    public Item[] itemsToPickUp;
    public static bool complete = false;



    // Start is called before the first frame update
    void Start()
    {
        Shard1 = GameObject.Find("obj1").transform;
        Shard2 = GameObject.Find("obj2").transform;
        Shard3 = GameObject.Find("obj3").transform;
        Shard4 = GameObject.Find("obj4").transform;
        Shard5 = GameObject.Find("obj5").transform;
        Shard6 = GameObject.Find("obj6").transform;
        Shard7 = GameObject.Find("obj7").transform;
        Shard8 = GameObject.Find("obj8").transform;
        posShard1 = GameObject.Find("obj1Pos").transform;
        posShard2 = GameObject.Find("obj2Pos").transform;
        posShard3 = GameObject.Find("obj3Pos").transform;
        posShard4 = GameObject.Find("obj4Pos").transform;
        posShard5 = GameObject.Find("obj5Pos").transform;
        posShard6 = GameObject.Find("obj6Pos").transform;
        posShard7 = GameObject.Find("obj7Pos").transform;
        posShard8 = GameObject.Find("obj8Pos").transform;


        dMan = FindAnyObjectByType<DialogueManager>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = Shard1.position - posShard1.position;
        float magnitude = distance.magnitude;
        if (magnitude < 0.5)
        {
            Shard1.position = posShard1.position;
            //print("Solved shard 1");
            shard1_solved = true;


        }

        Vector3 distance2 = Shard2.position - posShard2.position;
        magnitude = distance2.magnitude;
        if (magnitude < 0.5)
        {

            Shard2.position = posShard2.position;
            // print("Solved shard 2");
            shard2_solved = true;
        }

        Vector3 distance3 = Shard3.position - posShard3.position;
        magnitude = distance3.magnitude;
        if (magnitude < 0.5)
        {

            Shard3.position = posShard3.position;
            //print("Solved shard 3");
            shard3_solved = true;
        }

        Vector3 distance4 = Shard4.position - posShard4.position;
        magnitude = distance4.magnitude;
        if (magnitude < 0.5)
        {

            Shard4.position = posShard4.position;
            //print("Solved shard 4");
            shard4_solved = true;
        }

        Vector3 distance5 = Shard5.position - posShard5.position;
        magnitude = distance5.magnitude;
        if (magnitude < 0.5)
        {

            Shard5.position = posShard5.position;
            //print("Solved shard 5");
            shard5_solved = true;
        }

        Vector3 distance6 = Shard6.position - posShard6.position;
        magnitude = distance6.magnitude;
        if (magnitude < 0.5)
        {

            Shard6.position = posShard6.position;
            // print("Solved shard 6");
            shard6_solved = true;
        }

        Vector3 distance7 = Shard7.position - posShard7.position;
        magnitude = distance7.magnitude;
        if (magnitude < 0.5)
        {

            Shard7.position = posShard7.position;
            //print("Solved shard 7");
            shard7_solved = true;
        }

        Vector3 distance8 = Shard8.position - posShard8.position;
        magnitude = distance8.magnitude;
        if (magnitude < 0.5)
        {

            Shard8.position = posShard8.position;
            //print("Solved shard 8");
            shard8_solved = true;
        }
        if (shard1_solved && shard2_solved && shard3_solved && shard4_solved && shard5_solved && shard6_solved && shard7_solved && shard8_solved)
        {

            if (!compText)
            {
                complete = true;
                compText = dMan.ShowBox(compTextD);
                
            }

            


        }
    }
}
