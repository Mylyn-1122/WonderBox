using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class DataPerisistenceManager : MonoBehaviour
{


    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;

    public static DataPerisistenceManager instance { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene. Destroying the newest one.");
            
        }
        instance = this;
    }


    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }


    public void NewGame()
    {
        this.gameData = new GameData();
        
    }

    public void LoadGame()
    {
        //load saved data
        this.gameData = dataHandler.Load();


        //If no data
        if(this.gameData == null)
        {
            Debug.Log("No data was found, Initializing data to defaults.");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        
    }

    public void SaveGame()
    {
        Debug.Log("here");
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);

        
    }

    private void OnApplicationQuit()
    {
        
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);

    }
}
