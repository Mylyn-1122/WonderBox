using UnityEngine;

public class R8SaveData : MonoBehaviour
{
    public static bool R8C;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #region Save and Load

    public void Save(ref R8Data data)
    {

        data.R8Complete = SaveGameManager.R8;

    }

    public void Load(R8Data data)
    {
        R8C = data.R8Complete;
        SaveGameManager.R8 = R8C;

    }
    #endregion
}

[System.Serializable]
public struct R8Data
{

    public bool R8Complete;



}
