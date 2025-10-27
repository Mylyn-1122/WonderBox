using UnityEngine;

public class StarGameR7 : MonoBehaviour
{

    private static bool victor;

    private void Awake()
    {
        SaveGameManager.Instance.StarGameR7 = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        victor = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ThreadGameManager.winGet())
        {
            victor = true;
        }
    }

    public static bool victorGet()
    {
        return victor;
    }

    #region save and load

    public void Save(ref StarGameR7Data data)
    {
        data.starCleared = victor;

    }

    public void Load(StarGameR7Data data)
    {
        victor = data.starCleared;
    }



    #endregion


}
[System.Serializable]
public struct StarGameR7Data
{
    public bool starCleared;
}
 

