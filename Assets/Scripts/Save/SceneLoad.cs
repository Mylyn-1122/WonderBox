using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class SceneLoad : MonoBehaviour
{
    [SerializeField] private SceneDataSO[] _sceneDataSOArray;
    private Dictionary<string, int> _sceneIDtoIndexmap = new Dictionary<string, int>();

    private void Awake()
    {
        SaveGameManager.Instance.SceneLoad = this;

        PopulateSceneMapping();
    }

    private void PopulateSceneMapping()
    {
        foreach (var sceneDataSO in _sceneDataSOArray)
        {
            _sceneIDtoIndexmap[sceneDataSO.UniqueName] = sceneDataSO.SceneIndex;
        }
    }

    public void LoadSceneByIndex(string saveSceneID)
    {
        if(_sceneIDtoIndexmap.TryGetValue(saveSceneID, out int sceneIndex))
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogError($"No Scene found for ID: {saveSceneID}");
        }
    }

    public async Task LoadSceneByIndexAsync(string saveSceneID)
    {
        if (_sceneIDtoIndexmap.TryGetValue(saveSceneID, out int sceneIndex))
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
            asyncLoad.allowSceneActivation = false;

            while (!asyncLoad.isDone)
            {
                if (asyncLoad.progress>= 0.9f)
                {
                    asyncLoad.allowSceneActivation = true;
                    break;
                }
                await Task.Yield();

            }
        }
        else
        {
            Debug.LogError($"No Scene found for ID: {saveSceneID}");
        }
    }

}