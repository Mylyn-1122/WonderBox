using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class SaveGameManager : MonoBehaviour
{
    private static SaveGameManager instance;

    public static SaveGameManager Instance
    {
        get
        {
            if (!Application.isPlaying)
            {
                return null;
            }

            if (instance == null)
            {
                Instantiate(Resources.Load<SaveGameManager>("SaveGameManager"));
            }

            return instance;
        }
    }

    public Collectable Collectable { get; set; }
    public StainedGlassWindowGame StainedGlassWindowGame { get; set; }
    public SceneData SceneData { get; set; }
    public SceneLoad SceneLoad { get; set; }


    public static bool SaveSignal = false;
    public static bool RPG1 = false;
    public static bool LoadSignal = false;

    private bool _isSaving;
    private bool _isLoading;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
       


    // Update is called once per frame
    private void Update()
    {
        if (Keyboard.current.numpad0Key.wasPressedThisFrame)
        {
            SaveSignal = true;
        }

        if (Keyboard.current.numpad1Key.wasPressedThisFrame)
        {
            LoadSignal = true;
        }

        //Debug.Log(RPG1);

        if (SaveSignal && !_isSaving)
        {
            SaveAsync();
            SaveSignal = false;
        }

        if (LoadSignal && !_isLoading)
        {
            LoadAsync();
            LoadSignal = false;
        }
    }

    public async void SaveAsync()
    {
        _isSaving = true;
        await SaveSystem.SaveAsynchronously();
        _isSaving = false;
    }
    public async void LoadAsync()
    {
        _isLoading = true;
        await SaveSystem.LoadAsync();
        _isLoading = false;
    }
}

