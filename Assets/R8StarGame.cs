using UnityEngine;

public class R8StarGame : MonoBehaviour
{
    private static bool comp;

    private void Awake()
    {
        SaveGameManager.Instance.StarGameR8 = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        comp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ThreadGameManager.winGet())
        {
            comp = true;
        }
    }

    public static bool compGet()
    {
        return comp;
    }

    #region Save and Load
    
    public void Save(ref StarGameR8Data data)
    {
        data.StarGameR8C = comp;
    }

    public void Load(StarGameR8Data data)
    {
        comp = data.StarGameR8C;
    }
    #endregion

}

[System.Serializable]
public struct StarGameR8Data
{
    public bool StarGameR8C;
}

