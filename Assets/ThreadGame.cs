using UnityEngine;

public class ThreadGame : MonoBehaviour
{
//change thread movement tomm, do it in here instead of in other file.
    bool dragging = false;
    private LineRenderer Line;
    private Transform thread1;
    private Transform threadEnd1;
    private Vector3 thread1Pos;
    private bool thread1Set = false;

    private Transform thread2;
    private Transform threadEnd2;
    private Vector3 thread2Pos;
    private bool thread2Set = false;

    private Transform thread3;
    private Transform threadEnd3;
    private Vector3 thread3Pos;
    private bool thread3Set = false;

    private Transform thread4;
    private Transform threadEnd4;
    private Vector3 thread4Pos;
    private bool thread4Set = false;

    private Transform thread5;
    private Transform threadEnd5;
    private Vector3 thread5Pos;
    private bool thread5Set = false;

    private string collided;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thread1 = GameObject.Find("ThreadStart").transform;
        threadEnd1 = GameObject.Find("EndThread").transform;
        thread1Pos = thread1.position;

        thread2 = GameObject.Find("ThreadStart1").transform;
        threadEnd2 = GameObject.Find("EndThread1").transform;
        thread2Pos = thread2.position;

        thread3 = GameObject.Find("ThreadStart2").transform;
        threadEnd3 = GameObject.Find("EndThread2").transform;
        thread3Pos = thread3.position;

        thread4 = GameObject.Find("ThreadStart3").transform;
        threadEnd4 = GameObject.Find("EndThread3").transform;
        thread4Pos = thread4.position;

        thread5 = GameObject.Find("ThreadStart4").transform;
        threadEnd5 = GameObject.Find("EndThread4").transform;
        thread5Pos = thread5.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            if (collided.Equals("ThreadStart")) {
                Line.SetPosition(2, thread1.position);
            }
            if (collided.Equals("ThreadStart1"))
            {
                Line.SetPosition(2, thread2.position);
            }
            if (collided.Equals("ThreadStart2"))
            {
                Line.SetPosition(2, thread3.position);
            }
            if (collided.Equals("ThreadStart3"))
            {
                Line.SetPosition(2, thread4.position);
            }
            if (collided.Equals("ThreadStart4"))
            {
                Line.SetPosition(2, thread5.position);
            }
        }

        Vector3 distance = thread1.position - threadEnd1.position;
        float magnitude = distance.magnitude;
        if (magnitude < 0.5)
        {
            thread1.position = threadEnd1.position;
            thread1Set = true;
        }

        Vector3 distance1 = thread2.position - threadEnd2.position;
        float magnitude1 = distance1.magnitude;
        if (magnitude1 < 0.5)
        {
            thread2.position = threadEnd2.position;
            thread2Set = true;
        }

        Vector3 distance2 = thread3.position - threadEnd3.position;
        float magnitude2 = distance2.magnitude;
        if (magnitude2 < 0.5)
        {
            thread3.position = threadEnd3.position;
            thread3Set = true;
        }

        Vector3 distance3 = thread4.position - threadEnd4.position;
        float magnitude3 = distance3.magnitude;
        if (magnitude3 < 0.5)
        {
            thread4.position = threadEnd4.position;
            thread4Set = true;
        }

        Vector3 distance4 = thread5.position - threadEnd5.position;
        float magnitude4 = distance4.magnitude;
        if (magnitude4 < 0.5)
        {
            thread5.position = threadEnd5.position;
            thread5Set = true;
        }
    }

        private void OnMouseDown()
        {

            dragging = true;
        }

        private void OnMouseUp()
        {
            dragging = false;

            if (thread1Set == false && collided.Equals("ThreadStart"))
            {
                thread1.position = thread1Pos;
                Line.SetPosition(2, thread1.position);
            }
            if(thread2Set == false && collided.Equals("ThreadStart1"))
            {
                thread2.position = thread2Pos;
                Line.SetPosition(2, thread2.position);
            }
            if (thread3Set == false && collided.Equals("ThreadStart2"))
            {
                thread3.position = thread3Pos;
                Line.SetPosition(2, thread3.position);
            }
            if (thread4Set == false && collided.Equals("ThreadStart3"))
            {
                thread4.position = thread4Pos;
                Line.SetPosition(2, thread2.position);
            }
            if (thread5Set == false && collided.Equals("ThreadStart4"))
            {
                thread5.position = thread5Pos;
                Line.SetPosition(2, thread5.position);
            }
            thread1.position = new Vector3(thread1.position.x, thread1.position.y, 0);
            thread2.position = new Vector3(thread2.position.x, thread1.position.y, 0);
            thread3.position = new Vector3(thread3.position.x, thread1.position.y, 0);
            thread4.position = new Vector3(thread4.position.x, thread1.position.y, 0);
            thread5.position = new Vector3(thread5.position.x, thread1.position.y, 0);

    }

    private void EnterCollision(Collision collision)
    {
        collided = collision.gameObject.name;
    }
   

}
