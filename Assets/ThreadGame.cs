using UnityEngine;

public class ThreadGame : MonoBehaviour
{
    bool Dragging = false;
    public LineRenderer Line;
    public Transform endThread;
    private int finished;

    void Start()
    {
        finished = 0;

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
            if(magnitude < 0.25)
            {
                transform.position = endThread.position;
                Line.SetPosition(2, endThread.position);
                Dragging = false;
                finished++;
            }
        }

        if(finished == 5)
        {
            //
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
}

