using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

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
        if (Data.UniqueName == "RPGMusicBox")
        {
            SaveGameManager.RPG1 = RPGManagerR1.getVictor();
            data.SceneID = "MusicBox";
        }
        //Debug.Log(Data.UniqueName);
        Debug.Log(data.SceneID);
    }

    public void Load(SceneSaveData data)
    {
        SaveGameManager.Instance.SceneLoad.LoadSceneByIndex(data.SceneID);
        Debug.Log(data.SceneID);
    }

    public async Task LoadAsync(SceneSaveData data)
    {
        await SaveGameManager.Instance.SceneLoad.LoadSceneByIndexAsync(data.SceneID);
    }

    public Task WaitForSceneToBeFullyLoaded()
    {
        TaskCompletionSource<bool> taskCompletion = new TaskCompletionSource<bool>();

        UnityEngine.Events.UnityAction<Scene, LoadSceneMode> sceneLoaderHandler = null;

        sceneLoaderHandler = (scene, mode) =>
        {
            taskCompletion.SetResult(true);
            SceneManager.sceneLoaded -= sceneLoaderHandler;
        };

        SceneManager.sceneLoaded += sceneLoaderHandler;

        return taskCompletion.Task;
    }

}

[System.Serializable]
public struct SceneSaveData
{
    public string SceneID;
}