using UnityEngine;

public class TVR2 : MonoBehaviour
{
    private void Awake()
    {
        SaveGameManager.Instance.TVR2 = this;
    }
    private static bool complete = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        WireGameTV.cancel();
    }

    // Update is called once per frame
    void Update()
    {
        if (WireGameTV.getComplete())
        {
            complete = true;
        }
    }

    public static bool getComplete()
    {
        return complete;
    }
    #region save and load

    public void Save(ref WireTVDataR2 data)
    {
        data.WireTVComp2 = complete;

    }

    public void Load(WireTVDataR2 data)
    {
        if (data.WireTVComp2)
        {
            complete = data.WireTVComp2;
            WireGameTV.setComp();
        }

    }



    #endregion

}


[System.Serializable]
public struct WireTVDataR2
{
    public bool WireTVComp2;
}

