using UnityEngine;

public class Checkers_Puzzle : MonoBehaviour
{
 private Transform Shard1;
    private Transform Shard2;
    private Transform Shard3;
    private Transform Shard4;
    private Transform Shard5;
    private Transform Shard6;
    private Transform Shard7;
    private Transform Shard8;
    private Transform Shard9;
    private Transform Shard10;
    private Transform Shard11;
    private Transform posShard1;
    private Transform posShard2;
    private Transform posShard3;
    private Transform posShard4;
    private Transform posShard5;
    private Transform posShard6;
    private Transform posShard7;
    private Transform posShard8;
    private Transform posShard9;
    private Transform posShard10;
    private Transform posShard11;




    private bool shard1_solved = false;
    private bool shard2_solved = false;
    private bool shard3_solved = false;
    private bool shard4_solved = false;
    private bool shard5_solved = false;
    private bool shard6_solved = false;
    private bool shard7_solved = false;
    private bool shard8_solved = false;
    private bool shard9_solved = false;
    private bool shard10_solved = false;
    private bool shard11_solved = false;


    private DialogueManager dMan;


    private string[] compTextD = { "Its fixed now!" };
    private bool compText = false;


    public InventoryManager inventoryManager;
    public Item[] itemsToPickUp;
    public static bool complete = false;






    // Start is called before the first frame update
    void Start()
    {
        Shard1 = GameObject.Find("White_P").transform;
        Shard2 = GameObject.Find("White_P (1)").transform;
        Shard3 = GameObject.Find("White_P (2)").transform;
        Shard4 = GameObject.Find("White_P (3)").transform;
        Shard5 = GameObject.Find("White_P (4)").transform;
        Shard6 = GameObject.Find("White_P (5)").transform;
        Shard7 = GameObject.Find("White_P (6)").transform;
        Shard8 = GameObject.Find("White_P (7)").transform;
        Shard9 = GameObject.Find("White_P (8)").transform;
        Shard10 = GameObject.Find("White_P (9)").transform;
        Shard11 = GameObject.Find("White_P (10)").transform;
        posShard1 = GameObject.Find("White_Pos").transform;
        posShard2 = GameObject.Find("White_Pos (1)").transform;
        posShard3 = GameObject.Find("White_Pos (2)").transform;
        posShard4 = GameObject.Find("White_Pos (3)").transform;
        posShard5 = GameObject.Find("White_Pos (4)").transform;
        posShard6 = GameObject.Find("White_Pos (5)").transform;
        posShard7 = GameObject.Find("White_Pos (6)").transform;
        posShard8 = GameObject.Find("White_Pos (7)").transform;
        posShard9 = GameObject.Find("White_Pos (8)").transform;
        posShard10 = GameObject.Find("White_Pos (9)").transform;
        posShard11 = GameObject.Find("White_Pos (10)").transform;




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
        Vector3 distance9 = Shard9.position - posShard9.position;
        magnitude = distance9.magnitude;
        if (magnitude < 0.5)
        {


            Shard9.position = posShard9.position;
            //print("Solved shard 9");
            shard9_solved = true;
        }
         Vector3 distance10 = Shard10.position - posShard10.position;
        magnitude = distance10.magnitude;
        if (magnitude < 0.5)
        {


            Shard10.position = posShard10.position;
            //print("Solved shard 10");
            shard10_solved = true;
        }
        Vector3 distance11 = Shard11.position - posShard11.position;
        magnitude = distance11.magnitude;
        if (magnitude < 0.5)
        {


            Shard11.position = posShard11.position;
            //print("Solved shard 8");
            shard11_solved = true;
        }
        if (shard1_solved && shard2_solved && shard3_solved && shard4_solved && shard5_solved && shard6_solved && shard7_solved && shard8_solved && shard9_solved && shard10_solved && shard11_solved)
        {


            if (!compText)
            {
                complete = true;
                compText = dMan.ShowBox(compTextD);
               
            }


           




        }
    }
}
