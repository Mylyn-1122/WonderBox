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
        ThreadGameManager.notWin();
    }

    private void Update()
    {
        if (ThreadGameManager.winGet())
        {
            wins = true;
        }
    }

    public static bool getWins()
    {
        return wins;
    }
    #region save and load

    public void Save(ref ThreadGameManData data)
    {
        data.ThreadGameR5Comp = wins;

    }

    public void Load(ThreadGameManData data)
    {
        if (data.ThreadGameR5Comp)
        {
            wins = data.ThreadGameR5Comp;
            ThreadGameManager.setWin();
        }
    }



    #endregion


}
[System.Serializable]
public struct ThreadGameManData
{
    public bool ThreadGameR5Comp;
}
 

