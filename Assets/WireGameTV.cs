using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WireGameTV : MonoBehaviour
{
    private Transform LB;
    private Transform RB;
    private Transform LT;
    private Transform RT;
    //public Transform objLookedAt;
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private Transform target;
    private bool mouse_press = false;
    private Collider2D LBC;
    private Collider2D LTC;
    private Collider2D RBC;
    private Collider2D RTC;
    private float LBTopX;
    private float LBTopY;
    private float LBBotX;
    private float LBBotY;

    private float LTTopX;
    private float LTTopY;
    private float LTBotX;
    private float LTBotY;

    private float RBTopX;
    private float RBTopY;
    private float RBBotX;
    private float RBBotY;

    private float RTTopX;
    private float RTTopY;
    private float RTBotX;
    private float RTBotY;
    public int goal;
    private static bool complete;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LB = GameObject.Find("WireLB").transform;
        RB = GameObject.Find("WireRB").transform;
        LT = GameObject.Find("WireLT").transform;
        RT = GameObject.Find("WireRT").transform;
        LBC = LB.GetComponent<Collider2D>();
        LTC = LT.GetComponent<Collider2D>();
        RBC = RB.GetComponent<Collider2D>();
        RTC = RT.GetComponent<Collider2D>();
        target = transform;
        LBTopX = LB.GetComponent<SpriteRenderer>().bounds.max.x;
        LBTopY = LB.GetComponent<SpriteRenderer>().bounds.max.y;
        LBBotX = LB.GetComponent<SpriteRenderer>().bounds.min.x;
        LBBotY = LB.GetComponent<SpriteRenderer>().bounds.min.y;

        LTTopX = LT.GetComponent<SpriteRenderer>().bounds.max.x;
        LTBotY = LT.GetComponent<SpriteRenderer>().bounds.max.y;
        LTBotX = LT.GetComponent<SpriteRenderer>().bounds.min.x;
        LTBotY = LT.GetComponent<SpriteRenderer>().bounds.min.y;

        RBTopX = RB.GetComponent<SpriteRenderer>().bounds.max.x;
        RBTopY = RB.GetComponent<SpriteRenderer>().bounds.max.y;
        RBBotX = RB.GetComponent<SpriteRenderer>().bounds.min.x;
        RBBotY = RB.GetComponent<SpriteRenderer>().bounds.min.y;

        RTTopX = RT.GetComponent<SpriteRenderer>().bounds.max.x;
        RTBotY = RT.GetComponent<SpriteRenderer>().bounds.max.y;
        RTBotX = RT.GetComponent<SpriteRenderer>().bounds.min.x;
        RTBotY = RT.GetComponent<SpriteRenderer>().bounds.min.y;
        complete = false;
        //Debug.Log(complete);

    }

    // Update is called once per frame
    void Update()
    {
        

        LBTopX = LB.GetComponent<SpriteRenderer>().bounds.max.x;
        LBTopY = LB.GetComponent<SpriteRenderer>().bounds.max.y;
        LBBotX = LB.GetComponent<SpriteRenderer>().bounds.min.x;
        LBBotY = LB.GetComponent<SpriteRenderer>().bounds.min.y;

        LTTopX = LT.GetComponent<SpriteRenderer>().bounds.max.x;
        LTBotY = LT.GetComponent<SpriteRenderer>().bounds.max.y;
        LTBotX = LT.GetComponent<SpriteRenderer>().bounds.min.x;
        LTBotY = LT.GetComponent<SpriteRenderer>().bounds.min.y;

        RBTopX = RB.GetComponent<SpriteRenderer>().bounds.max.x;
        RBTopY = RB.GetComponent<SpriteRenderer>().bounds.max.y;
        RBBotX = RB.GetComponent<SpriteRenderer>().bounds.min.x;
        RBBotY = RB.GetComponent<SpriteRenderer>().bounds.min.y;

        RTTopX = RT.GetComponent<SpriteRenderer>().bounds.max.x;
        RTBotY = RT.GetComponent<SpriteRenderer>().bounds.max.y;
        RTBotX = RT.GetComponent<SpriteRenderer>().bounds.min.x;
        RTBotY = RT.GetComponent<SpriteRenderer>().bounds.min.y;

        if (!LBC.IsTouching(LTC))
        {
            LTC.transform.position = new Vector3(LBTopX, LBTopY, LT.rotation.z);
        }
        if (!RBC.IsTouching(RTC))
        {
            RTC.transform.position = new Vector3(RBTopX, RBTopY, RT.rotation.z);
        }

        if (mouse_press)
        {
            mouse_pos = Input.mousePosition;
            object_pos = Camera.main.WorldToScreenPoint(target.position);
            float angleRad = Mathf.Atan2(mouse_pos.y - object_pos.y, mouse_pos.x - object_pos.x);
            float angleDeg = (180 / Mathf.PI) * angleRad - 90;
            this.transform.rotation = Quaternion.Euler(0, 0, angleDeg);

            
            //print(this.transform.rotation);
        }

        

        

        if (LB.rotation.z <= goal + .05 && LB.rotation.z >= goal - .05)
        {
            if (LT.rotation.z <= goal + .05 && LT.rotation.z >= goal - .05)
            {
                if (RB.rotation.z <= goal + .05 && RB.rotation.z >= goal - .05)
                {
                    if (RT.rotation.z <= goal + .05 && RT.rotation.z >= goal - .05)
                    {
                        complete = true;
                        //Debug.Log(complete);
                    }
                }
            }
        }
        if (complete)
        {
            
            LB.rotation = Quaternion.Euler(0, 0, goal);
            LT.rotation = Quaternion.Euler(0, 0, goal);
            RB.rotation = Quaternion.Euler(0, 0, goal);
            RT.rotation = Quaternion.Euler(0, 0, goal);
            
        }

    }



    public bool getMousePressed()
    {
        return mouse_press;
    }

    private void OnMouseDown()
    {
        mouse_press = true;
    }

    private void OnMouseUp()
    {
        mouse_press = false;
    }

    public static bool getComplete()
    {
        return complete;
    }

    public static void setComp()
    {
        complete = true;
    }

    public static void cancel()
    {
        complete = false;
    }
}