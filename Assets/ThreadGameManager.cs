using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class ThreadGameManager : MonoBehaviour
{
    public List<ThreadGame> Threads;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int connectedThreads = 0;

        foreach(ThreadGame t in Threads)
        {
            if (t.isConnected())
            {
                connectedThreads++;
            }
        }

        if(connectedThreads == Threads.Count)
        {
            Debug.Log("Win");
        }
    }
}
