using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldTelescope : MonoBehaviour
{
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private Transform target;
    private bool mouse_press = false;
    private static bool cleared;

    // Start is called before the first frame update
    void Start()
    {
        target = transform;
        cleared = false;
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
    }



    private void OnMouseDown()
    {
        mouse_press = true;
    }

    private void OnMouseUp()
    {
        mouse_press = false;
    }
    public static bool getClear() {
        return cleared;
    }
}
