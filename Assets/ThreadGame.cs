using UnityEngine;

public class ThreadGame : MonoBehaviour
{
    bool Dragging = false;
    public LineRenderer Line;
    public Transform endThread;
 
    public static bool Connected = false;
    public bool conn = false;

    void Start()
    {
       
    }

    void Update()
    {
        if (Dragging)
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 convMousePos = Camera.main.ScreenToWorldPoint(mousePosition);
            convMousePos.z = 0;
            transform.position = convMousePos;

            Vector3 posDiff = convMousePos - Line.transform.position;
            Line.SetPosition(2, convMousePos);

            Vector3 endWireDiff = convMousePos - endThread.position;
            float magnitude = endWireDiff.magnitude;
            if(magnitude < 0.5f)
            {
                transform.position = endThread.position;
                Line.SetPosition(2, endThread.position);
                Dragging = false;
                Connected = true;
                conn = true;
                
            }
        }

        
    }

    private void OnMouseDown()
    {
        Dragging = true;
    }

    private void OnMouseUp()
    {
        Dragging = false;
        
    }

    public bool isConnected()
    {
        return (conn);
    }

    public static bool Connected1()
    {
        return Connected;
    }

    /*public void SetConnected(bool pConnected)
    {
        Connected = pConnected;
        if (!Connected)
        {

        }
    }
    */
}

