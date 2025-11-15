using UnityEngine;

public class R9_Trash_Game : MonoBehaviour
{
    private Transform TrashBag;
    private Transform Trash1pos;
    private Transform Trash2pos;
    private Transform Trash3pos;
    private Transform Trash4pos;
    private Transform Trash5pos;
    private Transform Trash6pos;
    private Transform Trash7pos;
   
    private static bool complete;
    public static bool trashcomp =false;
   
   
    private GameObject T1;
    private GameObject T2;
    private GameObject T3;
    private GameObject T4;
    private GameObject T5;
    private GameObject T6;
    private GameObject T7;


    private GameObject Trash_Bag;
    private GameObject Soda_Can;
    private GameObject Bottle_2;
    private GameObject Paper_1;
    private GameObject Paper_2;
    private GameObject Paper_Ball;
    private GameObject Paper_Ball_2;
    private GameObject Bottle_1;


    private bool One;
    private bool Two;
    private bool Three;
    private bool Four;
    private bool Five;
    private bool Six;
    private bool Seven;



    private void Awake()
    {
        SaveGameManager.Instance.trashR8 = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Trash1pos = GameObject.Find("Soda_Can").transform;
        Trash2pos = GameObject.Find("Bottle_2").transform;
        Trash3pos = GameObject.Find("Paper_1").transform;
        Trash4pos = GameObject.Find("Paper_2").transform;
        Trash5pos = GameObject.Find("Paper_Ball").transform;
        Trash6pos = GameObject.Find("Paper_Ball_2").transform;
        Trash7pos = GameObject.Find("Bottle_1").transform;


        TrashBag = GameObject.Find("Trash_Bag").transform;
       
       
        T1 = GameObject.Find("Soda_Can");
        T2 = GameObject.Find("Bottle_2");
        T3 = GameObject.Find("Paper_1");
        T4 = GameObject.Find("Paper_2");
        T5 = GameObject.Find("Paper_Ball");
        T6 = GameObject.Find("Paper_Ball_2");
        T7 = GameObject.Find("Bottle_1");

        One = false;
        Two = false;
        Three = false;
        Four = false;
        Five = false;
        Six = false;
        Seven = false;
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

        Vector3 distance6 = Trash7pos.position - TrashBag.position;
        float magnitude6 = distance6.magnitude;
        if (magnitude6 < 0.5)
        {
            Seven = true;
            T7.SetActive(false);
        }

        if (One && Two && Three && Four && Five && Six && Seven)
        {
            complete = true;
            trashcomp = true;
           
        }


    }


    public static bool returnComp()
    {
        return complete;
    }
    #region Save and Load

    public void Save(ref trashR8Data data)
    {
        data.trashR8C = complete;
    }

    public void Load(trashR8Data data)
    {
        complete = data.trashR8C;
    }
    #endregion

}

[System.Serializable]
public struct trashR8Data
{
    public bool trashR8C;
}

