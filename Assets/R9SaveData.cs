using UnityEngine;

public class R9SaveData : MonoBehaviour
{
    public static bool R9C;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #region Save and Load

    public void Save(ref R9Data data)
    {

        data.R9Complete = (R9_ShardGame.getComp());

    }

    public void Load(R9Data data)
    {
        R9C = data.R9Complete;
        SaveGameManager.R9 = R9C;

    }
    #endregion
}

[System.Serializable]
public struct R9Data
{

    public bool R9Complete;



}
