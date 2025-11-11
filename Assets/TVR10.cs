using UnityEngine;

public class TVR10 : MonoBehaviour
{
    private void Awake()
    {
        SaveGameManager.Instance.TVR10 = this;
    }
    private static bool complete;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        complete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (WireGameTV.getComplete())
        {
            complete = true;
        }
    }

    #region save and load

    public void Save(ref WireTVDataR10 data)
    {
        data.WireTVComp10 = complete;

    }

    public void Load(WireTVDataR10 data)
    {
        if (data.WireTVComp10)
        {
            complete = data.WireTVComp10;
            WireGameTV.setComp();
        }

    }



    #endregion

}


[System.Serializable]
public struct WireTVDataR10
{
    public bool WireTVComp10;
}

