using UnityEngine;

public class saveManR3 : MonoBehaviour
{
    public static bool RPG3Comp = false;

    private void Awake()
    {
        SaveGameManager.Instance.saveManR3 = this;

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SaveSystem.Save();
        if (SaveGameManager.RPG3Fin == true)
        {
            
            SaveGameManager.RPG3Fin = false;
            //saveMan.GetComponent<SaveGameManager>().loadGame();
            SaveSystem.Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Save and Load

    public void Save(ref R3Data data)
    {
       
        data.RPG3C = SaveGameManager.RPG1;
        
    }

    public void Load(R3Data data)
    {
        RPG3Comp = data.RPG3C;
        SaveGameManager.RPG3 = RPG3Comp;

    }
    #endregion
}

[System.Serializable]
public struct R3Data
{
   
    public bool RPG3C;
    

}
