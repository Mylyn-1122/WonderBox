using UnityEngine;
using System.Collections;

public class saveManR4 : MonoBehaviour
{
    public static bool WGComp = false;

    private void Awake()
    {
        SaveGameManager.Instance.saveManR4 = this;
       
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(wait());
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
        
    }

    public void Load(R4SaveData data)
    {

        WGComp = data.WGComplete;
        SaveGameManager.wg = WGComp;


    }
    #endregion
}

[System.Serializable]
public struct R4SaveData
{
    
    public bool WGComplete;
    
}

