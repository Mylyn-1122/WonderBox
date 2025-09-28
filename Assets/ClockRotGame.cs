using UnityEngine;

public class ClockRotGame : MonoBehaviour
{

    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private Transform target;
    private bool mouse_press = false;
    private static bool cleared;



    public float angle;

    private Transform MHand;
    private Transform HHand;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = transform;
        cleared = false;

        MHand = GameObject.Find("MHand").transform;
        HHand = GameObject.Find("HHand").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouse_press)
        {
            mouse_pos = Input.mousePosition;
            object_pos = Camera.main.WorldToScreenPoint(target.position);
            float angleRad = Mathf.Atan2(mouse_pos.y - object_pos.y, mouse_pos.x - object_pos.x);
            float angleDeg = (180 / Mathf.PI) * angleRad - 90;
            this.transform.rotation = Quaternion.Euler(0, 0, angleDeg);

        }

        

        if (MHand.rotation.z <= angle + 0.1 && MHand.rotation.z >= angle - 0.1)
        {
            if (HHand.rotation.z <= angle + 0.1 && HHand.rotation.z >= angle - 0.1)
            {
                Debug.Log("Yes!");
                cleared = true;
            }

        }
    }

    private void OnMouseDown()
    {
        mouse_press = true;
    }

    private void OnMouseUp()
    {
        mouse_press = false;
    }
    public static bool getClear()
    {
        return cleared;
    }
}
