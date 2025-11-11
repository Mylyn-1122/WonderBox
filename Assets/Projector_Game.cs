using UnityEngine;
using System.Collections.Generic;



public class Projector_Game : MonoBehaviour
{
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private Transform target;
    private bool mouse_press = false;
    private static bool cleared;

    private GameObject snakeB;
    public Sprite snakeC;
    


    public float angle;

    private void Awake()
    {
        SaveGameManager.Instance.projectorR8 = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        target = transform;
        cleared = false;
        snakeB = GameObject.Find("blurredSnake");
       

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

        if (this.transform.rotation.z <= angle + 0.1 && this.transform.rotation.z >= angle - 0.1)
        {
            cleared = true;
           
        }

        if (cleared)
        {
            snakeB.GetComponent<SpriteRenderer>().sprite = snakeC;
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

    #region Save and Load

    public void Save(ref projectorDataR8 data)
    {
        data.projectorR8C = cleared;
    }

    public void Load(projectorDataR8 data)
    {
        cleared = data.projectorR8C;
    }
    #endregion

}

[System.Serializable]
public struct projectorDataR8
{
    public bool projectorR8C;
}


