using UnityEngine;
using System.IO;
using System.Threading.Tasks;

public class SaveSystem
{
    private static SaveData _saveData = new SaveData();

    [System.Serializable]
    public struct SaveData
    {
        public PlayerSaveData PlayerData;
        public StainedWindowData StainedWindowData;
        public SceneSaveData SceneSaveData;
        public OldTelescopeData OldTelescopeData;
        public WireTVData WireTVData;
        public ClockRotGameData ClockRotGameData;

    }

    public static string SaveFileName()
    {
        string savefile = Application.persistentDataPath + "/save" + ".save";
        return savefile;
    }

    public static void Save()
    {
        HandleSaveData();

        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(_saveData, true));
    }

    #region Save Async

    public static async Task SaveAsynchronously()
    {
        await SaveAsync();
    }

    private static async Task SaveAsync()
    {
        HandleSaveData();

        await File.WriteAllTextAsync(SaveFileName(), JsonUtility.ToJson(_saveData, true));
    }

    #endregion

    private static void HandleSaveData()
    {
        

        if (_saveData.SceneSaveData.SceneID == "MusicBox")
        {
            Debug.Log(_saveData.PlayerData.RPG1Complete);
            Debug.Log(Collectable.RPG1Comp);
            SaveGameManager.Instance.Collectable.Save(ref _saveData.PlayerData);
            SaveGameManager.Instance.StainedGlassWindowGame.Save(ref _saveData.StainedWindowData);

            
            Debug.Log("Music Box Save");

        }

        if (_saveData.SceneSaveData.SceneID == "RPGMusicBox")
        {
            SaveGameManager.Instance.Collectable.Save(ref _saveData.PlayerData);
            SaveGameManager.Instance.StainedGlassWindowGame.Save(ref _saveData.StainedWindowData);

            Debug.Log(RPGManagerR1.getVictor());
            Debug.Log("RPG Save");
        }

        if (_saveData.SceneSaveData.SceneID == "TreeHouse")
        {

            SaveGameManager.Instance.OldTelescope.Save(ref _saveData.OldTelescopeData);
            SaveGameManager.Instance.WireGameTV.Save(ref _saveData.WireTVData);
            

        }
        if (_saveData.SceneSaveData.SceneID == "School")
        {

            SaveGameManager.Instance.ClockRotGame.Save(ref _saveData.ClockRotGameData);
            


        }




        SaveGameManager.Instance.SceneData.Save(ref _saveData.SceneSaveData);

        
    }

    public static void Load()
    {
        string saveContent = File.ReadAllText(SaveFileName());

        _saveData = JsonUtility.FromJson<SaveData>(saveContent);
        HandleLoadData();
    }

    #region Load Async

    

    public static async Task LoadAsync()
    {
        string saveContent = File.ReadAllText(SaveFileName());

        _saveData = JsonUtility.FromJson<SaveData>(saveContent);

        await HandleLoadDataAsync();
    }

    private static async Task HandleLoadDataAsync()
    {
        await SaveGameManager.Instance.SceneData.LoadAsync(_saveData.SceneSaveData);

        await SaveGameManager.Instance.SceneData.WaitForSceneToBeFullyLoaded();

        if (_saveData.SceneSaveData.SceneID == "MusicBox")
        {
            SaveGameManager.Instance.StainedGlassWindowGame.Load(_saveData.StainedWindowData);
            SaveGameManager.Instance.Collectable.Load(_saveData.PlayerData);

            Debug.Log(RPGManagerR1.getVictor());
        }

        if (_saveData.SceneSaveData.SceneID == "TreeHouse")
        {

            SaveGameManager.Instance.OldTelescope.Load(_saveData.OldTelescopeData);
            SaveGameManager.Instance.WireGameTV.Load(_saveData.WireTVData);
            //Debug.Log(_saveData.OldTelescopeData.TelescopeComp);


        }
        if (_saveData.SceneSaveData.SceneID == "School")
        {

            SaveGameManager.Instance.ClockRotGame.Load(_saveData.ClockRotGameData);
          

        }
    }

    #endregion

    private static void HandleLoadData()
    {


        if (_saveData.SceneSaveData.SceneID == "MusicBox")
        {
            SaveGameManager.Instance.StainedGlassWindowGame.Load(_saveData.StainedWindowData);
            SaveGameManager.Instance.Collectable.Load(_saveData.PlayerData);


        }

        if (_saveData.SceneSaveData.SceneID == "TreeHouse")
        {
            SaveGameManager.Instance.OldTelescope.Load(_saveData.OldTelescopeData);
            SaveGameManager.Instance.WireGameTV.Load(_saveData.WireTVData);


        }
        if (_saveData.SceneSaveData.SceneID == "School")
        {
            SaveGameManager.Instance.ClockRotGame.Load(_saveData.ClockRotGameData);


        }


    }
}
