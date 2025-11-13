using UnityEngine;
using System.Collections;

public class saveManR4 : MonoBehaviour
{
    public static bool WGComp = false;
    public static bool R4C = false;
    private void Awake()
    {
        SaveGameManager.Instance.saveManR4 = this;
       
    }

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        SaveSystem.Save();
        if (SaveGameManager.wgFin)
        {
            SaveGameManager.wgFin = false;
            SaveSystem.Load();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Save and Load

    public void Save(ref R4SaveData data)
    {

        data.WGComplete= SaveGameManager.wg;
        data.R4Complete = (SaveGameManager.wg && R4_ShardGame.getComp());
        
    }

    public void Load(R4SaveData data)
    {

        WGComp = data.WGComplete;
        SaveGameManager.wg = WGComp;

        R4C = data.R4Complete;
        SaveGameManager.R4 = R4C;

    }
    #endregion
}

[System.Serializable]
public struct R4SaveData
{
    
    public bool WGComplete;
    public bool R4Complete;
    
}

