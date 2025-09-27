using UnityEngine;
using System.IO;

public class SaveSystem
{
    private static SaveData _saveData = new SaveData();

    [System.Serializable]
    public struct SaveData
    {
        public PlayerSaveData PlayerData;
    }

    public static string SaveFileName()
    {
        string savefile = Application.persistentDataPath + "/save" + ".save";
        return savefile;
    }

    public static void Save()
    {
        HandlesaveData();

        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(_saveData, true));
    }

    private static void HandlesaveData()
    {
        SaveGameManager.Instance.Collectable.Save(ref _saveData.PlayerData);
    }

    public static void Load()
    {
        string saveContent = File.ReadAllText(SaveFileName());

        _saveData = JsonUtility.FromJson<SaveData>(saveContent);
        HandleLoadData();
    }

    private static void HandleLoadData()
    {
        SaveGameManager.Instance.Collectable.Load(_saveData.PlayerData);
    }
}
