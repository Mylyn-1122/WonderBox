using UnityEngine;
using System.IO;

public class SaveSystem
{
    private static SaveData _saveData = new SaveData();

    [System.Serializable]
    public struct SaveData
    {
        public PlayerSaveData PlayerData;
        public StainedWindowData StainedWindowData;
        public SceneSaveData SceneSaveData;
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

    private static void HandleSaveData()
    {
        SaveGameManager.Instance.Collectable.Save(ref _saveData.PlayerData);
        SaveGameManager.Instance.StainedGlassWindowGame.Save(ref _saveData.StainedWindowData);

        SaveGameManager.Instance.SceneData.Save(ref _saveData.SceneSaveData);
    }

    public static void Load()
    {
        string saveContent = File.ReadAllText(SaveFileName());

        _saveData = JsonUtility.FromJson<SaveData>(saveContent);
        HandleLoadData();
    }

    private static void HandleLoadData()
    {
       
        SaveGameManager.Instance.StainedGlassWindowGame.Load(_saveData.StainedWindowData);
        SaveGameManager.Instance.Collectable.Load(_saveData.PlayerData);
        SaveGameManager.Instance.SceneData.Load(_saveData.SceneSaveData);
    }
}
