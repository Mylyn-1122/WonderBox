using UnityEngine;

public class R6SaveData : MonoBehaviour
{
    public static bool R6C;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Save and Load

    public void Save(ref R6Data data)
    {

        data.R6Complete = (R6_RPG_Game.getVictor()&&R6_Password_Game.returnClear());

    }

    public void Load(R6Data data)
    {
        R6C = data.R6Complete;
        SaveGameManager.R6 = R6C;

    }
    #endregion
}

[System.Serializable]
public struct R6Data
{

    public bool R6Complete;



}
