using UnityEngine;

public class SceneData : MonoBehaviour
{
    public SceneDataSO Data;

    private void Awake()
    {
        SaveGameManager.Instance.SceneData = this;
    }

    public void Save(ref SceneSaveData data)
    {
        data.SceneID = Data.UniqueName;
        //Debug.Log(Data.UniqueName);
        Debug.Log(data.SceneID);
    }

    public void Load(SceneSaveData data)
    {
        SaveGameManager.Instance.SceneLoad.LoadSceneByIndex(data.SceneID);
        Debug.Log(data.SceneID);
    }

}

[System.Serializable]
public struct SceneSaveData
{
    public string SceneID;
}