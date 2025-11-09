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
        public KeyShardGameData KeyShardGameData;

        public ClockRotGameData ClockRotGameData;
        public LockGameR3Data LockGameR3Data;

        public ThreadGameManData ThreadGameManData;
        public watchGameData watchGameData;

        public skeleGameManagerData skeleGameManagerData;
        public TrashGameData TrashGameData;

        public StarGameR7Data StarGameR7Data;

        public LockGameR4Data LockGameR4Data;
        public Rope_CodeData Rope_CodeData;

        public MirrorShardData MirrorShardData;
        public SuitcaseData SuitcaseData;
        public TicketShardData TicketShardData;

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
            SaveGameManager.Instance.KeyShardGame.Save(ref _saveData.KeyShardGameData);


        }
        if (_saveData.SceneSaveData.SceneID == "School")
        {

            SaveGameManager.Instance.ClockRotGame.Save(ref _saveData.ClockRotGameData);
            SaveGameManager.Instance.LockGameR3.Save(ref _saveData.LockGameR3Data);

            Debug.Log(RPGManagerR3.getVictor());
            Debug.Log("RPG Save");
        }
        if (_saveData.SceneSaveData.SceneID == "Room4")
        {

            SaveGameManager.Instance.LockGameR4.Save(ref _saveData.LockGameR4Data);

        }

        if (_saveData.SceneSaveData.SceneID == "Room5")
        {

            SaveGameManager.Instance.ThreadGameMan.Save(ref _saveData.ThreadGameManData);
            SaveGameManager.Instance.Collectable.Save(ref _saveData.PlayerData);
            SaveGameManager.Instance.watchGame.Save(ref _saveData.watchGameData);

        }
        if (_saveData.SceneSaveData.SceneID == "Room6")
        {

            SaveGameManager.Instance.skeleMan.Save(ref _saveData.skeleGameManagerData);
            SaveGameManager.Instance.TrashGame.Save(ref _saveData.TrashGameData);

        }
        if (_saveData.SceneSaveData.SceneID == "Room7")
        {

            SaveGameManager.Instance.StarGameR7.Save(ref _saveData.StarGameR7Data);
            SaveGameManager.Instance.Rope_Code.Save(ref _saveData.Rope_CodeData);

        }
        if (_saveData.SceneSaveData.SceneID == "Room10")
        {

            SaveGameManager.Instance.MirrorShard.Save(ref _saveData.MirrorShardData);
            SaveGameManager.Instance.Suitcase.Save(ref _saveData.SuitcaseData);
            SaveGameManager.Instance.TicketShard.Save(ref _saveData.TicketShardData);

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
            SaveGameManager.Instance.KeyShardGame.Load(_saveData.KeyShardGameData);

            //Debug.Log(_saveData.OldTelescopeData.TelescopeComp);


        }
        if (_saveData.SceneSaveData.SceneID == "School")
        {

            SaveGameManager.Instance.ClockRotGame.Load(_saveData.ClockRotGameData);
            SaveGameManager.Instance.LockGameR3.Load(_saveData.LockGameR3Data);
            //Debug.Log(_saveData.OldTelescopeData.TelescopeComp);


        }
        if (_saveData.SceneSaveData.SceneID == "Room4")
        {

            SaveGameManager.Instance.LockGameR4.Load(_saveData.LockGameR4Data);
            //add for other minigames


        }
        if (_saveData.SceneSaveData.SceneID == "Room5")
        {

            SaveGameManager.Instance.ThreadGameMan.Load(_saveData.ThreadGameManData);
            SaveGameManager.Instance.Collectable.Load(_saveData.PlayerData);
            SaveGameManager.Instance.watchGame.Load(_saveData.watchGameData);
            //add for other minigames


        }
        if (_saveData.SceneSaveData.SceneID == "Room6")
        {

            SaveGameManager.Instance.skeleMan.Load(_saveData.skeleGameManagerData);
            SaveGameManager.Instance.TrashGame.Load(_saveData.TrashGameData);
            //add for other minigames

        }

        if (_saveData.SceneSaveData.SceneID == "Room7")
        {

            SaveGameManager.Instance.StarGameR7.Load(_saveData.StarGameR7Data);
            SaveGameManager.Instance.Rope_Code.Load( _saveData.Rope_CodeData);


        }
        if (_saveData.SceneSaveData.SceneID == "Room10")
        {

            SaveGameManager.Instance.MirrorShard.Load(_saveData.MirrorShardData);
            SaveGameManager.Instance.Suitcase.Load(_saveData.SuitcaseData);
            SaveGameManager.Instance.TicketShard.Load(_saveData.TicketShardData);

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
            SaveGameManager.Instance.KeyShardGame.Load(_saveData.KeyShardGameData);

        }
        if (_saveData.SceneSaveData.SceneID == "School")
        {
            SaveGameManager.Instance.ClockRotGame.Load(_saveData.ClockRotGameData);
            SaveGameManager.Instance.LockGameR3.Load(_saveData.LockGameR3Data);


        }
        if (_saveData.SceneSaveData.SceneID == "Room4")
        {
            SaveGameManager.Instance.LockGameR4.Load(_saveData.LockGameR4Data);


        }
        if (_saveData.SceneSaveData.SceneID == "Room5")
        {
            SaveGameManager.Instance.ThreadGameMan.Load(_saveData.ThreadGameManData);
            SaveGameManager.Instance.Collectable.Load(_saveData.PlayerData);
            SaveGameManager.Instance.watchGame.Load(_saveData.watchGameData);
            //add more later


        }
        if (_saveData.SceneSaveData.SceneID == "Room6")
        {
            SaveGameManager.Instance.skeleMan.Load(_saveData.skeleGameManagerData);
            SaveGameManager.Instance.TrashGame.Load(_saveData.TrashGameData);
            //add more later


        }
        if (_saveData.SceneSaveData.SceneID == "Room7")
        {
            SaveGameManager.Instance.StarGameR7.Load(_saveData.StarGameR7Data);
            SaveGameManager.Instance.Rope_Code.Load( _saveData.Rope_CodeData);


        }
        if (_saveData.SceneSaveData.SceneID == "Room10")
        {
            SaveGameManager.Instance.MirrorShard.Load(_saveData.MirrorShardData);
            SaveGameManager.Instance.Suitcase.Load(_saveData.SuitcaseData);
            SaveGameManager.Instance.TicketShard.Load(_saveData.TicketShardData);

        }

    }
}
