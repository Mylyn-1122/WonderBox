using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldTelescope : MonoBehaviour
{
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private Transform target;
    private bool mouse_press = false;
    private static bool cleared = false;
    


    public float angle;

    private void Awake()
    {
        SaveGameManager.Instance.OldTelescope = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        target = transform;
        

       

    }

    // Update is called once per frame
    void Update()
    {
        if (cleared)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
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

    #region save and load

    public void Save(ref OldTelescopeData data)
    {
        data.TelescopeComp = cleared;

    }

    public void Load(OldTelescopeData data)
    {
        if (data.TelescopeComp)
        {
            cleared = data.TelescopeComp;
        }
    }



    #endregion


}
[System.Serializable]
public struct OldTelescopeData
{
    public bool TelescopeComp;
}
 