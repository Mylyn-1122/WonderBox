using UnityEngine;

public class R7SaveData : MonoBehaviour
{
    public static bool R7C;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #region Save and Load

    public void Save(ref R7Data data)
    {

        data.R7Complete = SaveGameManager.R7;

    }

    public void Load(R7Data data)
    {
        R7C = data.R7Complete;
        SaveGameManager.R7 = R7C;

    }
    #endregion
}

[System.Serializable]
public struct R7Data
{

    public bool R7Complete;



}
