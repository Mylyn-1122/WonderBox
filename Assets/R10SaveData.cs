using UnityEngine;

public class R10SaveData : MonoBehaviour
{
    public static bool R10C;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #region Save and Load

    public void Save(ref R10Data data)
    {

        data.R10Complete = SaveGameManager.R10;

    }

    public void Load(R10Data data)
    {
        R10C = data.R10Complete;
        SaveGameManager.R10 = R10C;

    }
    #endregion
}

[System.Serializable]
public struct R10Data
{

    public bool R10Complete;



}
