using UnityEngine;

public class watchGame : MonoBehaviour
{
    private GameObject ghost;
    private static bool start;
    private static bool end;
    public static bool used;
    public InventoryManager inventoryManager;

    private void Awake()
    {
        SaveGameManager.Instance.watchGame = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ghost = GameObject.Find("ghost");
        start = false;
        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        if (Input.GetMouseButtonDown(0))
        {


            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(ghost) && !end)
                {
                    if(start == false)
                    {
                        start = true;
                    }
                    else
                    {
                        end = true;
                        inventoryManager.useItem(1);
                        used = true;

                    }
                }
            }
        }

        if (end)
        {
            //inventoryManager.useItem(1);
        }
    }

    public static bool getStart()
    {
        return start;
    }

    public static bool getEnd()
    {
        return end;
    }

    #region save and load

    public void Save(ref watchGameData data)
    {
        data.watchComp = end;

    }

    public void Load(watchGameData data)
    {
        end = data.watchComp;
    }



    #endregion


}
[System.Serializable]
public struct watchGameData
{
    public bool watchComp;
}


