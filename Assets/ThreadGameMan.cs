using UnityEngine;

public class ThreadGameMan : MonoBehaviour
{
    public static bool wins;

    private void Awake()
    {
        SaveGameManager.Instance.ThreadGameMan = this;
    }

    private void Start()
    {
        wins = false;
    }

    private void Update()
    {
        if (ThreadGameManager.winGet())
        {
            wins = true;
        }
    }

    #region save and load

    public void Save(ref ThreadGameManData data)
    {
        data.ThreadGameR5Comp = wins;

    }

    public void Load(ThreadGameManData data)
    {
        wins = data.ThreadGameR5Comp;
    }



    #endregion


}
[System.Serializable]
public struct ThreadGameManData
{
    public bool ThreadGameR5Comp;
}
 

