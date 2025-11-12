using UnityEngine;

public class R2SaveMan : MonoBehaviour
{
    public static bool R2C;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SaveGameManager.Instance.saveManR2 = this;
    }

    #region Save and Load
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save(ref R2SaveData data)
    {

        data.R2Complete = (OldTelescope.getClear() && TVR2.getComplete());

    }

    public void Load(R2SaveData data)
    {

        R2C = data.R2Complete;
        SaveGameManager.R2 = R2C;


    }
#endregion
}

[System.Serializable]
public struct R2SaveData
{

    public bool R2Complete;


}
