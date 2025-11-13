using UnityEngine;

public class KeyShardGame : MonoBehaviour
{
 private Transform Shard1;
    private Transform Shard2;
    private Transform Shard3;
    private Transform posShard1;
    private Transform posShard2;
    private Transform posShard3;






    private bool shard1_solved = false;
    private bool shard2_solved = false;
    private bool shard3_solved = false;

    private DialogueManager dMan;


    private string[] compTextD = { "Its fixed now!" };
    private bool compText = false;


    public InventoryManager inventoryManager;
    public Item[] itemsToPickUp;
    public static bool complete = false;



    private static bool victor;

    private void Awake()
    {
        SaveGameManager.Instance.KeyShardGame = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Shard1 = GameObject.Find("obj1").transform;
        Shard2 = GameObject.Find("obj2").transform;
        Shard3 = GameObject.Find("obj3").transform;

        posShard1 = GameObject.Find("obj1Pos").transform;
        posShard2 = GameObject.Find("obj2Pos").transform;
        posShard3 = GameObject.Find("obj3Pos").transform;

        victor = false;



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



        if (shard1_solved && shard2_solved && shard3_solved )
        {


            if (!compText)
            {
                complete = true;
                compText = dMan.ShowBox(compTextD);
               
            }

            victor = true;
           




        }
    }


    public static bool getVictor()
    {
        return victor;
    }

    public void loadFin()
    {
        Shard1 = GameObject.Find("obj1").transform;
        Shard2 = GameObject.Find("obj2").transform;
        Shard3 = GameObject.Find("obj3").transform;

        posShard1 = GameObject.Find("obj1Pos").transform;
        posShard2 = GameObject.Find("obj2Pos").transform;
        posShard3 = GameObject.Find("obj3Pos").transform;

        Shard1.position = posShard1.position;
        Shard2.position = posShard2.position;
        Shard3.position = posShard3.position;
    }

    #region save and load

    public void Save(ref KeyShardGameData data)
    {
        data.KeyShardComp = victor;

    }

    public void Load(KeyShardGameData data)
    {
        if (data.KeyShardComp)
        {
            victor = data.KeyShardComp;
            loadFin();
            compText = data.KeyShardText;
        }
    }



    #endregion


}

[System.Serializable]
public struct KeyShardGameData
{
    public bool KeyShardComp;
    public bool KeyShardText;
}


