using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class StarKeyComplete: MonoBehaviour
{
    private Transform key1;
    private Transform key2;
    private Transform key3;
   
    private Transform posKey1;
    private Transform posKey2;
    private Transform posKey3;
   


    private bool key1_solved = false;
    private bool key2_solved = false;
    private bool key3_solved = false;

    
    private VideoPlayer player;
    private bool animation2Finished = false;

    public InventoryManager inventoryManager;
    public Item[] itemsToPickUp;
    public static bool completeRoom = false;



    // Start is called before the first frame update
    void Start()
    {
        key1 = GameObject.Find("StarR").transform;
        key2 = GameObject.Find("StarB").transform;
        key3 = GameObject.Find("StarY").transform;
       
        posKey1 = GameObject.Find("StarRPos").transform;
        posKey2 = GameObject.Find("StarBPos").transform;
        posKey3 = GameObject.Find("StarYPos").transform;

        player = GameObject.Find("R1Cutsceen").GetComponent<VideoPlayer>();
        player.isLooping = false;
        //print("Initialized!");




    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = key1.position - posKey1.position;
        float magnitude = distance.magnitude;
        if (magnitude <= 0.5)
        {
            key1.position = posKey1.position;
            //print("Solved shard 1");
            key1_solved = true;


        }

        Vector3 distance2 = key2.position - posKey2.position;
        float magnitude2 = distance2.magnitude;
        if (magnitude2 <= 0.5)
        {

            key2.position = posKey2.position;
            //print("Solved shard 2");
            key2_solved = true;
        }

        Vector3 distance3 = key3.position - posKey3.position;
        float magnitude3 = distance3.magnitude;
        if (magnitude3 <= 0.5)
        {

            key3.position = posKey3.position;
            //print("Solved shard 3");
            key3_solved = true;
        }

        
        if (key1_solved && key2_solved && key3_solved)
        {


            completeRoom = true;
            player.gameObject.SetActive(true);
            player.Play();
            //SaveSystem.Save();


        }

        if (animation2Finished)
        {
            SceneManager.LoadScene("Room2", LoadSceneMode.Single);
        }
        player.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.gameObject.SetActive(false);
        animation2Finished = true;
    }

}
